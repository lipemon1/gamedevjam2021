using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToCameraBehavior : MonoBehaviour
{
    Camera _camera;
    [SerializeField] float _YOffset;
    void Awake()
    {
        _camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.LookAt(_camera.transform);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.y + _YOffset, transform.rotation.z);
    }
}
