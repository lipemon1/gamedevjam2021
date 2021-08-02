using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulSystem
{
    public class RedSoulCollectableBehavior : CollectableSoulBehavior
    {
        [SerializeField] RedSoulAttackBehavior _redSoulAttackBehavior;

        void OnTriggerEnter(Collider other)
        {
            OnSoulCollected(other);
        }

        void OnTriggerExit(Collider other)
        {
            if (!CollidedWithPlayer(other)) return;

            _redSoulAttackBehavior.StopAttack();
        }

        protected override void OnSoulCollected(Collider other)
        {
            if (!CollidedWithPlayer(other)) return;
            
            OnRedSoulCollected();
        }

        void OnRedSoulCollected()
        {
            _redSoulAttackBehavior.StartAttack();
        }
    }   
}
