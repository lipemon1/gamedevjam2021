using System;
using System.Collections.Generic;
using Level;
using UnityEngine;

namespace SoulSystem
{
    public class PurifySoulsManager : MonoBehaviour
    {
        public static PurifySoulsManager Instance { get; set; }

        [SerializeField] GameObject _bluePrefab;

        List<CollectableSoulBehavior> _soulsToPurify = new List<CollectableSoulBehavior>();

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        void Start()
        {
            LevelManager.Instance.OnLevelChange += OnLevelChange;
        }

        void OnLevelChange(string curlevel)
        {
            foreach (CollectableSoulBehavior soulBehavior in _soulsToPurify)
            {
                if(soulBehavior.SoulType == SoulType.BLUE)
                    soulBehavior.ResetState();
                else
                {
                    Instantiate(_bluePrefab, soulBehavior.transform.position,
                        Quaternion.identity);
                    soulBehavior.KillSoul();
                }
            }
        }

        public void RegisterSouls(CollectableSoulBehavior soulBehavior)
        {
            _soulsToPurify.Add(soulBehavior);
        }
    }   
}
