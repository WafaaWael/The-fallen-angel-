using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    private bool isFly;
    private bool canFly=false;
    private float flyPower=40f;
    private float flyheight = 20;
    private float flyTime=0.2f;
    private float flyCoolDown = 1f;
    [SerializeField] private TrailRenderer trilRenderer;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] Playersystem player;
    [SerializeField] BoxCollider2D collider2D;
    [SerializeField] private Player_controller _Controller;
    private Input_handler input;
    // Start is called before the first frame update
    void Start()
    {
        input = Input_handler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFly == false)
        {
            if (input.fly_trigger)
            {
                if (canFly == true)
                {
                    //put here animation fly 
                    _Controller.has_wings = true;
                    StartCoroutine(Fly());
                }
            }
        }
    }
    private IEnumerator Fly()
    {
        canFly = false;
        isFly = true;
        float originalGravity = rigidbody.gravityScale;
        rigidbody.gravityScale = 0f;
        rigidbody.velocity = new Vector2(transform.localScale.x * flyPower, 0.1F*transform.localScale.y*Mathf.Log(flyheight));
        trilRenderer.emitting=true;
        yield return new WaitForSeconds(flyTime);
        rigidbody.gravityScale= originalGravity;
        trilRenderer.emitting = false;
        isFly =false;
        canFly = true;
        yield return new WaitForSeconds(flyCoolDown);
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Statu"))
        {
            canFly = true;
            player.SetHealth(20);
        }
    }
   
}
