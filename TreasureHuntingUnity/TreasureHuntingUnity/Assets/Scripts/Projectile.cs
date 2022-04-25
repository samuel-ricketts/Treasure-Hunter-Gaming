using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        GameObject colGO = collision.gameObject;

        if(colGO.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
