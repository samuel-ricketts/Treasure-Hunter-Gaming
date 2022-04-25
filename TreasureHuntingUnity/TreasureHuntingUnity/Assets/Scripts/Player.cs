using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    ObjectPool pool;
    GameManager gm;
    private static int health = 3;

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
        gm = GameManager.GM;
        
        playerRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (health <= 0)
        {
            //gamemanager shift
        }

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

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGo = collision.gameObject;

        if (otherGo.tag == "Key1")
        {

            Inventory.key1 = true;
            Destroy(otherGo);
        }
        if (otherGo.tag == "Key2")
        {
            Inventory.key2 = true;

            Destroy(otherGo);
        }
        if (otherGo.tag == "Key3")
        {
            Inventory.key3 = true;

            Destroy(otherGo);
        }


        if (otherGo.tag == "Enemy")
        {
            Destroy(otherGo);
            health--;
        }
    }
}

