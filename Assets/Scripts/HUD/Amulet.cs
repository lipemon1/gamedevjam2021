using System;
using Level;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Amulet : MonoBehaviour
{
    [SerializeField] int _numberOfLevels;
    [SerializeField] Image _amulet;
    static int _levelDone;

    void Awake()
    {
        _levelDone = PlayerPrefs.GetInt("LevelDone");
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.Instance.OnLevelChange += OnLevelChange;
    }

    void OnLevelChange(string curlevel)
    {
        _levelDone++;
        
        PlayerPrefs.SetInt("LevelDone", _levelDone);
        
        UpdateAmulet(_numberOfLevels);
    }

    void UpdateAmulet(int maxAmount)
    {
        _amulet.fillAmount = PlayerPrefs.GetInt("LevelDone") / maxAmount;
    }
}
