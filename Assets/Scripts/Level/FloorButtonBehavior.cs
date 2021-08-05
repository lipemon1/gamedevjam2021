using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButtonBehavior : MonoBehaviour
{
    [SerializeField] GameObject _column;

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        _column.SetActive(true);
    }
}
