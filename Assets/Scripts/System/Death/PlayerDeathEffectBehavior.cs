using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerDeath
{
    public class PlayerDeathEffectBehavior : MonoBehaviour
    {
        [SerializeField] float _deathEffectTime;
        WaitForSeconds _deathEffectWait;

        // Start is called before the first frame update
        void Start()
        {
            _deathEffectWait = new WaitForSeconds(_deathEffectTime);
            PlayerDeathManager.Instance.OnPlayerDeath += () => StartPlayerDeath();
        }

        void StartPlayerDeath()
        {
            StartCoroutine(DeathCo());
        }

        IEnumerator DeathCo()
        {
            yield return _deathEffectWait;
            StopPlayerDeath();
        }

        void StopPlayerDeath()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
