using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldChange
{
    public class WorldChangeInput : MonoBehaviour
    {
        [SerializeField] KeyCode _changeWorldInput;
        [SerializeField] GameObject _soulWorld;
        [SerializeField] GameObject _humanWorld;
        bool canChangeWorld = false;
        int curSouls;

        // Start is called before the first frame update
        void Start()
        {
            SoulsCollectorManager.Instance.OnSoulCollected += OnSoulAmountChanged;
            WorldChangeManager.Instance.OnEnableWorldChange += () => SetCanChangeWorld(true);
            WorldChangeManager.Instance.OnNewWorld += OnNewWorld;
        }

        private void OnNewWorld(World newWorld)
        {
            switch (newWorld)
            {
                case World.HumanWorld:
                    _soulWorld?.SetActive(false);
                    _humanWorld?.SetActive(true);
                    break;
                case World.SoulWorld:
                    _humanWorld?.SetActive(false);
                    _soulWorld?.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newWorld), newWorld, null);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!canChangeWorld) return;

            if (Input.GetKeyUp(_changeWorldInput))
            {
                canChangeWorld = false;
                WorldChangeManager.Instance.ChangeToHumanWorld(curSouls);
            }
        }

        void SetCanChangeWorld(bool value)
        {
            canChangeWorld = value;
        }

        void OnSoulAmountChanged(int newAmount)
        {
            curSouls = newAmount;
        }
    }
}