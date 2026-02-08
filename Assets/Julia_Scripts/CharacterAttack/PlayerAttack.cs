using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;
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
    [SerializeField] private InteractableCharacter enemy;

    [SerializeField] private UIManager _uiManager; 

    void Update()
    {
        HandleAttackInput();
        
    }

    void HandleAttackInput()
    {     
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && enemy == null)
        {
            Debug.Log("Attacked enemy!");
            // apply damage to enemy (set their gameobject to false or destroy)
            //other.gameObject.SetActive(false);
            enemy = other.gameObject.GetComponent<InteractableCharacter>();
            // fill blood guage
            //bloodGuage.GetBlood(bloodGainPerAttack);
            //Debug.Log("Gained blood: " + bloodGainPerAttack + " from enemy!");
            //Debug.Log("Current Blood: " + bloodGuage.currentBlood);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            enemy = null; 
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
        if (enemy != null)
        {

            if (context.started)
            {
                attackInput = true;

                if(_uiManager == null) 
                {
                    _uiManager = FindFirstObjectByType<UIManager>();
                }

                if (_uiManager == null) return; 

                if (enemy.isHunter)
                {
                    _uiManager.ActivateWinUI();
                }
                else
                {
                    _uiManager.ActivateLoseUI();
                }
                //enemy.Attack();
                //Debug.Log("Attack started");
            }
            if (context.canceled)
            {
                //attackInput = false;
                //Debug.Log("Attack cancelled");
            }
        }
    }
    
}
