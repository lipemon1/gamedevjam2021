using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulSystem
{
    public class RedSoulCollectableBehavior : CollectableSoulBehavior
    {
        void OnTriggerEnter(Collider other)
        {
            OnSoulCollected(other);
        }

        protected override void OnSoulCollected(Collider other)
        {
            if (!CollidedWithPlayer(other)) return;
            
            OnRedSoulCollected();
            
            base.OnSoulCollectedEnd();
        }

        void OnRedSoulCollected()
        {
            Debug.Log("RED SOUL COLLECTED");
        }
    }   
}
