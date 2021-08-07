using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] Transform _playerTrasnform;
    [SerializeField] Vector3 _cameraOffset;

    [Range(0.1f, 1f)]
    [SerializeField] float _smoothFactor;

    // Start is called before the first frame update
    void Start()
    {
        _playerTrasnform = GameObject.FindGameObjectWithTag("Player").transform;
        //_cameraOffset = transform.position - _playerTrasnform.position;
    }

    void LateUpdate()
    {
        Vector3 newPos = _playerTrasnform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, _smoothFactor);
    }
}
