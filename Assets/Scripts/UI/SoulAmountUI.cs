using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulAmountUI : MonoBehaviour
{
    [SerializeField] Text SoulTextAmount;
    [SerializeField] string SoulPrefix;
    
    void Start()
    {
        SoulsCollectorManager.Instance.OnSoulCollected += UpdateSoulsUI;
    }

    void UpdateSoulsUI(int newAmount)
    {
        SoulTextAmount.text = SoulPrefix + $"{newAmount}";
    }
}