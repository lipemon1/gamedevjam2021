using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] Animator _playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerAnim.SetFloat("Speed", _playerMovement.GetPlayerSpeed());
    }
}
