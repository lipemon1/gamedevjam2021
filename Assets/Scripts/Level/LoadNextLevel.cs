using System.Collections;
using System.Collections.Generic;
using Level;
using SoulSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public string _levelName;
    public float _timeToLoad;
    public bool _loadNextLevel;

    private void Load()
    {
        SceneManager.LoadScene(_levelName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.ChangeLevel(_levelName);
            
            if(_loadNextLevel)
                StartCoroutine(LoadNextLevelCo());
        }
    }

    IEnumerator LoadNextLevelCo()
    {
        yield return new WaitForSeconds(_timeToLoad);
        Load();
    }
}
