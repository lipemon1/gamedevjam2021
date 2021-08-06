using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    LoadNextLevel _loadNextLevel;

    private void Start()
    {
        _loadNextLevel = GetComponent<LoadNextLevel>();
        StartCoroutine(_loadNextLevel.LoadNextLevelCo());
    }
}
