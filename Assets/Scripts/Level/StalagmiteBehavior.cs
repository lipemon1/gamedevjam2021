using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagmiteBehavior : MonoBehaviour
{

    [SerializeField] GameObject _stalagmite;

    private void Awake()
    {
        _stalagmite.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ActiveStalagmite();
        }
    }

    private void ActiveStalagmite()
    {
        _stalagmite.SetActive(true);
    }
}
