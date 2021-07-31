using System;
using UnityEngine;

namespace SoulSystem
{
    public class BlueSoulCollectableBehavior : CollectableSoulBehavior
    {
        void OnTriggerEnter(Collider other)
        {
            OnSoulCollected(other);
        }

        protected override void OnSoulCollected(Collider other)
        {
            if (!CollidedWithPlayer(other)) return;
            
            OnBlueSoulCollected();
            
            base.OnSoulCollectedEnd();
        }

        void OnBlueSoulCollected()
        {
            SoulsCollectorManager.Instance.CollectSouls(1);
        }
    }
}