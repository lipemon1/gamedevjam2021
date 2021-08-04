using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SoulSystem.FollowPlayer
{
    public class FollowPlayerBehavior : MonoBehaviour
    {
        NavMeshAgent _agent;
        Transform _target;

        bool _followTarget = false;

        private void Awake()
        {
            if (_agent == null)
                _agent = GetComponent<NavMeshAgent>();
        }

        // Start is called before the first frame update
        void Start()
        {
            FollowPlayerManager.Instance.OnFollowPlayer += (player) => StartFollowPlayer(player);
            FollowPlayerManager.Instance.OnStopFollowPlayer += (player) => StopFollowPlayer();
        }

        void LateUpdate()
        {
            if (!_followTarget) return;

            _agent.SetDestination(_target.position);
        }

        void StartFollowPlayer(Transform playerTransform)
        {
            _target = playerTransform;

            _followTarget = true;
        }

        void StopFollowPlayer()
        {
            _target = null;

            _followTarget = false;
        }
    }
}
