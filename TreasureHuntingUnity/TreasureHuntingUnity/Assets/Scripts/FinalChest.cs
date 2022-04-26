/*
 * Created by: Krieger
 * Created on: 4/25/2022
 * 
 * Last Edited By: Krieger
 * Last Edited On: 4/25/2022
 * 
 * Description: Special chest that holds the treasure, when broken the player wins the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChest : MonoBehaviour
{
    ObjectPool pool;
    GameManager gm;

    private void Start()
    {
        pool = ObjectPool.POOL;
        gm = GameManager.GM;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGo = collision.gameObject;

        if (otherGo.tag == "Bullet")
        {
            Debug.Log("Enemy hit by projectile " + otherGo.name);
            pool.ReturnObjects(otherGo); // destroy projectile

            gm.WinGame();
            Destroy(gameObject);
        }
    }
}
