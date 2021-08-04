using UnityEngine;

namespace SoulSystem
{
    [RequireComponent(typeof(SoulIdentifierBehavior))]
    public abstract class CollectableSoulBehavior : MonoBehaviour
    {
        [SerializeField] bool _enableCollectable = true;
        protected SoulType _soulType;
        Collider _trigger;

        void Awake()
        {
            _soulType = this.gameObject.GetComponent<SoulIdentifierBehavior>().SoulType;

            if (_soulType == SoulType.UNSET)
                Debug.LogError("THIS SOULS IS UNSET");

            _trigger = GetComponent<Collider>();
            _trigger.enabled = true;
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

        protected virtual void OnSoulCollectedEnd()
        {
            Destroy(this.gameObject);
        }
    }
}