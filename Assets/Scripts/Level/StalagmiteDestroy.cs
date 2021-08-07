using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagmiteDestroy : MonoBehaviour
{
    [SerializeField] float _secondsToDestroy = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDeath.PlayerDeathManager.Instance.PlayerDeath();
        }

        Destroy(gameObject, _secondsToDestroy);
    }
}