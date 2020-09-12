using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Voxel
{
    public static Dictionary<Vector3Int, List<VoxelMod>> _voxelMods = new Dictionary<Vector3Int, List<VoxelMod>>();

    public static int Calculate(Vector3Int pos)
    {
        int block = 0; // Air.
        float height;

        height = Noise.Perlin2D(pos, Seed._pseudoRandomOffset, 5, 1, 2);
        height = Mathf.RoundToInt(height * WorldData._worldHeightInVoxels);

        if (pos.y == height) block = 2; // Grass.
        else if (pos.y < height) block = 1; // Dirt.

        if (pos.y == height)
        {
            if (Noise.Perlin2D(pos, Seed._pseudoRandomOffset, 2f) > 0.5f)
            {
                if (Noise.Perlin2D(pos, Seed._pseudoRandomOffset, 0.01f) > 0.85f)
                {
                    block = 1;
                    AddStructure(Structures._tree, pos);
                }
            }
        }

        return block;
    }

    private static void AddStructure(VoxelMod[] structure, Vector3Int pos)
    {
        for (int i = 0; i < structure.Length; i++)
        {
            AddVoxelMod(structure[i], pos);
        }
    }

    private static void AddVoxelMod(VoxelMod voxelMod, Vector3Int offset)
    {
        Vector3Int chunkCoord = WorldData.GlobalPosToChunkCoord(voxelMod._pos + offset);
        Vector3Int pos = (voxelMod._pos + offset) - WorldData.ChunkCoordToGlobalPos(chunkCoord);

        if (_voxelMods.ContainsKey(chunkCoord)) _voxelMods[chunkCoord].Add(new VoxelMod(pos, voxelMod._id)); // Override other voxel.
        else _voxelMods.Add(chunkCoord, new List<VoxelMod>() { new VoxelMod(pos, voxelMod._id) });
    }
}
