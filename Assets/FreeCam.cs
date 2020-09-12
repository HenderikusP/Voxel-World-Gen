using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public float _flySpeed = 0.1f;
    public float _boostFlySpeed = 0.4f;

    private float _rotationX;
    private float _rotationY;
    private float _rotationXSmooth;
    private float _rotationYSmooth;
    Vector3 _movement;
    private Transform _camera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _camera = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        Look();
        Move();
        _camera.position += _movement;
    }

    private void Move() {
        _movement = Vector3.Lerp(_movement, ((Input.GetAxisRaw("Vertical") * _camera.forward.normalized) + (Input.GetAxisRaw("Horizontal") * _camera.right.normalized)).normalized * _flySpeed, Time.deltaTime * 15);
        if (Input.GetKey(KeyCode.LeftShift)) _movement = Vector3.Lerp(_movement, ((Input.GetAxisRaw("Vertical") * _camera.forward.normalized) + (Input.GetAxisRaw("Horizontal") * _camera.right.normalized)).normalized * _boostFlySpeed, Time.deltaTime * 15);
    }

    private void Look()
    {
        bool _smoothLook = true;
        float _mouseSenscitvity = 1.5f;
        float _smoothSpeed = 50.0f;

        {
            _rotationX += Input.GetAxis("Mouse X") * _mouseSenscitvity;
            _rotationY += Input.GetAxis("Mouse Y") * _mouseSenscitvity;
        }

        _rotationY = Mathf.Clamp(_rotationY, -90f, 90f);

        _rotationXSmooth = Mathf.Lerp(_rotationXSmooth, _rotationX, Time.deltaTime * _smoothSpeed);
        _rotationYSmooth = Mathf.Lerp(_rotationYSmooth, _rotationY, Time.deltaTime * _smoothSpeed);

        if (_smoothLook) _camera.localRotation = Quaternion.Euler(-_rotationYSmooth, _rotationXSmooth, 0);
        else _camera.localRotation = Quaternion.Euler(-_rotationY, _rotationX, 0);
    }
}
