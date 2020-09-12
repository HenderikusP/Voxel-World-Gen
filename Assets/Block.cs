using UnityEngine;

[System.Serializable]
public class Block
{
    public readonly string _name;
    public readonly bool _isSolid;
    [Tooltip("Back, Front, Top, Bottom, Left, Right.")] public readonly int[] _faceTextures = new int[6];

    public Block(string name, bool isSolid, int[] faceTextures) {
        _name = name;
        _isSolid = isSolid;
        _faceTextures = faceTextures;
    }
}
