using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyingEnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
   [SerializeField] private float force;
    //put here sprite anime
    private float attackDistance = 1f;
    private float timer;
    public UnityAction health;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        destroyer();
    }
    private void Move()
    {
        Vector2 direction = player.transform.position - this.transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }
    private void destroyer()
    {
       
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                Destroy(this.gameObject);

            }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

}
