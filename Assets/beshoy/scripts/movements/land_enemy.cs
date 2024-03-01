using System.Collections;
using UnityEngine;

public class LandEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isattacking;
    [SerializeField] private bool ischasing;
    [SerializeField] private bool isidle;

    private int chase_bool;
    private int idle_bool;
    private int attack_bool;
    private int dead_tirgger;
    private Rigidbody2D RB2D;
    private int currentindex = 0;
    private bool collidedWithPlayer = false;

    private void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        chase_bool = Animator.StringToHash("chasing");
        idle_bool = Animator.StringToHash("idle");
        attack_bool = Animator.StringToHash("attacking");
        dead_tirgger = Animator.StringToHash("dead");
        Patrol();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= 4)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
        animator.SetBool(attack_bool, isattacking);
        animator.SetBool(chase_bool, ischasing);
        animator.SetBool(idle_bool, isidle);
    }

    private void Chase()
    {
        ischasing = true;
        Vector2 direction = (player.transform.position - transform.position).normalized;
        RB2D.velocity = direction * speed;

        // Check if the distance between enemy and player changes
        if (Vector2.Distance(transform.position, player.transform.position) > 4)
        {
            // Player has moved away, stop chasing and resume patrolling
            Patrol();
        }
        else if (Vector2.Distance(transform.position, player.transform.position) <= 2)
        {
            // Player is within attack range, initiate attack
            StartCoroutine(DoAttack());
        }
    }

    IEnumerator DoAttack()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        RB2D.velocity = direction * speed;
        transform.localScale = new Vector3(direction.normalized.x, 1, 1);
        // Wait for a short duration to allow the collision to occur
        yield return new WaitForSeconds(0.1f);

        // Check if the enemy collided with the player
        if (collidedWithPlayer)
        {
            Debug.Log("Attack");
            isattacking = true;
            Vector2 forceBack = (transform.position - player.transform.position).normalized;
            RB2D.AddForce(forceBack * 10f, ForceMode2D.Impulse);
            collidedWithPlayer = false; // Reset the flag to avoid continuous bouncing
        }

        // Wait for a short duration before allowing another attack
        yield return new WaitForSeconds(3);
        StartCoroutine(DoAttack());
    }


    private void Patrol()
    {
        Vector2 direction = (waypoints[currentindex].transform.position - transform.position).normalized;
        RB2D.velocity = direction.normalized * speed;
        transform.localScale= new Vector3(direction.normalized.x,1,1);

        if (Vector2.Distance(transform.position, waypoints[currentindex].transform.position) <= 1f)
        {
            currentindex = (currentindex + 1) % waypoints.Length;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            collidedWithPlayer = true;
        }
        else
        {
            collidedWithPlayer = false;
        }
    }
}
