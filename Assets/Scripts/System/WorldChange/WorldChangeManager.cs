using System;
using System.Collections;
using Level;
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
        [SerializeField] int _secondsMultiplier;
        [SerializeField] World _curWorld;

        public delegate void WorldChangeDelegate();
        public WorldChangeDelegate OnEnableWorldChange;

        public delegate void NewWorldDelegate(World newWorld);
        public NewWorldDelegate OnNewWorld;
        
        public delegate void HumanWorldWithTimeDelegate(World newWorld, float worldTime);
        public HumanWorldWithTimeDelegate OnHumanWorldWithTime;

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
            if (currentSouls >= _soulNeededToWorldChange)
                OnEnableWorldChange?.Invoke();
        }

        public void ChangeToHumanWorld(int soulsAmount)
        {
            if (_curWorld == World.HumanWorld) return;

            int smallsBalls = soulsAmount / _soulNeededToWorldChange;
            OnSoulsSpent?.Invoke(smallsBalls * _soulNeededToWorldChange);

            int seconds = smallsBalls * _secondsMultiplier;
            _curWorld = World.HumanWorld;
            Debug.Log($"ChangeWorld for {seconds} seconds");
            OnNewWorld?.Invoke(_curWorld);
            StartCoroutine(ReturnToSoulWorldCo(seconds));
            OnHumanWorldWithTime?.Invoke(_curWorld, seconds);
        }

        void ChangeToSoulWorld()
        {
            LevelManager.Instance.ResetCurrentLevel();
            Debug.Log("Back to Soul World");
            if (_curWorld == World.SoulWorld) return;

            _curWorld = World.SoulWorld;
            OnNewWorld?.Invoke(_curWorld);
        }

        IEnumerator ReturnToSoulWorldCo(float delay)
        {
            yield return new WaitForSeconds(delay);
            ChangeToSoulWorld();
        }

        public int GetSoulsNeededToWorldChange()
        {
            return _soulNeededToWorldChange;
        }

        public World GetCurWorld(){
            return _curWorld;
        }
    }
}
