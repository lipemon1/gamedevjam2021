using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToCameraBehavior : MonoBehaviour
{
    Camera _camera;
    [SerializeField] float _YOffset;

    [SerializeField] Canvas _cameraCanvas;
    void Awake()
    {
        if (_cameraCanvas == null)
            _cameraCanvas = GetComponent<Canvas>();

        _camera = Camera.main;
        _cameraCanvas.worldCamera = _camera;
    }

    void LateUpdate()
    {
        transform.LookAt(_camera.transform);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.y + _YOffset, transform.rotation.z);
    }
}
