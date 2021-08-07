using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagmiteBehavior : MonoBehaviour
{

    [SerializeField] GameObject _stalagmite;
    MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        _stalagmite.SetActive(false);
        _meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ActiveStalagmite();
            Destroy(gameObject);
        }
    }

    private void ActiveStalagmite()
    {
        _stalagmite.SetActive(true);
    }
}
