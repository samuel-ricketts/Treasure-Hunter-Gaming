/*
 * Created by: Krieger
 * Created on: 4/15/2022
 * 
 * Last Edited By: Krieger
 * Last Edited On: 4/15/2022
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /**Variables**/
    [SerializeField]
    private GameObject targetObject; //reference to the object the enemy will be targeting, generally the player

    private Rigidbody rb;

    [Header("Movement Settings")]
    public float speed = 5f;


    [Header("Projectile Settings")]
    public bool hasProjectile = false; //if this enemy has a projectile
    public GameObject projectile; //if it has a projectile, a reference to the projectile prefab
    public float projectileCooldown = 2f; //how long between firing projectiles
    public float projectileSpeed = 10f; //speed to fire projectile at

    private float timeSinceLastShot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(targetObject != null) //if the enemy has a target
        {
            Vector3 targetPos = targetObject.transform.position - transform.position;
            targetPos.Normalize();
            targetPos = targetPos * speed;

            rb.velocity = targetPos;
        }
        if(timeSinceLastShot >= projectileCooldown)
        {
            FireProjectile();
            timeSinceLastShot = 0;
        }
        timeSinceLastShot += Time.deltaTime;
    }

    // Set a new target for the enemy to follow
    public void SetTarget(GameObject newTarget)
    {
        targetObject = newTarget;
    }

    // Fires the projectile prefab in the direction of the targetObject
    void FireProjectile()
    {
        if(hasProjectile && projectile != null) //if it is supposed to shoot and has something to shoot
        {
            GameObject projObj = Instantiate(projectile);
            Rigidbody projRB = projObj.GetComponent<Rigidbody>();

            projObj.transform.position = transform.position;
            Vector3 targetPos;

            if (targetObject != null)
            {
                targetPos = targetObject.transform.position - transform.position;
                targetPos.Normalize();
                targetPos = targetPos * projectileSpeed;
            }
            else
            {
                targetPos = Vector3.down * projectileSpeed;
            }

            projRB.velocity = targetPos;
        }
    }
}
