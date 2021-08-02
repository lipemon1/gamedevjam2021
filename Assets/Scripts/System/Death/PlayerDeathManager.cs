using SoulSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerDeath
{
    public class PlayerDeathManager : MonoBehaviour
    {
        public static PlayerDeathManager Instance { get; set; }

        List<RedSoulAttackBehavior> _soulsKillingPlayer = new List<RedSoulAttackBehavior>();

        [SerializeField] int _soulsToKillPlayer;

        public delegate void OnPlayerDeathDelegate();
        public OnPlayerDeathDelegate OnPlayerDeath;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        public void NewSoulKillingPlayer(RedSoulAttackBehavior redSoulAttackBehavior)
        {
            foreach (RedSoulAttackBehavior redSoulAttack in _soulsKillingPlayer)
                redSoulAttack.StartRaid();

            _soulsKillingPlayer.Add(redSoulAttackBehavior);

            VerifyDeathCondition();
        }

        public void StopSoulKillingPlayer(RedSoulAttackBehavior redSoulAttackBehavior)
        {
            redSoulAttackBehavior.StopRaid();

            _soulsKillingPlayer.Remove(redSoulAttackBehavior);

            VerifyDeathCondition();
        }

        void VerifyDeathCondition()
        {
            if(_soulsKillingPlayer?.Count >= _soulsToKillPlayer)
                OnPlayerDeath?.Invoke();
        }
    }
}