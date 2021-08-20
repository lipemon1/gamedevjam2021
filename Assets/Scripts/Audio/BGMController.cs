using System;
using FMODUnity;
using Level;
using SoulSystem.FollowPlayer;
using UnityEngine;
using WorldChange;

namespace Audio
{
    public class BGMController : MonoBehaviour
    {
        public static BGMController Instance { get; set; }
        
        [SerializeField] string _normal;
        [SerializeField] string _deadWorld;
        [SerializeField] string _humanWorld;
        [SerializeField] string _chasing;
        [SerializeField] string _level8;
        [SerializeField] StudioEventEmitter _emitter;
        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
            
            DontDestroyOnLoad(this.gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            _emitter.SetParameter(_deadWorld, 1f);
            _emitter.Play();
            
            WorldChangeManager.Instance.OnNewWorld += OnNewWorld;
            LevelManager.Instance.OnLevelChange += OnLevelChange;
            FollowPlayerManager.Instance.OnFollowPlayer += OnFollowPlayer;
            FollowPlayerManager.Instance.OnStopFollowPlayer += OnStopFollowPlayer;
        }

        public void Reset()
        {
            _emitter.SetParameter(_level8, 0f);
            _emitter.SetParameter(_chasing, 0f);
            _emitter.SetParameter(_humanWorld, 0f);
        }

        void OnStopFollowPlayer(Transform player)
        {
            _emitter.SetParameter(_deadWorld, 1f);
            _emitter.SetParameter(_chasing, 0f);
        }

        void OnFollowPlayer(Transform player)
        {
            _emitter.SetParameter(_deadWorld, 0f);
            _emitter.SetParameter(_chasing, 1f);
        }

        void OnLevelChange(string curlevel)
        {
            if (curlevel == "Level 2")
            {
                _emitter.SetParameter(_normal, 1f);
            }
            
            if (curlevel == "Level 8")
            {
                _emitter.SetParameter(_level8, 1f);
            }
        }

        void OnNewWorld(World newworld)
        {
            switch (newworld)
            {
                case World.HumanWorld:
                    _emitter.SetParameter(_deadWorld, 0f);
                    _emitter.SetParameter(_humanWorld, 1f);
                    break;
                case World.SoulWorld:
                    _emitter.SetParameter(_deadWorld, 1f);
                    _emitter.SetParameter(_humanWorld, 0f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newworld), newworld, null);
            }
            // throw new System.NotImplementedException();
        }
    }
}