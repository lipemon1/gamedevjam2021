using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerDeath
{
    public class DeathUIFeedback : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            PlayerDeathManager.Instance.OnPlayerDeath += () => ToggleUI(true);
            ToggleUI(false);
        }

        // Update is called once per frame
        void ToggleUI(bool value)
        {
            transform.gameObject.SetActive(value);
        }
    }
}
