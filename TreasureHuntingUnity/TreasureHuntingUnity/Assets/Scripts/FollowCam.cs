/*
 * Created by: Krieger
 * Created on: 4/23/2022
 * 
 * Last Edited By: Krieger
 * Last Edited On: 4/23/2022
 * 
 * Description: Controls the camera and lets it follow player from room to room
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    #region FollowCam Singleton
    static public FollowCam FOLLOWCAM;

    
    void CheckFOLLOWCAMIsInScene()
    {

        //Check if instnace is null
        if (FOLLOWCAM == null)
        {
            FOLLOWCAM = this; //set FOLLOWCAM to this game object
        }
        else //else if FOLLOWCAM is not null send an error
        {
            Debug.LogError("FollowCam.Awake() - Attempeted to assign second FollowCam.FOLLOWCAM"); 
        }
    }//end CheckFOLLOWCAMIsInScene()
    #endregion

    private float camZPos;

    public float cameraMoveSpeed = 120f; //speed that the camera moves from room to room
    public float snapToRoomDistance = 5f; //how far before the camera just snaps to the center of the room
    private Vector3 targetPosition;
    private bool moving;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        CheckFOLLOWCAMIsInScene();
        camZPos = transform.position.z;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (targetPosition.Equals(transform.position))
            {
                moving = false;
                rb.velocity = Vector3.zero;
            }
            else
            {
                Vector3 targetVel = targetPosition - transform.position;

                if (targetVel.magnitude < snapToRoomDistance)
                {
                    transform.position = targetPosition;
                    return;
                }

                targetVel.Normalize();
                targetVel *= cameraMoveSpeed;

                rb.velocity = targetVel;
            }
        }
    }

    public void ChangeRooms(Room room) //method overloaded for sanity's sake later
    {
        ChangeRooms(room.transform.position);
    }

    public void ChangeRooms(Vector3 roomPos)
    {
        if (!moving)
        {
            targetPosition = roomPos;
            targetPosition.z = camZPos;
            moving = true;
        }
    }
}
