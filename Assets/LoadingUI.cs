using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, 1)]
    public float _progress = 0;
    private float _value;
    private int _randomizePasses = 4;
    private int _res = 16;
    private CanvasGroup[,] _blocks;
    private RectTransform _rectTransform;

    private void Start()
    {
        _blocks = new CanvasGroup[_res, _res];
        _rectTransform = GetComponent<RectTransform>();
        GridLayoutGroup grid;
        if (GetComponent<GridLayoutGroup>()) grid = GetComponent<GridLayoutGroup>();
        else grid = gameObject.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2((float)_rectTransform.rect.width / _res, (float)_rectTransform.rect.height / _res);

        for (int x = 0; x < _res; x++)
        {
            for (int y = 0; y < _res; y++)
            {
                GameObject block = new GameObject("block " + ((x * _res) + y));
                block.transform.SetParent(transform);
                block.AddComponent<Image>().color = new Color32(255, 255, 255, (byte)Random.Range(100, 150));
                _blocks[x, y] = block.AddComponent<CanvasGroup>();
            }
        }

        for (int i = 0; i < _randomizePasses; i++)
        {
            for (int x = 0; x < transform.childCount; x++)
            {
                int rand;
                do rand = Random.Range(0, transform.childCount);
                while (Random.Range(0, transform.childCount) == x);
                transform.GetChild(x).SetSiblingIndex(rand);
            }
        }

        _value = 1 / (float)_blocks.Length;
    }

    private void Update()
    {
        _progress = Mathf.Clamp(_progress, 0, 1);

        for (int x = 0; x < _res; x++)
        {
            for (int y = 0; y < _res; y++)
            {
                _blocks[x, y].alpha = _progress - (((x * _res) + y) * _value);
                _blocks[x, y].alpha /= _value;
            }
        }
    }
}
