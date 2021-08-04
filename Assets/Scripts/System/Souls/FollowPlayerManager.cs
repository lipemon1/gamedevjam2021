using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulSystem.FollowPlayer
{
    public class FollowPlayerManager : MonoBehaviour
    {
        public static FollowPlayerManager Instance { get; set; }

        [SerializeField] Transform _player;

        public delegate void OnFollowPlayerDelegate(Transform player);
        public OnFollowPlayerDelegate OnFollowPlayer;

        bool _followingPlayer = false;

        private void Awake()
        {
            if (_player == null)
                _player = GameObject.FindGameObjectWithTag("Player").transform;


            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        public void StartFollowPlayer()
        {
            if (!_followingPlayer)
                OnFollowPlayer?.Invoke(_player);

            _followingPlayer = true;
        }
    }
}
