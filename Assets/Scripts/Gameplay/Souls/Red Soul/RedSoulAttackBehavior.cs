using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulSystem
{
    public class RedSoulAttackBehavior : MonoBehaviour
    {
        [SerializeField] Transform _player;
        [SerializeField] GameObject _uiFeedback;

        bool _attacking;

        private void Awake()
        {
            if (_player == null)
                _player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void LateUpdate()
        {
            if (_attacking)
                transform.LookAt(_player);
        }

        public void StartAttack()
        {
            _attacking = true;
            ToggleUI(_attacking);
        }

        public void StopAttack()
        {
            _attacking = false;
            ToggleUI(_attacking);
        }

        void ToggleUI(bool value)
        {
            _uiFeedback.SetActive(value);
        }
    }
}
