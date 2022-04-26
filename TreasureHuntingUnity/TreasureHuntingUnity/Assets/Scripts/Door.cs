/*
 * Created by: Krieger
 * Created on: 4/20/2022
 * 
 * Last Edited By: Krieger
 * Last Edited On: 4/25/2022
 * 
 * Description: Tells the camera what room to enter on colliding with this door
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Room nextRoom; //holds a reference to the index of the next room

    public int keyIndex = -1; 

    private FollowCam fc;

    private Inventory inv;
    //private Inventory inv;

    // Start is called before the first frame update
    void Start()
    {
        fc = FollowCam.FOLLOWCAM;
        inv = Inventory.INV;

        if(keyIndex != -1)
        {
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    // Update is called once per frame
    public Room getRoom()
    {
        return nextRoom;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        
        if(go.tag == "Player" && nextRoom != null)
        {
            fc.ChangeRooms(nextRoom);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject go = other.gameObject;

        if (go.tag == "Player" && nextRoom != null && keyIndex != -1)
        {
            GetComponent<BoxCollider>().isTrigger = false;
            Debug.Log("turning off trigger for door " + keyIndex);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;

        if (go.tag == "Player" && nextRoom != null)
        {
            if (inv.checkKey(keyIndex))
            {
                GetComponent<BoxCollider>().isTrigger = true;
                Debug.Log("turning on trigger for door " + keyIndex);
            }
        }
    }
}
