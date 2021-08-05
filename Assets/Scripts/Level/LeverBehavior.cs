using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehavior : MonoBehaviour
{
    [SerializeField] GameObject _wall;
    [SerializeField] bool _active;

    // Start is called before the first frame update
    void Start()
    {
        _active = _wall.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        _wall.SetActive(!_wall.activeSelf);
        _active = _wall.activeSelf;
    }
}
