using System;
using Level;
using UnityEngine;
using WorldChange;

namespace SoulSystem
{
    [RequireComponent(typeof(SoulIdentifierBehavior))]
    public abstract class CollectableSoulBehavior : MonoBehaviour
    {
        [SerializeField] bool _enableCollectable = true;
        protected SoulType _soulType;
        Collider _trigger;

        Vector3 _initialPos;
        Quaternion _initialRot;

        bool isOwnedByPurple = false;

        void Awake()
        {
            SaveInitialState();
            
            _soulType = this.gameObject.GetComponent<SoulIdentifierBehavior>().SoulType;

            if (_soulType == SoulType.UNSET)
                Debug.LogError("THIS SOULS IS UNSET");

            _trigger = GetComponent<Collider>();
            _trigger.enabled = true;
        }

        protected virtual void Start()
        {
            PurifySoulsManager.Instance.RegisterSouls(this);
            LevelManager.Instance.OnLevelReseted += (curLevel) => ResetState();
            WorldChangeManager.Instance.OnNewWorld += OnNewWorld;
        }

        void OnNewWorld(World newworld)
        {
            if(newworld == World.HumanWorld)
                KillSoul();
        }

        void SaveInitialState()
        {
            _initialPos = transform.position;
            _initialRot = transform.rotation;
        }

        public virtual void ResetState()
        {
            transform.position = _initialPos;
            transform.rotation = _initialRot;
            _trigger.enabled = true;
            
            if(!isOwnedByPurple)
                transform.gameObject.SetActive(true);
        }

        public virtual void KillSoul()
        {
            transform.gameObject.SetActive(false);
            transform.position = new Vector3(-5000f, -5000, -5000);
        }

        protected bool CollidedWithPlayerAndDisable(Collider other)
        {
            if (!_enableCollectable) return false;

            if (CollidedWithPlayer(other))
            {
                _trigger.enabled = false;
                return true;
            }
            else
                return false;
        }

        protected bool CollidedWithPlayer(Collider other)
        {
            return other.CompareTag("Player");
        }

        protected abstract void OnSoulCollected(Collider other);

        protected void OnSoulCollectedEnd()
        {
            KillSoul();
        }

        public void SetPurpleAsOwner()
        {
            isOwnedByPurple = true;
        }

        public SoulType SoulType => _soulType;
    }
}