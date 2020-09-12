using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLight : MonoBehaviour
{
    private Light _light;

    void Start()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (_light.enabled) _light.enabled = false;
            else _light.enabled = true;
        }
    }
}
