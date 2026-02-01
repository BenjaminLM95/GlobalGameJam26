using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;
using UnityEditor.PackageManager;
using Unity.VisualScripting;

public class PlayerAttack : MonoBehaviour
{
    // player detects enemy by tag
    // when attack input is received, check for enemy in range and apply damage
    // fill up blood guage when drinking enemy blood (+ 20 points per drink)

    [SerializeField]private UserInput inputManager;
    private CharacterController characterController => GetComponent<CharacterController>();
    private bool attackInput = false;
    private Player_BloodGuage bloodGuage => GetComponent<Player_BloodGuage>();
    [SerializeField] private int bloodGainPerAttack = 20;

    void Update()
    {
        HandleAttackInput();
        
    }

    void HandleAttackInput()
    {     
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && attackInput)
        {
            Debug.Log("Attacked enemy!");
            // apply damage to enemy (set their gameobject to false or destroy)
            other.gameObject.SetActive(false);
            // fill blood guage
            bloodGuage.GetBlood(bloodGainPerAttack);
            Debug.Log("Gained blood: " + bloodGainPerAttack + " from enemy!");
            Debug.Log("Current Blood: " + bloodGuage.currentBlood);
        }
    }

    void OnEnable()
    {
        inputManager.AttackInputEvent += AttackHandler;
    }

    void OnDisable()
    {
        inputManager.AttackInputEvent -= AttackHandler;
    }

    void AttackHandler(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            attackInput = true;
            //Debug.Log("Attack started");
        }
        if(context.canceled)
        {
            //attackInput = false;
            //Debug.Log("Attack cancelled");
        }
    }
    
}
