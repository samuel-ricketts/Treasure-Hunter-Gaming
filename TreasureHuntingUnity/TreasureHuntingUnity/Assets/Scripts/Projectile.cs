using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update


    ObjectPool pool;

    private void Start()
    {
        pool = ObjectPool.POOL;
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject colGO = collision.gameObject;

        if(colGO.tag == "Wall" || colGO.tag == "Door")
        {
            pool.ReturnObjects(this.gameObject);
        }
    }
}
