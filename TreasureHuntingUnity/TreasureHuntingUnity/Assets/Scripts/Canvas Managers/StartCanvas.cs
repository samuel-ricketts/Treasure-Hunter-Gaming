/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 23, 2022
 * 
 * Description: Updates start canvas referecing game manager
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //libraries for UI components

public class StartCanvas : MonoBehaviour
{
    /*** VARIABLES ***/
   
    GameManager gm; //reference to game manager

    [Header("Canvas SETTINGS")]
    public Text titleTextbox; //textbox for the title
    public Text creditsTextbox; //textbox for the credits
    public Text copyrightTextbox; //textbox for the copyright

    private void Start()
    {
         gm = GameManager.GM; //find the game manager
         
         //Set the Canvas text from GM reference
         titleTextbox.text = gm.gameTitle; 
         creditsTextbox.text = gm.gameCredits;
         copyrightTextbox.text = gm.copyrightDate;
    }



   public void GameStart()
    {
        gm.StartGame(); //refenece the StartGame method on the game manager

    }

   public void GameExit()
    {
        gm.ExitGame(); //refenece the ExitGame method on the game manager

    }

}
