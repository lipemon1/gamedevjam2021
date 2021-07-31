using UnityEngine;

namespace SoulSystem
{
    [RequireComponent(typeof(SoulIdentifierBehavior))]
    public abstract class CollectableSoulBehavior : MonoBehaviour
    {
        protected SoulType _soulType;
        Collider _trigger;

        void Awake()
        {
            _soulType = this.gameObject.GetComponent<SoulIdentifierBehavior>().SoulType;
            
            if(_soulType == SoulType.UNSET)
                Debug.LogError("THIS SOULS IS UNSET");

            _trigger = GetComponent<Collider>();
            _trigger.enabled = true;
        }

        protected bool CollidedWithPlayer(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _trigger.enabled = false;
                return true;
            }
            else
                return false;
        }

        protected abstract void OnSoulCollected(Collider other);

        protected virtual void OnSoulCollectedEnd()
        {
            Destroy(this.gameObject);   
        }
    }   
}