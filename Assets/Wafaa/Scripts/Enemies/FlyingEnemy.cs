using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] private  GameObject bullet;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private GameObject Player;
    private float timer;
    private float attackDistance=15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShottingMang();
    }
    private void shooting()
    {
        Instantiate(bullet, bulletPosition.position,Quaternion.identity);
    }
    private void ShottingMang()
    {
        if (Vector2.Distance(Player.transform.position,this.transform.position)< attackDistance)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                shooting();
            }
        }
    }
}
