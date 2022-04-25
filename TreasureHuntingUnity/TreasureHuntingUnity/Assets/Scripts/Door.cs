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
    public int lockID = -1; //ID of the key needed to open the door, -1 for an unlocked door, 0 for not unlockable

    private FollowCam fc;
    //private Inventory inv;

    // Start is called before the first frame update
    void Start()
    {
        fc = FollowCam.FOLLOWCAM;
        //inv = Inventory.INV;

        if(lockID != 0)
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

    void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;

        if (go.tag == "Player" && nextRoom != null)
        {
            if (lockID == -1 /*|| inv.checkKey(lockID)*/) //if the door has no lock or if the player has the key
            {
                GetComponent<BoxCollider>().isTrigger = true;
                fc.ChangeRooms(nextRoom);
            }
        }
    }

}
