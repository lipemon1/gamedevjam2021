using System.Collections;
using System.Collections.Generic;
using Level;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public string _levelName;

    private void Load()
    {
        SceneManager.LoadScene(_levelName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.ChangeLevel(_levelName);
            Load();
        }
    }
}
