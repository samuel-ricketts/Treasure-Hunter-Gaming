/*
 * Created by: Krieger
 * Created on: 4/20/2022
 * 
 * Last Edited By: Krieger
 * Last Edited On: 4/23/2022
 * 
 * Description: Tells the camera what room to enter on colliding with this door
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Room nextRoom; //holds a reference to the index of the next room

    private FollowCam fc;

    // Start is called before the first frame update
    void Start()
    {
        fc = FollowCam.FOLLOWCAM;
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
}
