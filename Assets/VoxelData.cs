using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VoxelData
{
    public static readonly int _textureAtlasWidthInBlocks = 32;

    public static float _normalizedBlockTextureSize
    {
        get { return 1f / _textureAtlasWidthInBlocks; }
    }

    public static readonly Dictionary<int, Block> _blocks = new Dictionary<int, Block>() {
        { 0, new Block("Air", false, null) },
        { 1, new Block("Dirt", true, new int[] { 2, 2, 2, 2, 2, 2 }) },
        { 2, new Block("Grass", true, new int[] { 1, 1, 0, 2, 1, 1 }) },
        { 3, new Block("Stone", true, new int[] { 3, 3, 3, 3, 3, 3 }) },
        { 4, new Block("BROWN", true, new int[] { 4, 4, 4, 4, 4, 4 }) },
        { 5, new Block("GREEN", true, new int[] { 5, 5, 5, 5, 5, 5 }) },
    };

    public static readonly Vector3Int[] _voxelVertices = new Vector3Int[8] {
        new Vector3Int(0, 0, 0),
        new Vector3Int(1, 0, 0),
        new Vector3Int(1, 1, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(0, 0, 1),
        new Vector3Int(1, 0, 1),
        new Vector3Int(1, 1, 1),
        new Vector3Int(0, 1, 1)
    };

    public static readonly Vector3Int[] _faceChecks = new Vector3Int[6] {
        new Vector3Int(0, 0, -1),
        new Vector3Int(0, 0, 1),
        new Vector3Int(0, 1, 0),
        new Vector3Int(0, -1, 0),
        new Vector3Int(-1, 0, 0),
        new Vector3Int(1, 0, 0)
    };

    public static readonly int[,] _voxelTriangles = new int[6, 4] {
        { 0, 3, 1, 2 }, // Back face.
        { 5, 6, 4, 7 }, // Front face.
        { 3, 7, 2, 6 }, // Top face.
        { 1, 5, 0, 4 }, // Bottom face.
        { 4, 7, 0, 3 }, // Left face.
        { 1, 2, 5, 6 }  // Right face.
    };

    public static readonly Vector2Int[] _voxelUvs = new Vector2Int[4] {
        new Vector2Int(0, 0),
        new Vector2Int(0, 1),
        new Vector2Int(1, 0),
        new Vector2Int(1, 1)
    };
}
