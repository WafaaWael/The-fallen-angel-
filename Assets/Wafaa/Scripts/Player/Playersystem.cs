using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playersystem : MonoBehaviour
{
    [SerializeField] private Image health;
    [SerializeField] private FlyingEnemyBullet healthAction;
    private float healthCount=20;
    private float maxhealth = 20;
    public int score=0;
    private float timer;
    [SerializeField] Animator animator;
    [SerializeField] private void_event deayh_event;
    public static Playersystem Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        health.fillAmount = healthCount/ maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = healthCount / maxhealth;
        Heal();
        Die();
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            healthCount = healthCount - 1;
            Debug.Log($"{healthCount}");
            health.fillAmount = healthCount / maxhealth;
        }
        if (collision.gameObject.CompareTag("Melee_Enemy"))
        {
            healthCount = healthCount - 1;
            Debug.Log($"{healthCount}");
            health.fillAmount = healthCount / maxhealth;
        }
        if (collision.gameObject.CompareTag("Spikes"))
        {
            healthCount = healthCount - 1;
            Debug.Log($"{healthCount}");
            health.fillAmount = healthCount / maxhealth;
        }
    }
    private void Heal()
    {
        if (healthCount < 10)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                timer = 0;
                healthCount = healthCount + 1;

            }
        }
    }

    public void SetHealth(int Health )
    {
        healthCount = Health;
    }
    public float getHealth()
    {
        return healthCount;
    }
    private void Die()
    {
        if(healthCount <= 0)
        {
            //put here animation fly 
          deayh_event.Raise();
        }
    }
   
   
}
