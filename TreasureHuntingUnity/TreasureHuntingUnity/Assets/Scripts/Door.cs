/*
 * Created by: Krieger
 * Created on: 4/20/2022
 * 
 * Last Edited By: Krieger
 * Last Edited On: 4/20/2022
 * 
 * Description: Tells the player what room to enter on colliding with this door
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int room; //holds a reference to the index of the next room

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public int getRoom()
    {
        return room;
    }
}
