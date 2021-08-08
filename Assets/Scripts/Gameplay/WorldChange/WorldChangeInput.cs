using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WorldChange
{
    public class WorldChangeInput : MonoBehaviour
    {
        [SerializeField] GameObject _soulWorld;
        [SerializeField] GameObject _humanWorld;
        public UnityEvent _onSoulWorld;
        public UnityEvent _onHumanWorld;
        
        
        [Space(20)]
        
        [SerializeField] float _worldChangeInput;
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
                    _onHumanWorld?.Invoke();
                    break;
                case World.SoulWorld:
                    _humanWorld?.SetActive(false);
                    _soulWorld?.SetActive(true);
                    _onSoulWorld?.Invoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newWorld), newWorld, null);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!canChangeWorld) return;

            _worldChangeInput = Input.GetAxis("ChangeWorld");

            if (Input.GetButtonDown("ChangeWorld") || _worldChangeInput > 0.1f || _worldChangeInput < -0.1f)
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