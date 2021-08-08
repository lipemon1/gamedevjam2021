using System;
using System.Collections.Generic;
using Level;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Amulet : MonoBehaviour
{
    [SerializeField] int _numberOfLevels;
    [SerializeField] Image _amulet;
    [SerializeField] List<Sprite> amuletList;
    static int _levelDone;

    void Awake()
    {
        _levelDone = PlayerPrefs.GetInt("LevelDone", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.Instance.OnLevelChange += OnLevelChange;

        UpdateAmulet();
    }

    void OnLevelChange(string curlevel)
    {
        _levelDone++;

        PlayerPrefs.SetInt("LevelDone", _levelDone);

        UpdateAmulet();
    }

    void UpdateAmulet()
    {
        int levelDone = PlayerPrefs.GetInt("LevelDone", 0);

        if (levelDone > 8)
            levelDone = 0;

        _amulet.sprite = amuletList[levelDone];
    }
}
