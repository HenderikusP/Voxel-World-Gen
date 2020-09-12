using UnityEngine;

public static class Seed
{
    private static string _seed = "";
    private static readonly string _randomSeedChars = "abcdefghijklmnopqrstuvwxyz0123456789";
    private static readonly int _randomSeedLength = 16;
    private static System.Random _pseudoRandom;
    public static int _pseudoRandomOffset;

    public static void Calculate(string customSeed = "")
    {
        if (customSeed == "")
            for (int i = 0; i < _randomSeedLength; i++)
                _seed += _randomSeedChars[Random.Range(0, _randomSeedChars.Length)];
        else
            _seed = customSeed;

        DebugHelper.Log(string.Format("SEED: {0}", _seed), DebugHelper.successColor);
        _pseudoRandom = new System.Random(_seed.GetHashCode());
        _pseudoRandomOffset = _pseudoRandom.Next(-99999, 99999); // Find better method.
    }
}
