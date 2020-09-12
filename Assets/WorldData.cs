using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldData
{
    public static readonly int _chunkWidth = 32;
    public static readonly int _chunkHeight = 32;
    public static readonly int _worldHeightInChunks = 4;
    public static int _worldHeightInVoxels {
        get { return _worldHeightInChunks * _chunkHeight; }
    }
    public static int _worldBottomInChunks {
        get { return -_worldHeightInChunks / 2; }
    }
    public static int _worldTopInChunks
    {
        get { return (_worldHeightInChunks / 2) + 1; }
    }

    public static Vector3Int GlobalPosToChunkCoord(Vector3 pos)
    {
        return new Vector3Int(Mathf.FloorToInt(pos.x / _chunkWidth), Mathf.FloorToInt(pos.y / _chunkHeight), Mathf.FloorToInt(pos.z / _chunkWidth));
    }

    public static Vector3Int ChunkCoordToGlobalPos(Vector3Int pos)
    {
        return new Vector3Int(pos.x * _chunkWidth, pos.y * _chunkHeight, pos.z * _chunkWidth);
    }

    public static Vector3Int Vector3ToInt(Vector3 vector)
    {
        return new Vector3Int((int)vector.x, (int)vector.y, (int)vector.z);
    }
    public static Vector3 IntToVector3(Vector3Int vector)
    {
        return new Vector3(vector.x, vector.y, vector.z);
    }
}
