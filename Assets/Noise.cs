using UnityEngine;

public static class Noise
{
    public static float Perlin2D(Vector3Int pos, float offset, float scale, float amp = 1, float pow = 1) {
        return amp * Mathf.Pow(Mathf.PerlinNoise((pos.x + 0.1f ) / WorldData._chunkWidth * (1 / scale) + offset, (pos.z + 0.1f) / WorldData._chunkWidth * (1 / scale) + offset), pow);
    }
}
