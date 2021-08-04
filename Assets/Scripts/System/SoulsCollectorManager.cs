using System;
using UnityEngine;
using WorldChange;

public class SoulsCollectorManager : MonoBehaviour
{
    public static SoulsCollectorManager Instance { get; set; }

    [SerializeField] int _soulsAmount;
    
    public delegate void OnSoulChanged(int currentSoul);
    public OnSoulChanged OnSoulCollected;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        WorldChangeManager.Instance.OnSoulsSpent += OnSoulSpent;
    }

    public void CollectSouls(int soulAmount)
    {
        _soulsAmount += soulAmount;
        
        OnSoulCollected?.Invoke(_soulsAmount);
    }

    public void OnSoulSpent(int soulSpent)
    {
        Debug.Log($"Spending {soulSpent} souls");
        _soulsAmount -= soulSpent;
        
        OnSoulCollected?.Invoke(_soulsAmount);
    }
}
