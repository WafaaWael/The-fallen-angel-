using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Playersystem Player;
    [SerializeField] private int enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        die();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Player.score++;
            enemyHealth--;
        }
    }
    private void die()
    {
        if(enemyHealth<=0)
        {
            StartCoroutine(DeiCount());
            Destroy(gameObject);
        }
    }
    private IEnumerator DeiCount()
    {
        // put here animation dei for flying enemy
        yield return new WaitForSeconds(1);
    }
}
