using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int ammo;
    private int numItems;
    static public List<Item> Items = new List<Item>();
    public string itemName;

    private void Awake()
    {
        BuildDatabase();
    }

    // Start is called before the first frame update
    void Start()
    {
        ammo = 0;
        numItems = 0;
    }

    public Item GetItem(int id)
    {
        return Items.Find(Items => Item.id == id);
    }

    void BuildDatabase()
    {
        Items = new List<Item>()
        {
            new Item(0, "MeleeWeapon", "A trusty rusty dagger!", new Dictionary<string, int>{
                {"Damage", 1 }
            }),

            new Item(1, "GUN", "That's just it, a GUN!", new Dictionary<string, int>
            {
                {"Damage", 3 }
            })
        };
    }

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
}
