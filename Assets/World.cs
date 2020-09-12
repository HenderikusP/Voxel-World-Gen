using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Collections.Concurrent;


public class World : MonoBehaviour
{
    [Header("Debug:")]
    public bool _debugMode;

    [Header("Material:")]
    public Material _material;

    [Header("Chunks:")]
    [SerializeField] private Vector3Int _spawnChunk = new Vector3Int(0, 0, 0);
    [SerializeField] private Vector3Int _currentChunk;

    [Header("View Distance:")]
    [SerializeField] private int _viewDistanceInChunks = 5;
    [SerializeField] private int _deactivateDistance = 15;

    public Dictionary<Vector3Int, Chunk> _chunks = new Dictionary<Vector3Int, Chunk>();
    private List<Vector3Int> _activeChunks = new List<Vector3Int>();
    private bool _currentlyApplyingMeshes;

    private List<Vector3Int> _chunksToPopulate = new List<Vector3Int>();
    private List<Vector3Int> _chunksToMod = new List<Vector3Int>();
    private List<Vector3Int> _chunksToClearAndCreateMeshData = new List<Vector3Int>();

    public ConcurrentQueue<Vector3Int> _chunksToApplyMesh = new ConcurrentQueue<Vector3Int>();

    Thread thread2;
    Thread thread;


    /// <summary>
    /// TODO:
    /// -ADD TO GIT HUB
    /// -ADD DYNAMIC THREAD THING
    /// -CLEAN UP COOMENTS AND MAKE CODE PRETTY, ESTABLISH CODE STYLE, LOOK AT GETTING "PRITTIER".
    /// -GO THROUGH AND CHANGE DATA TYPES FOR MEMEORY REASONS
    /// -TRY FIX MEMORY PROBLEM
    /// -ADD BREAKING AND ADDING BLOCKS
    /// </summary>

    private void OnDisable()
    {
        if (thread != null) thread.Abort();
        if (thread2 != null) thread2.Abort();
    }

    private void Start()
    {
        Seed.Calculate("zvhv9leuyyzw93wd");
        UpdateChunks(true);
        Structures.LoadStructures();
    }

    private void Update()
    {
        #region Load More Chunks
        if (!_currentChunk.Equals(WorldData.GlobalPosToChunkCoord(Camera.main.transform.position)))
        {
            if (_debugMode) DebugHelper.Log("PLAYER IN NEW CHUNK", "cyan");
            _currentChunk = WorldData.GlobalPosToChunkCoord(Camera.main.transform.position);
            UpdateChunks();
        }
        #endregion



        #region Apply Meshes Coroutine

        if (_chunksToApplyMesh.Count > 0 && !_currentlyApplyingMeshes)
            StartCoroutine("ApplyMeshes");

        #endregion



        #region Start Thread

        if ((thread == null || !thread.IsAlive) && (_chunksToPopulate.Count > 0 || _chunksToMod.Count > 0 || _chunksToClearAndCreateMeshData.Count > 0))
        {
            ThreadJob threadJob = new ThreadJob(_chunksToPopulate, _chunksToMod, _chunksToClearAndCreateMeshData, this);

            foreach (Vector3Int chunk in _chunksToPopulate)
                _chunks.Add(chunk, new Chunk(chunk, this));

            _chunksToPopulate.Clear();
            _chunksToMod.Clear();
            _chunksToClearAndCreateMeshData.Clear();

            thread = new Thread(new ThreadStart(threadJob.Run));
            thread.Start();
        }

        if ((thread2 == null || !thread2.IsAlive) && (_chunksToPopulate.Count > 0 || _chunksToMod.Count > 0 || _chunksToClearAndCreateMeshData.Count > 0))
        {
            if (_debugMode) DebugHelper.Log("THREAD 2", "yellow");

            ThreadJob threadJob = new ThreadJob(_chunksToPopulate, _chunksToMod, _chunksToClearAndCreateMeshData, this);

            foreach (Vector3Int chunk in _chunksToPopulate)
                _chunks.Add(chunk, new Chunk(chunk, this));

            _chunksToPopulate.Clear();
            _chunksToMod.Clear();
            _chunksToClearAndCreateMeshData.Clear();

            thread2 = new Thread(new ThreadStart(threadJob.Run));
            thread2.Start();
        }

        #endregion
    }

    private IEnumerator ApplyMeshes()
    {
        _currentlyApplyingMeshes = true;

        while (_chunksToApplyMesh.Count > 0)
        {
            Vector3Int chunk;
            _chunksToApplyMesh.TryDequeue(out chunk);
            if (chunk != null) // Might not need.
            {
                _chunks[chunk]._active = true;
                _chunks[chunk]._finnished = true;
                _chunks[chunk].CreateGameObject();
                _chunks[chunk].ApplyMesh();
                _activeChunks.Add(chunk);
            }
            yield return null;
        }

        _currentlyApplyingMeshes = false;
    }

    private void UpdateChunks(bool initialPass = false)
    {
        Vector3Int[] chunksInArea = ChunkCircleArea(_currentChunk, _viewDistanceInChunks); // Make it so the further under ground, the smaller it is, the higher the flatter to cover more distance.

        foreach (Vector3Int chunkCoord in chunksInArea)
        {
            if (!_chunks.ContainsKey(chunkCoord)) // If it doesnt exist.
            {
                if (!_chunksToPopulate.Contains(chunkCoord)) // And its not inline to be created.
                {
                    _chunksToPopulate.Add(chunkCoord);
                    if (!initialPass && _chunksToPopulate.Count > 100)
                        _chunksToPopulate.RemoveAt(0);
                }
            }
            else if (!_chunks[chunkCoord]._active && _chunks[chunkCoord]._finnished)
            {
                _chunks[chunkCoord]._active = true;
                _chunks[chunkCoord]._finnished = false;
                _chunksToClearAndCreateMeshData.Add(chunkCoord);
                if (_debugMode) DebugHelper.Log("RELOADING CHUNK", "magenta");
            }
        }

        foreach (Vector3Int chunkCoord in _activeChunks.ToArray())
        {
            if (Voxel._voxelMods.ContainsKey(chunkCoord) && _chunks[chunkCoord]._finnished)
            {
                _chunks[chunkCoord]._finnished = false;
                _chunksToMod.Add(chunkCoord);
                if (_debugMode) DebugHelper.Log("MODDING CHUNK", "blue");
            }
            else if (Vector3Int.Distance(chunkCoord, _currentChunk) > _deactivateDistance && _chunks[chunkCoord]._active)
            {
                if (_chunks[chunkCoord]._modified)
                {
                    if (_debugMode) DebugHelper.Log("CHUNK SAVED", "green");
                    _chunks[chunkCoord]._active = false;
                    _activeChunks.Remove(chunkCoord);
                    _chunks[chunkCoord].Deactivate();
                }
                else
                {
                    if (_debugMode) DebugHelper.Log("CHUNK DESTROYED", "red");
                    _chunks[chunkCoord]._active = false;
                    _activeChunks.Remove(chunkCoord);
                    _chunks[chunkCoord].Deactivate();
                    _chunks.Remove(chunkCoord);
                }
            }
        }
    }

    private Vector3Int[] ChunkCircleArea(Vector3Int centre, int radius)
    {
        List<Vector3Int> chunks = new List<Vector3Int>();
        for (int x = centre.x - radius; x < centre.x + radius; x++)
        {
            for (int y = centre.y - radius; y < centre.y + radius; y++)
            {
                for (int z = centre.z - radius; z < centre.z + radius; z++)
                {
                    Vector3Int chunk = new Vector3Int(x, y, z);

                    if (y >= WorldData._worldBottomInChunks && y <= WorldData._worldTopInChunks)
                    {
                        if (Vector3Int.Distance(centre, chunk) < radius)
                            chunks.Add(chunk);
                    }





                    //if (Vector3Int.Distance(centre, chunk) < radius / 3)
                    //    chunks.Add(chunk);

                    //else if (Vector3Int.Distance(centre, chunk) < radius)
                    //{
                    //    Vector3 vec = Camera.main.WorldToViewportPoint(new Vector3(x * WorldData._chunkWidth, y * WorldData._chunkHeight, z * WorldData._chunkWidth));
                    //    if (vec.x >= 0 && vec.x <= 1 && vec.z > 0)
                    //        chunks.Add(chunk);
                    //}
                }
            }

        }
        chunks.Sort((y, x) => Vector3.Distance(x, centre).CompareTo(Vector3.Distance(y, centre)));
        chunks.Reverse();
        return chunks.ToArray();
    }

    public bool isVoxelSolid(Vector3Int pos)
    {
        Vector3Int chunkCoord = WorldData.GlobalPosToChunkCoord(pos);
        pos -= WorldData.ChunkCoordToGlobalPos(chunkCoord);

        if (_chunks.ContainsKey(chunkCoord))
            return _chunks[chunkCoord].IsVoxelSolid(new Vector3Int(Mathf.Abs(pos.x), Mathf.Abs(pos.y), Mathf.Abs(pos.z)));
        else
            return true; // If chunk dosnt not exist currently.
    }
}

public class ThreadJob {

    private World _world;
    private List<Vector3Int> _chunksToPopulateThread;
    private List<Vector3Int> _chunksToModThread;
    private List<Vector3Int> _chunksToClearAndCreateMeshDataThread;

    public ThreadJob(List<Vector3Int> chunksToPopulate, List<Vector3Int> chunksToMod, List<Vector3Int> chunksToClearAndCreateMeshData, World world) {
        _chunksToPopulateThread = new List<Vector3Int>(chunksToPopulate);
        _chunksToModThread = new List<Vector3Int>(chunksToMod);
        _chunksToClearAndCreateMeshDataThread = new List<Vector3Int>(chunksToClearAndCreateMeshData);
        _world = world;
    }

    public void Run() {
        while (_chunksToPopulateThread.Count > 0)
        {
            _world._chunks[_chunksToPopulateThread[0]].PopulateVoxels();
            _chunksToModThread.Add(_chunksToPopulateThread[0]);
            _chunksToPopulateThread.RemoveAt(0);
        }

        while (_chunksToModThread.Count > 0)
        {
            if (Voxel._voxelMods.ContainsKey(_chunksToModThread[0])) // If Mods are found for chunk then add them.
            {
                _world._chunks[_chunksToModThread[0]].AddVoxelMods(Voxel._voxelMods[_chunksToModThread[0]].ToArray());
                Voxel._voxelMods.Remove(_chunksToModThread[0]);
            }
            _chunksToClearAndCreateMeshDataThread.Add(_chunksToModThread[0]);
            _chunksToModThread.RemoveAt(0);
        }

        while (_chunksToClearAndCreateMeshDataThread.Count > 0)
        {
            _world._chunks[_chunksToClearAndCreateMeshDataThread[0]].ClearAndCreateMeshData();
            _world._chunksToApplyMesh.Enqueue(_chunksToClearAndCreateMeshDataThread[0]);
            _chunksToClearAndCreateMeshDataThread.RemoveAt(0);
        }
    }
}