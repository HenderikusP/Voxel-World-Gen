using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Structures
{
    public static int[,,] tree = new int[9, 7, 7]
    {
        {
            {  0,  0,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0,  0,  0 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  0,  0,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0,  0,  0 }
        },
        {
            {  0,  0,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0,  0,  0 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  0,  0,  0,  0,  0,  0,  0 },
            {  0,  0,  0,  0,  0,  0,  0 }
        },
        {
            {  0,  0,  0,  0,  0,  0,  0 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  0,  0,  0,  0,  0,  0,  0 }
        },
        {
            {  0,  0,  0,  0,  0,  0,  0 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5,  5,  5,  5,  5,  5,  5 },
            {  0,  0,  0,  0,  0,  0,  0 }
        },
        {
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5,  5,  5,  5,  5,  5,  5 }
        },
        {
            {  5,  5, -1,  5, -1,  5,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5,  5, -1,  5, -1,  5,  5 }
        },
        {
            {  5,  5, -1,  5, -1,  5,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            { -1, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5,  5, -1,  5, -1,  5,  5 }
        },
        {
            {  5,  5,  5,  5,  5,  5,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            { -1, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5, -1, -1, -1, -1, -1,  5 },
            {  5,  5,  5,  5,  5,  5,  5 }
        },
        {
            { 5, 5, 5, 5, 5, 5, 5 },
            { 5, 3, 3, 3, 3, 3, 5 },
            { 5, 3, 3, 3, 3, 3, 5 },
            { 5, 3, 3, 3, 3, 3, 5 },
            { 5, 3, 3, 3, 3, 3, 5 },
            { 5, 3, 3, 3, 3, 3, 5 },
            { 5, 5, 5, 5, 5, 5, 5 }
        },
    };

    public static int[,,] TESTtreeints = new int[30, 5, 5] {
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
            { 5, 5, 5, 5, 5 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 4, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        },
    };

    public static void LoadStructures() {
        _TEST = ConvertToStructure(tree, new Vector3Int(-2, 0, -2));
    }

    private static VoxelMod[] ConvertToStructure(int[,,] structure, Vector3Int offset) {
        List<VoxelMod> voxelMods = new List<VoxelMod>();

        for (int x = 0; x < structure.GetLength(2); x++)
        {
            for (int y = 0; y < structure.GetLength(0); y++)
            {
                for (int z = 0; z < structure.GetLength(1); z++)
                {
                    if (structure[y, z, x] != 0)
                    {
                        int block = structure[y, z, x];
                        if (block == -1) block = 0;
                        voxelMods.Add(new VoxelMod(new Vector3Int(x + offset.x, structure.GetLength(0) - 1 - y + offset.y, structure.GetLength(1) - 1 - z + offset.z), block));
                    }
                }
            }
        }

        return voxelMods.ToArray();
    }

    public static VoxelMod[] _TEST;

    public static readonly VoxelMod[] _tree = new VoxelMod[] {
        new VoxelMod(new Vector3Int(0, 1, 0), 4),
        new VoxelMod(new Vector3Int(0, 2, 0), 4),
        new VoxelMod(new Vector3Int(0, 3, 0), 4),
        new VoxelMod(new Vector3Int(0, 4, 0), 4),
        new VoxelMod(new Vector3Int(0, 5, 0), 4),
        new VoxelMod(new Vector3Int(0, 6, 0), 4),
        new VoxelMod(new Vector3Int(0, 7, 0), 4),
        new VoxelMod(new Vector3Int(0, 8, 0), 4),
        new VoxelMod(new Vector3Int(0, 9, 0), 4),
        new VoxelMod(new Vector3Int(0, 10, 0), 4),
        new VoxelMod(new Vector3Int(0, 11, 0), 4),

        new VoxelMod(new Vector3Int(0, 12, 0), 4),
        new VoxelMod(new Vector3Int(1, 12, 0), 5),

        new VoxelMod(new Vector3Int(0, 13, 0), 4),
        new VoxelMod(new Vector3Int(1, 13, 0), 5),
        new VoxelMod(new Vector3Int(2, 13, 0), 5),
        new VoxelMod(new Vector3Int(3, 13, 0), 5),
        new VoxelMod(new Vector3Int(1, 13, 1), 5),
        new VoxelMod(new Vector3Int(2, 13, 1), 5),
        new VoxelMod(new Vector3Int(3, 13, 1), 5),
        new VoxelMod(new Vector3Int(1, 13, 2), 5),
        new VoxelMod(new Vector3Int(2, 13, 2), 5),
        new VoxelMod(new Vector3Int(1, 13, -1), 5),
        new VoxelMod(new Vector3Int(1, 13, -2), 5),
        new VoxelMod(new Vector3Int(2, 13, -2), 5),
        new VoxelMod(new Vector3Int(0, 13, -2), 5),
        new VoxelMod(new Vector3Int(0, 13, -3), 5),
        new VoxelMod(new Vector3Int(-1, 13, -1), 5),
        new VoxelMod(new Vector3Int(-2, 13, 0), 5),
        new VoxelMod(new Vector3Int(-3, 13, 0), 5),
        new VoxelMod(new Vector3Int(-2, 13, 1), 5),
        new VoxelMod(new Vector3Int(-2, 13, 2), 5),
        new VoxelMod(new Vector3Int(-1, 13, 1), 5),
        new VoxelMod(new Vector3Int(0, 13, 1), 5),
        new VoxelMod(new Vector3Int(0, 13, 2), 5),
        new VoxelMod(new Vector3Int(0, 13, 3), 5),

        new VoxelMod(new Vector3Int(0, 14, 0), 4),
        new VoxelMod(new Vector3Int(1, 14, 1), 5),
        new VoxelMod(new Vector3Int(-1, 14, 0), 5),
        new VoxelMod(new Vector3Int(1, 14, -1), 5),
        new VoxelMod(new Vector3Int(0, 14, -1), 5),
        new VoxelMod(new Vector3Int(-1, 14, -1), 5),
        new VoxelMod(new Vector3Int(-2, 14, -1), 5),
        new VoxelMod(new Vector3Int(-3, 14, -1), 5),
        new VoxelMod(new Vector3Int(0, 14, -2), 5),
        new VoxelMod(new Vector3Int(-1, 14, -2), 5),
        new VoxelMod(new Vector3Int(-2, 14, -2), 5),
        new VoxelMod(new Vector3Int(-2, 14, -3), 5),

        new VoxelMod(new Vector3Int(0, 15, 0), 4),
        new VoxelMod(new Vector3Int(0, 15, -1), 5),
        new VoxelMod(new Vector3Int(0, 15, 1), 5),
        new VoxelMod(new Vector3Int(0, 15, 2), 5),
        new VoxelMod(new Vector3Int(0, 15, 3), 5),
        new VoxelMod(new Vector3Int(-1, 15, 2), 5),

        new VoxelMod(new Vector3Int(0, 16, 0), 4),
        new VoxelMod(new Vector3Int(1, 16, 2), 5),
        new VoxelMod(new Vector3Int(1, 16, 1), 5),
        new VoxelMod(new Vector3Int(1, 16, 0), 5),
        new VoxelMod(new Vector3Int(1, 16, -1), 5),
        new VoxelMod(new Vector3Int(2, 16, 1), 5),
        new VoxelMod(new Vector3Int(2, 16, 0), 5),
        new VoxelMod(new Vector3Int(2, 16, -1), 5),

        new VoxelMod(new Vector3Int(0, 17, 0), 4),
        new VoxelMod(new Vector3Int(1, 17, 0), 5),
        new VoxelMod(new Vector3Int(-1, 17, 0), 5),
        new VoxelMod(new Vector3Int(1, 17, -2), 5),
        new VoxelMod(new Vector3Int(-1, 17, -2), 5),
        new VoxelMod(new Vector3Int(0, 17, -1), 5),
        new VoxelMod(new Vector3Int(0, 17, -2), 5),
        new VoxelMod(new Vector3Int(0, 17, -3), 5),

        new VoxelMod(new Vector3Int(0, 18, 0), 4),
        new VoxelMod(new Vector3Int(0, 18, 2), 5),
        new VoxelMod(new Vector3Int(0, 18, 3), 5),
        new VoxelMod(new Vector3Int(-1, 18, 2), 5),
        new VoxelMod(new Vector3Int(-1, 18, 1), 5),
        new VoxelMod(new Vector3Int(-2, 18, 1), 5),
        new VoxelMod(new Vector3Int(-2, 18, 0), 5),
        new VoxelMod(new Vector3Int(-2, 18, -1), 5),
        new VoxelMod(new Vector3Int(-1, 18, -1), 5),

        new VoxelMod(new Vector3Int(0, 19, 0), 4),
        new VoxelMod(new Vector3Int(1, 19, 0), 5),
        new VoxelMod(new Vector3Int(2, 19, 0), 5),
        new VoxelMod(new Vector3Int(1, 19, 1), 5),
        new VoxelMod(new Vector3Int(2, 19, 1), 5),
        new VoxelMod(new Vector3Int(0, 19, 1), 5),
        new VoxelMod(new Vector3Int(0, 19, 2), 5),
        new VoxelMod(new Vector3Int(1, 19, 2), 5),

        new VoxelMod(new Vector3Int(0, 20, 0), 4),
        new VoxelMod(new Vector3Int(1, 20, 0), 5),
        new VoxelMod(new Vector3Int(0, 20, -1), 5),
        new VoxelMod(new Vector3Int(0, 20, -2), 5),

        new VoxelMod(new Vector3Int(0, 21, 0), 4),
        new VoxelMod(new Vector3Int(0, 21, -1), 5),
        new VoxelMod(new Vector3Int(-1, 21, 0), 5),
        new VoxelMod(new Vector3Int(-2, 21, 0), 5),
        new VoxelMod(new Vector3Int(1, 21, 1), 5),
        new VoxelMod(new Vector3Int(0, 21, 1), 5),
        new VoxelMod(new Vector3Int(-1, 21, 1), 5),
        new VoxelMod(new Vector3Int(0, 21, 2), 5),

        new VoxelMod(new Vector3Int(0, 21, 0), 4),
        new VoxelMod(new Vector3Int(1, 21, 0), 5),

        new VoxelMod(new Vector3Int(0, 22, 0), 4),
        new VoxelMod(new Vector3Int(1, 22, 0), 5),
        new VoxelMod(new Vector3Int(-1, 22, 0), 5),
        new VoxelMod(new Vector3Int(0, 22, -1), 5),

        new VoxelMod(new Vector3Int(0, 23, 0), 4),
        new VoxelMod(new Vector3Int(-1, 23, 0), 5),
        new VoxelMod(new Vector3Int(0, 23, 1), 5),

        new VoxelMod(new Vector3Int(0, 24, 0), 5),
        new VoxelMod(new Vector3Int(0, 25, 0), 5),
        new VoxelMod(new Vector3Int(0, 26, 0), 5),
    };
}
