using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagmiteMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(0, -1, 0);

        _rigidbody.MovePosition(transform.position + direction * Time.deltaTime * _speed);
    }
}
