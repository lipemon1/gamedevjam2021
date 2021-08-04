using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldChange;

public class ActiveLoadLevel : MonoBehaviour
{
    [SerializeField] float _afterSeconds;
    [SerializeField] GameObject _loadLevel;
    [SerializeField] GameObject _closeLoadLevel;

    bool startTime = false;
    float time;
    World startWorld;

    private void Start()
    {
        startWorld = WorldChangeManager.Instance.GetCurWorld();
    }

    private void Update()
    {
        if (World.HumanWorld == WorldChangeManager.Instance.GetCurWorld())
        {
            startTime = true;
        }

        if (startTime)
        {
            time += Time.deltaTime;

            if (time >= _afterSeconds)
            {
                _closeLoadLevel.SetActive(false);
                _loadLevel.SetActive(true);
            }
        }
    }
}
