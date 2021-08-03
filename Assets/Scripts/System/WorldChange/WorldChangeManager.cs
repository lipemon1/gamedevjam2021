using System;
using System.Collections;
using UnityEngine;

namespace WorldChange
{
    public enum World
    {
        HumanWorld,
        SoulWorld
    }
    
    public class WorldChangeManager : MonoBehaviour
    {
        public static WorldChangeManager Instance { get; set; }

        [SerializeField] int _soulNeededToWorldChange;
        [SerializeField] World _curWorld;
        
        public delegate void WorldChangeDelegate();
        public WorldChangeDelegate OnEnableWorldChange;

        public delegate void NewWorldDelegate(World newWorld);
        public NewWorldDelegate OnNewWorld;

        public delegate void SoulSpentOnChangeWorldDelegate(int amount);
        public SoulSpentOnChangeWorldDelegate OnSoulsSpent;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }
        
        void Start()
        {
            SoulsCollectorManager.Instance.OnSoulCollected += (currentSouls) => EnableWorldChange(currentSouls);
        }

        void EnableWorldChange(int currentSouls)
        {
            if(currentSouls >= _soulNeededToWorldChange)
                OnEnableWorldChange?.Invoke();
        }

        public void ChangeToSoulWorld(int soulsAmount)
        {
            if (_curWorld == World.SoulWorld) return;

            int seconds = soulsAmount / _soulNeededToWorldChange;
            int soulsSpent = seconds * _soulNeededToWorldChange;
            OnSoulsSpent?.Invoke(soulsSpent);

            _curWorld = World.SoulWorld;
            Debug.Log($"ChangeWorld for {seconds} seconds");
            OnNewWorld?.Invoke(_curWorld);
            StartCoroutine(ReturnToHumanWorldCo(seconds));
        }

        void ChangeToHumanWorld()
        {
            Debug.Log("Back to Human World");
            if (_curWorld == World.HumanWorld) return;
            
            _curWorld = World.HumanWorld;
            OnNewWorld?.Invoke(_curWorld);
        }

        IEnumerator ReturnToHumanWorldCo(float delay)
        {
            yield return new WaitForSeconds(delay);
            ChangeToHumanWorld();
        }

        public int GetSoulsToWorldChange()
        {
            return _soulNeededToWorldChange;
        }
    }   
}
