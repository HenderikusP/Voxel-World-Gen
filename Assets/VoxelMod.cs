using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VoxelMod
{
    public Vector3Int _pos;
    public int _id;

    public VoxelMod(Vector3Int pos, int id)
    {
        _pos = pos;
        _id = id;
    }
}
