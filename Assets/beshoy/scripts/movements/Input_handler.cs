using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_handler : MonoBehaviour
{
    [Header("inputAction reference")]
    [SerializeField] private InputActionAsset actions;
    [Header("string referencers")]
    [SerializeField] private string aciton_map;
    [SerializeField] private string move_action;
    [SerializeField] private string jump_action;
    [SerializeField] private string crouch_action;
    [SerializeField] private string fly_action;
    [SerializeField] private string pause_action;
    [SerializeField] private string attack_action;
    [SerializeField] private string melee_action;
    [SerializeField] private string ladder_action;
   


    private InputActionMap inputActions;
    private InputAction Move_Action;
    private InputAction Jump_Action;
    private InputAction Crouch_Action;
    private InputAction Fly_Action;
    private InputAction Pause_Action;
    private InputAction Attack_Action;
    private InputAction Melee_Action;
    private InputAction Ladder_Action;


    public float direction { get; private set; }
    public bool jump_trigger { get; private set; }
    public bool crouch_trigger { get; private set; }
    public bool fly_trigger { get; private set; }
    public bool pause_trigger{ get; private set; }

    public bool attack_trigger { get; private set; }

    public bool melee_trigger { get; private set; }
    public float ladder_value { get; private set; }

    public static Input_handler Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        inputActions = actions.FindActionMap(aciton_map);
        Move_Action = actions.FindActionMap(aciton_map).FindAction(move_action);
        Jump_Action = actions.FindActionMap(aciton_map).FindAction(jump_action);
        Crouch_Action = actions.FindActionMap(aciton_map).FindAction(crouch_action);
        Fly_Action = actions.FindActionMap(aciton_map).FindAction(fly_action);
        Pause_Action = actions.FindActionMap(aciton_map).FindAction(pause_action);
        Attack_Action=actions.FindActionMap(aciton_map).FindAction(attack_action);
        Melee_Action = actions.FindActionMap(aciton_map).FindAction(melee_action);
        Ladder_Action = actions.FindActionMap(aciton_map).FindAction(ladder_action);
        Rejester_input();
    }

    private void Rejester_input()
    {
        Move_Action.performed += context => direction = context.ReadValue<float>();
        Move_Action.canceled += context => direction = 0;

        Ladder_Action.performed += context => ladder_value = context.ReadValue<float>();
        Ladder_Action.canceled += context => ladder_value = 0;

        Jump_Action.performed += context => jump_trigger = true;
        Jump_Action.canceled += context => jump_trigger = false;

        Crouch_Action.performed += context => crouch_trigger = true;
        Crouch_Action.canceled += context => crouch_trigger = false;

        Fly_Action.performed += context => fly_trigger = true;
        Fly_Action.canceled += context => fly_trigger = false;

        Pause_Action.performed += context => pause_trigger = true;
        Pause_Action.canceled += context => pause_trigger = false;

        Attack_Action.performed += context => attack_trigger = true;
        Attack_Action.canceled += context => attack_trigger = false;

        Melee_Action.performed += context => melee_trigger = true;
        Melee_Action.canceled += context => melee_trigger = false;
    }
    private void OnEnable()
    {
        Move_Action.Enable();
        Ladder_Action.Enable();
        Jump_Action.Enable();
        Crouch_Action.Enable();
        Fly_Action.Enable();
        Pause_Action.Enable();
        Attack_Action.Enable();
        Melee_Action.Enable();
    }
    private void OnDisable()
    {
        Move_Action.Disable();
        Ladder_Action.Disable();
        Jump_Action.Disable();
        Crouch_Action.Disable();
        Fly_Action.Disable();
        Pause_Action.Disable();
        Attack_Action.Disable();
        Melee_Action.Disable();


    }
}
