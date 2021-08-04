using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SoulSystem
{
    public class RedSoulAttackBehavior : MonoBehaviour
    {
        [SerializeField] Transform _player;
        [SerializeField] GameObject _uiFeedback;
        [SerializeField] bool _enabledAttackBehavior = true;

        [Space(20)]
        NavMeshAgent _agent;
        [SerializeField] float _normalSpeed;
        [SerializeField] float _raidSpeed;

        bool _attacking;

        private void Awake()
        {
            if (_player == null)
                _player = GameObject.FindGameObjectWithTag("Player").transform;

            if (_agent == null)
                _agent = GetComponent<NavMeshAgent>();

            _agent.speed = _normalSpeed;
        }

        private void LateUpdate()
        {
            if (_attacking)
                transform.LookAt(_player);
        }

        public void StartAttack()
        {
            if (!_enabledAttackBehavior) return;

            _attacking = true;
            PlayerDeath.PlayerDeathManager.Instance.NewSoulKillingPlayer(this);
            ToggleUI(_attacking);
        }

        public void StopAttack()
        {
            _attacking = false;
            PlayerDeath.PlayerDeathManager.Instance.StopSoulKillingPlayer(this);
            ToggleUI(_attacking);
        }

        void ToggleUI(bool value)
        {
            _uiFeedback.SetActive(value);
        }

        public void StartRaid()
        {
            _agent.speed = _raidSpeed;
        }

        public void StopRaid()
        {
            _agent.speed = _normalSpeed;
        }
    }
}
