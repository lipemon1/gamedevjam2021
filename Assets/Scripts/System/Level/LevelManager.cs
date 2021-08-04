using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; set; }

        static string _curLevel;
        [SerializeField] string _curLevelEditor;

        public delegate void OnLevelChangeDelegate(string curLevel);
        public OnLevelChangeDelegate OnLevelChange;

        public delegate void OnLevelResetDelegate(string curLevel);
        public OnLevelResetDelegate OnLevelReseted;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        public void ChangeLevel(string newLevel)
        {
            _curLevel = newLevel;
            _curLevelEditor = _curLevel;
            
            OnLevelChange?.Invoke(_curLevel);
        }

        public void ResetCurrentLevel()
        {
            OnLevelReseted?.Invoke(_curLevel);
        }
    }
}
