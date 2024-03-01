using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.ParticleSystem;


public class Player_controller : MonoBehaviour
{
    [SerializeField] private float moving_speed;
    [SerializeField] private float jump_force;
    [SerializeField] private float fall_multiplaier;
    [SerializeField] private BoxCollider2D feet;
    [SerializeField] private Animator animator;
    [SerializeField] private void_event pause_event;
    public bool has_wings=false;
    [SerializeField] private bool isgrounded = true;
    [SerializeField] private bool melee_bool= false;
    [SerializeField] private bool range_bool = false;
    [SerializeField] private bool crouch_bool = false;

    private Rigidbody2D Rigidbody2D;
    private Input_handler input_;
    private float Movement_value;
    private Vector2 gravity;
    private bool jumping;
    /// <summary>
    /// / the group of int that include the word hash are used to store the strings of the animator parameters
    /// </summary>
    /// only one parameter will be left for you has_wings in the animator
    private int anim_hash_diretion_x;
    private int anim_hash_jump_bool;
    private int anim_hash_crouch_bool;
    private int anim_hash_wings;
    private int anim_hash_wings_bool;
    private int anim_hash_melee_bool;
    private int anim_hash_range_bool;



    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        input_ = Input_handler.Instance;
        feet.excludeLayers =6;
    }
    private void Start()
    {
        input_ = Input_handler.Instance;
        gravity=new Vector2(0,-Physics2D.gravity.y);
        anim_hash_diretion_x = Animator.StringToHash("Blend");
        anim_hash_wings = Animator.StringToHash("has_wings");
        anim_hash_wings_bool = Animator.StringToHash("has_wings_bool");
        anim_hash_jump_bool = Animator.StringToHash("jumping");
        anim_hash_crouch_bool = Animator.StringToHash("crouch");
        anim_hash_melee_bool = Animator.StringToHash("melee");
        anim_hash_range_bool = Animator.StringToHash("range");
    }
    private void Update()
    {
        Movement_value = input_.direction;
        if (Movement_value != 0)
        {
            transform.localScale =new Vector3( Movement_value,1,1);
        }
        animator.SetFloat(anim_hash_diretion_x, Movement_value);
        animator.SetBool(anim_hash_melee_bool,melee_bool);
        animator.SetBool(anim_hash_range_bool,range_bool);
        animator.SetBool(anim_hash_crouch_bool, crouch_bool);
        if (input_.jump_trigger)
        {
            jump();
            jumping = true;
        }
        if (has_wings)
        {
            animator.SetBool(anim_hash_wings_bool,true);
            animator.SetFloat(anim_hash_wings,1);

        }
        else
        {
            animator.SetBool(anim_hash_wings_bool, false);
            animator.SetFloat(anim_hash_wings, 0);
        }

        
    }
    private void FixedUpdate()
    {
        apply_movement();
        ranged();
        crouch();
        melee();
        Pause();
    }
  
    private void Pause()
    {
        if (input_.pause_trigger)
        {
           pause_event.Raise();
        }
    }
    private void ranged()
    {
        if (input_.attack_trigger)
        {
            range_bool = true;
        }
        else
        {
            range_bool = false;
        }
    }
    private void crouch()
    {
        if (input_.crouch_trigger)
        {
            crouch_bool = true;
        }
        else
        {
            crouch_bool = false;
        }
    }
    private void melee()
    {
        if (input_.melee_trigger)
        {
           melee_bool = true;
        }
        else
        {
            melee_bool = false;
        }
    }
    private void jump()
    {
        
            if (isgrounded&&jumping)
            {

                Rigidbody2D.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
                Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x,jump_force);
                animator.SetBool(anim_hash_jump_bool, true);
                isgrounded = false;
                jumping = true;
                Rigidbody2D.velocity += 5 * gravity * Time.deltaTime;
            }

            if (Rigidbody2D.velocity.y <= 0)
            {
                Rigidbody2D.velocity -= gravity * fall_multiplaier * Time.deltaTime;
            }

        
    }
    
    private void apply_movement()
    {
        float velocity = moving_speed * Movement_value;
        Rigidbody2D.velocity = new Vector2(velocity, Rigidbody2D.velocity.y);
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer==3)
        {
            isgrounded=true;
            animator.SetBool(anim_hash_jump_bool,false);
        }
    }
}
