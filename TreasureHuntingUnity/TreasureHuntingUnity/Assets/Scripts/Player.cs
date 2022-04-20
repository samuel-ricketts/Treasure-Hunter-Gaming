using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    ObjectPool pool;
    private Rigidbody playerRigidbody;

    [Header("Hero Movement")]
    public float speed = 10;
    

    [Space(10)]

    [Header("Bullet Settings")]

    public float bulletSpeed; //speed of the projectile


    

    // Start is called before the first frame update
    void Start()
    {
        pool = ObjectPool.POOL;
        playerRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");  //horizontal axis
        float yAxis = Input.GetAxis("Vertical");    //vertical axis
        Vector3 vel = playerRigidbody.velocity; //vector for position
        vel.x += xAxis * speed * Time.deltaTime; //adjust x position
        vel.y += yAxis * speed * Time.deltaTime;
        playerRigidbody.velocity = vel;//adjusts y position
         //updated position
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();//fires
        }
    }//end Update()


    void FireBullet()
    {
        GameObject projGo = pool.GetObject();
        if (projGo != null)
        {
            

            projGo.transform.position = transform.position;
            Rigidbody rb = projGo.GetComponent<Rigidbody>();
            rb.velocity = Vector3.up * bulletSpeed;
        }

    }
}

