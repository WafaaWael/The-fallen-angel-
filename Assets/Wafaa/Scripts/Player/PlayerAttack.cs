using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private Camera _Camera;
    [SerializeField, Range(1f, 100f)] private float rotationSpeed=1;
    private Input_handler input;
    private Vector3 mousePos;
    private float timer = 0;
    // Start is called before the first frame update
    private void Start()
    {
        input = Input_handler.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        firing();
    }

    private void firing()
    {
        if (input.attack_trigger)
        {

            //Debug.Log("This fiting method");
            mousePos = Input.mousePosition.normalized;
            mousePos = _Camera.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            transform.up= Vector3.MoveTowards(transform.up,mousePos,rotationSpeed*Time.deltaTime);
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            timer += Time.deltaTime;
            if (timer > 0.01)
            {
                timer = 0;
                Instantiate(bullet, bulletPosition.transform.position, Quaternion.Euler(0, 0, rotZ));

            }

        }
    }
}