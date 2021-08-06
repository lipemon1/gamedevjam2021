using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulSystem.FollowPlayer;
using UnityEngine.AI;
using Movement;

namespace SoulSystem
{
    public class AggresiveRedSoulBehavior : MonoBehaviour
    {
        [SerializeField] float _attackRadius = 10f;
        RedSoulAttackBehavior _attackBehavior;
        NavMeshAgent _navMeshAgent;

        bool _followingPlayer;

        private void Awake()
        {
            _attackBehavior = GetComponent<RedSoulAttackBehavior>();
            _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

            _followingPlayer = false;
            _navMeshAgent.enabled = false;
        }

        private void FixedUpdate()
        {
            StartFollowPlayer();
        }

        void StartFollowPlayer()
        {
            if (_followingPlayer) return;

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRadius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Player"))
                {
                    _followingPlayer = true;

                    _navMeshAgent.enabled = true;

                    hitCollider.gameObject.GetComponent<PlayerMovement>().ApplyReduceSpeed();

                    FollowPlayerManager.Instance.OnFollowPlayer(hitCollider.gameObject.transform);
                }
            }
        }
    }
}
