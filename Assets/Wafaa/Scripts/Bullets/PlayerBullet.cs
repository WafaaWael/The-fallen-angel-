using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    private float timer;
    //put here play bullets sprite sheet 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(transform.position.x + 1, transform.position.y + 1);
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;

        }
    }
}
