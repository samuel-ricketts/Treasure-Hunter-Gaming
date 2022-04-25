/*
 * Created by: Ethan Landrum
 * Created on: 4/23/2022
 * 
 * Last Edited By: Ethan Landrum
 * Last Edited On: 4/25/2022
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
     static public int ammo;
     static public List<Item> Items = new List<Item>();
     public string itemName;

    [Header("Items")]
    public bool key;
    public bool hasMeleeWeapon;
    public bool hasGun;

    #region FollowCam Singleton
    static public Inventory INV;
    
    void CheckINVIsInScene()
    {

        //Check if instnace is null
        if (INV == null)
        {
            INV = this; //set INV to this game object
        }
        else //else if INV is not null send an error
        {
            Debug.LogError("Inventory.Awake() - Attempted to assign second Inventory.INV");
        }
    }//end CheckINVIsInScene()
    #endregion

    private void Awake()
     {
         BuildDatabase();
         CheckINVIsInScene();

    }


    // public Item GetItem(int id)
    // {
    //     return Items.Find(Items => Item.id == id);
    // }

    // void BuildDatabase()
    // {
    //     Items = new List<Item>()
    //     {
    //         new Item(0, "MeleeWeapon", "A trusty rusty dagger!", new Dictionary<string, int>{
    //             {"Damage", 1 }
    //         }),

    //         new Item(1, "GUN", "That's just it, a GUN!", new Dictionary<string, int>
    //         {
    //             {"Damage", 3 }
    //         })
    //     };
    // }


    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Item"))
        {
            numItems++;
            itemName = collision.name;
            Items.Add(collision);
            Destroy(collision.gameObject);
        }
    }
    
    void Start()
     {
        ammo = 0;
        key = false;
        hasMeleeWeapon = false;
        hasGun = false;
     }

     public Item GetItem(int id)
     {
        return Items.Find(x => x.id == id);
     }

    public Item GetItem(string title)
    {
        return Items.Find(x => x.title == title);
    }

    void BuildDatabase()
     {
         Items = new List<Item>()
         {
             new Item(0, "MeleeWeapon", "A trusty rusty dagger!", new Dictionary<string, int>{
                 {"Damage", 1 }
             }),

             new Item(1, "Gun", "That's just it, a gun!", new Dictionary<string, int>
             {
                 {"Damage", 3 }
             })
         };
     }

     public void OnTriggerEnter(Collider collision)
     {
         if (collision.CompareTag("Item"))
         {
             itemName = collision.name;
             
             if(itemName == "Ammo")
            {
                ammo += 10;
            }
            if (itemName == "Key")
            {
                key = true;
            }
            if (itemName == "MeleeWeapon")
            {
                hasMeleeWeapon = true;
            }
            if (itemName == "Gun")
            {
                hasGun = true;
            }
             Destroy(collision.gameObject);
         }
     }

    public bool checkKey()
    {
        return key;
    }

    public bool checkMelee()
    {
        return hasMeleeWeapon;
    }

    public bool checkGun()
    {
        return hasGun;
    }
    

}
