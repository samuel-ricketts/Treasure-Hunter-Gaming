using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGo = collision.gameObject;

        if (otherGo.tag == "Bullet")
        {
            Debug.Log("Enemy hit by projectile " + otherGo.name);
            otherGo.SetActive(false); // destroy projectile
            
            Destroy(gameObject);
        }
    }
}
