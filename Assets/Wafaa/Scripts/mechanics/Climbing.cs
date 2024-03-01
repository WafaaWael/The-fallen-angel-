using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    private bool climping = false;
    private float climpV = 0;
    private int power=2;
    private Input_handler input;
    [SerializeField] private Rigidbody2D rb;
    float originalGravity;
    // Start is called before the first frame update
    void Start()
    {
        input = Input_handler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        climpV = input.ladder_value;
        ClimpMove();
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Ladder"))
        {
            climping = true;
            Debug.Log("climp =  true ");

            Debug.Log("Trigger entered with " + otherCollider.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //rb.gravityScale = originalGravity;
        climping = false;
    }
    private void ClimpMove()
    {
         originalGravity = rb.gravityScale;

        if (climpV==1)
        {
            if (climping == true)
            {
                rb.velocity = new Vector2(0, transform.position.y + 2);
                Debug.Log("this W");
            }
        }
        if (climpV == -1)
        {
            if (climping == true)
            {
                rb.velocity = new Vector2(0, transform.position.y - 2);

                Debug.Log("this S");
            }
        }
    }
}
