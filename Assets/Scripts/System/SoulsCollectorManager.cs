using UnityEngine;

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

    public void CollectSouls(int soulAmount)
    {
        _soulsAmount += soulAmount;
        
        OnSoulCollected?.Invoke(_soulsAmount);
    }
}
