using System;
using Level;
using UnityEngine;

namespace SoulSystem
{
    [RequireComponent(typeof(SoulIdentifierBehavior))]
    public abstract class CollectableSoulBehavior : MonoBehaviour
    {
        protected SoulType _soulType;
        Collider _trigger;

        Vector3 _initialPos;
        Quaternion _initialRot;

        void Awake()
        {
            SaveInitialState();
            
            _soulType = this.gameObject.GetComponent<SoulIdentifierBehavior>().SoulType;
            
            if(_soulType == SoulType.UNSET)
                Debug.LogError("THIS SOULS IS UNSET");

            _trigger = GetComponent<Collider>();
            _trigger.enabled = true;
        }

        protected virtual void Start()
        {
            LevelManager.Instance.OnLevelReseted += (curLevel) => ResetState();
        }

        void SaveInitialState()
        {
            _initialPos = transform.position;
            _initialRot = transform.rotation;
        }

        public void ResetState()
        {
            transform.position = _initialPos;
            transform.rotation = _initialRot;
            transform.gameObject.SetActive(true);
        }

        public void KillSoul()
        {
            transform.gameObject.SetActive(false);
            transform.position = new Vector3(-5000f, -5000, -5000);
        }

        protected bool CollidedWithPlayerAndDisable(Collider other)
        {
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

        protected virtual void OnSoulCollectedEnd()
        {
            KillSoul();
        }
    }   
}