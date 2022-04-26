using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region Player Singleton
    static public Player PLAYER;

    void CheckPLAYERIsInScene()
    {
        if (PLAYER == null)
        {
            PLAYER = this;
        }
        else
        {
            Debug.LogError("PLAYER.Awake() - Attempted to assign a second Player.PLAYER");
            Destroy(this.gameObject);
        }
    }
    #endregion

    private ObjectPool pool;
    private GameManager gm;
    private Inventory inv;
    public int health = 3;
    public int maxHealth = 3;

    public Rigidbody playerRigidbody;

    [Header("Hero Movement")]
    public float speed = 10;
    

    [Space(10)]

    [Header("Bullet Settings")]

    public float bulletSpeed; //speed of the projectile




    void Awake()
    {
        CheckPLAYERIsInScene();
    }

    // Start is called before the first frame update
    void Start()
    {
        pool = ObjectPool.POOL;
        gm = GameManager.GM;
        inv = Inventory.INV;

        playerRigidbody = this.GetComponent<Rigidbody>();

        setPlayer();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            FireBullet(0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FireBullet(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            FireBullet(2);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            FireBullet(3);
        }
    }//end Update()



    public void setPlayer()
    {
        
        Vector3 pos = new Vector3(0f, -15f, -3f);
        transform.position = pos;
        health = maxHealth;
    }


    private void FireBullet(int direction)
    {
        GameObject projGo = pool.GetObject();
        if (projGo != null)
        {
            

            projGo.transform.position = transform.position;
            Rigidbody rb = projGo.GetComponent<Rigidbody>();
            if(direction == 0)
            {
                rb.velocity = Vector3.up * bulletSpeed;
            } 
            else if(direction == 1)
            {
                rb.velocity = Vector3.down * bulletSpeed;
            }
            else if (direction == 2)
            {
                rb.velocity = Vector3.left * bulletSpeed;
            }
            else if (direction == 3)
            {
                rb.velocity = Vector3.right * bulletSpeed;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGo = collision.gameObject;

        if (otherGo.tag == "Key1")
        {
            inv.addKey(0);
            Destroy(otherGo);
            
        }
        else if (otherGo.tag == "Key2")
        {
            inv.addKey(1);
            Destroy(otherGo);
        }
        else if (otherGo.tag == "Key3")
        {
            inv.addKey(2);
            Destroy(otherGo);
        }
        else if (otherGo.tag == "Enemy")
        {
            Destroy(otherGo);
            health--;
            if (health <= 0)
            {
                gm.GameOver(); //gamemanager shift
            }
        }
        /*else if (otherGo.tag == "Door1")
        {
            if (Inventory.key1 == true)
            {
                otherGo.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
        else if (otherGo.tag == "Door2")
        {
            if (Inventory.key2 == true)
            {
                otherGo.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
        else if (otherGo.tag == "Door3")
        {
            if (Inventory.key3 == true)
            {
                otherGo.GetComponent<BoxCollider>().isTrigger = true;
            }
        }*/


    }

    /*void OnCollisionExit(Collision collision)
    {
        GameObject otherGo = collision.gameObject;

        if (otherGo.tag == "Door1")
        {
            if (Inventory.key1 == true)
            {
                otherGo.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
        else if (otherGo.tag == "Door2")
        {
            if (Inventory.key2 == true)
            {
                otherGo.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
        else if (otherGo.tag == "Door3")
        {
            if (Inventory.key3 == true)
            {
                otherGo.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }*/
}

