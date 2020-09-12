using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    /// <summary>
    /// Three stages of chunk gen:
    /// 1. Object creation.
    ///     -Add to _chunks.
    /// 2. Population.
    /// 3. Mod.
    /// 4. Generate Mesh Data.
    /// 5. Create and apply mesh.
    /// </summary>
    public bool _finnished;
    public bool _active;
    public bool _modified;
    private World _world;
    private GameObject _chunkGameObject;
    private MeshRenderer _meshRenderer;
    private MeshFilter _meshFilter;
    private MeshCollider _meshCollider;

    private int _vertexIndex = 0;
    private List<Vector3> _vertices = new List<Vector3>();
    private List<int> _triangles = new List<int>();
    private List<Vector2> _uvs = new List<Vector2>();

    public int[,,] _voxels = new int[WorldData._chunkWidth, WorldData._chunkHeight, WorldData._chunkWidth];
    private Vector3Int _chunkOrign; // Global chunk orign.
    private Vector3Int _chunkCoord;

    public Chunk(Vector3Int chunkCoord, World world)
    {
        _world = world;
        _chunkCoord = chunkCoord;
        _chunkOrign = new Vector3Int(_chunkCoord.x * WorldData._chunkWidth, _chunkCoord.y * WorldData._chunkHeight, _chunkCoord.z * WorldData._chunkWidth);
    }

    public void CreateGameObject()
    {
        if (_chunkGameObject == null)
        {
            _chunkGameObject = new GameObject(string.Format("Chunk {0}x {1}y {2}z", _chunkCoord.x, _chunkCoord.y, _chunkCoord.z));
            _chunkGameObject.transform.SetParent(_world.transform);
            _chunkGameObject.transform.position = _chunkOrign;

            //_meshCollider = _chunkGameObject.AddComponent<MeshCollider>();
            _meshFilter = _chunkGameObject.AddComponent<MeshFilter>();
            _meshRenderer = _chunkGameObject.AddComponent<MeshRenderer>();
            _meshRenderer.material = _world._material;
            _meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;
        }
        else
            _chunkGameObject.SetActive(true);
    }

    public void PopulateVoxels()
    {
        for (int x = 0; x < WorldData._chunkWidth; x++)
        {
            for (int y = 0; y < WorldData._chunkHeight; y++)
            {
                for (int z = 0; z < WorldData._chunkWidth; z++)
                {
                    _voxels[x, y, z] = Voxel.Calculate(_chunkOrign + new Vector3Int(x, y, z));
                }
            }
        }
    }

    public void AddVoxelMods(VoxelMod[] voxelMods) 
    {
        if (voxelMods.Length > 0 && !_modified) _modified = true;

        foreach (VoxelMod voxelMod in voxelMods)
        {
            if (voxelMod._pos.x >= 0 && voxelMod._pos.x < WorldData._chunkWidth && voxelMod._pos.y >= 0 && voxelMod._pos.y < WorldData._chunkHeight && voxelMod._pos.z >= 0 && voxelMod._pos.z < WorldData._chunkWidth)
            {
                _voxels[voxelMod._pos.x, voxelMod._pos.y, voxelMod._pos.z] = voxelMod._id;
            }
        }
    }

    public void ClearAndCreateMeshData()
    {
        _vertexIndex = 0;
        _vertices.Clear();
        _triangles.Clear();
        _uvs.Clear();

        for (int x = 0; x < WorldData._chunkWidth; x++)
        {
            for (int z = 0; z < WorldData._chunkWidth; z++)
            {
                for (int y = 0; y < WorldData._chunkHeight; y++)
                {
                    AddVoxelDataToChunk(new Vector3Int(x, y, z));
                }
            }
        }
    }

    private void AddVoxelDataToChunk(Vector3Int chunkRelPos)
    {
        int blockID = _voxels[Mathf.RoundToInt(chunkRelPos.x), Mathf.RoundToInt(chunkRelPos.y), Mathf.RoundToInt(chunkRelPos.z)];

        for (int f = 0; f < 6; f++)
        {
            if (!IsVoxelSolid(chunkRelPos + VoxelData._faceChecks[f]) && blockID != 0)
            {
                for (int v = 0; v < 4; v++)
                    _vertices.Add(chunkRelPos + VoxelData._voxelVertices[VoxelData._voxelTriangles[f, v]]);

                AddTexture(VoxelData._blocks[blockID]._faceTextures[f]);

                int[] vs = new int[] { 0, 1, 2, 2, 1, 3 };
                for (int v = 0; v < 6; v++)
                    _triangles.Add(_vertexIndex + vs[v]);

                _vertexIndex += 4;
            }
        }
    }

    public bool IsVoxelSolid(Vector3Int chunkRelPos)
    {
        if (IsVoxelInChunk(chunkRelPos))
            return VoxelData._blocks[_voxels[chunkRelPos.x, chunkRelPos.y, chunkRelPos.z]]._isSolid;
        else
            return false;
            return _world.isVoxelSolid(_chunkOrign + chunkRelPos); // CAUSES CRASH
    }

    private bool IsVoxelInChunk(Vector3Int chunkRelPos)
    {
        if (chunkRelPos.x < 0 || chunkRelPos.x >= WorldData._chunkWidth || chunkRelPos.y < 0 || chunkRelPos.y >= WorldData._chunkHeight || chunkRelPos.z < 0 || chunkRelPos.z >= WorldData._chunkWidth)
            return false;
        else
            return true;
    }

    private void AddTexture(int textureId)
    {
        float y = textureId / VoxelData._textureAtlasWidthInBlocks;
        float x = textureId - (y * VoxelData._textureAtlasWidthInBlocks);

        x *= VoxelData._normalizedBlockTextureSize;
        y *= VoxelData._normalizedBlockTextureSize;

        y = 1f - y - VoxelData._normalizedBlockTextureSize;

        _uvs.Add(new Vector2(x, y));
        _uvs.Add(new Vector2(x, y + VoxelData._normalizedBlockTextureSize));
        _uvs.Add(new Vector2(x + VoxelData._normalizedBlockTextureSize, y));
        _uvs.Add(new Vector2(x + VoxelData._normalizedBlockTextureSize, y + VoxelData._normalizedBlockTextureSize));
    }

    public void ApplyMesh()
    {
        //Debug.Log(_chunkCoord);
        CreateGameObject();
        Mesh mesh = new Mesh();
        mesh.vertices = _vertices.ToArray();
        mesh.triangles = _triangles.ToArray();
        mesh.uv = _uvs.ToArray();
        mesh.RecalculateNormals();
        _meshFilter.mesh = mesh;
        
        //_meshCollider.sharedMesh = mesh; // Exspecive.
    }

    public void Deactivate() {
        _vertexIndex = 0;
        _vertices.Clear();
        _triangles.Clear();
        _uvs.Clear();
        //_meshCollider.sharedMesh.Clear();
        Mesh.Destroy(_meshFilter.sharedMesh);
        GameObject.Destroy(_chunkGameObject);
    }
}