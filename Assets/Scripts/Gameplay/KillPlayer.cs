using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDeath.PlayerDeathManager.Instance.PlayerDeath();
        }
    }
}
