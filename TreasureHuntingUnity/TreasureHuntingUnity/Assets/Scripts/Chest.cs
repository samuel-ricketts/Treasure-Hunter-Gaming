using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update



    ObjectPool pool;

    private void Start()
    {
        pool = ObjectPool.POOL;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGo = collision.gameObject;

        if (otherGo.tag == "Bullet")
        {
            Debug.Log("Enemy hit by projectile " + otherGo.name);
            pool.ReturnObjects(otherGo); // destroy projectile
            
            Destroy(gameObject);
        }
    }
}
