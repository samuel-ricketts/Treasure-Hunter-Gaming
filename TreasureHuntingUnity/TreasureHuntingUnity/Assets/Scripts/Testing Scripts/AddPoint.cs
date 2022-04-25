/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 23, 2022
 * 
 * Description: Check for score update [TESTINGS ONLY]
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TEST SCRIPT FOR CHECKING SCORE UPDATE
public class AddPoint : MonoBehaviour
{
    public int point = 100; 

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp("return")) {
            GameManager.GM.Score = GameManager.GM.Score + point;}

    }//end Update()
}
