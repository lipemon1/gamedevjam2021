using System;
using System.Collections;
using System.Collections.Generic;
using SoulSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SoulSystem
{
    public class PurpleSoulsCollectableBehavior : CollectableSoulBehavior
    {
        [SerializeField] BlueSoulCollectableBehavior _blueSoul;
        [SerializeField] RedSoulCollectableBehavior _redSoul;

        [Space] [SerializeField] float _delayToTransform;
        WaitForSeconds _transformWait;

        void Start()
        {
            _transformWait = new WaitForSeconds(_delayToTransform);
        }

        void OnTriggerEnter(Collider other)
        {
            OnSoulCollected(other);
        }

        protected override void OnSoulCollected(Collider other)
        {
            if (!CollidedWithPlayerAndDisable(other)) return;

            OnPurpleSoulCollected();
        }

        void OnPurpleSoulCollected()
        {
            SoulType soulToBecame = GetRandomType();

            switch (soulToBecame)
            {
                case SoulType.BLUE:
                    StartCoroutine(PurpleSoulCollectedCo(_transformWait, _blueSoul));
                    break;
                case SoulType.RED:
                    StartCoroutine(PurpleSoulCollectedCo(_transformWait, _redSoul));
                    break;
                default:
                    Debug.LogError("This type is not supported here");
                    throw new ArgumentOutOfRangeException();
            }
        }

        IEnumerator PurpleSoulCollectedCo(WaitForSeconds waitForTransform, CollectableSoulBehavior soulToActive)
        {
            yield return waitForTransform;
            soulToActive.gameObject.SetActive(true);
            base.OnSoulCollectedEnd();
        }
    
        SoulType GetRandomType()
        {
            return Random.Range(0f, 1f) > 0.5f ? SoulType.RED : SoulType.BLUE;
        }
    }   
}
