using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase_T1 : MonoBehaviour {
    public List<Item_T1> items = new List<Item_T1>();


    void Awake()
    {
        BuildDatabase();
    }

    // Get item by id number.
    public Item_T1 GetItem(int id)
    {
        return items.Find(item=> item.id == id);
    }

    // Get item by name
    public Item_T1 GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }


    /// <summary>
    /// This is where you add items.
    /// Each item requires:
    /// An int which scales by 1 each time.
    /// A name (that is the same as the sprite name.
    /// A description.
    /// And finally declare all the "stats" of the item in the dict.
    /// </summary>
    void BuildDatabase()
    {
        items = new List<Item_T1>()
        {
            new Item_T1(0, "Potion 1", "Only the very best health booster",
            new Dictionary<string, int>
            {
                { "Value", 100 }, { "Weight", 2 }
            }),
            new Item_T1(1, "Armor 1", "The original Armor of the land.",
            new Dictionary<string, int>
            {
                { "Value", 40 }, { "Weight", 4 }
            }),
            new Item_T1(2, "Axe 1", "The Axe forged in Numenor",
            new Dictionary<string, int>
            {
                { "Value", 500 }, { "Weight", 16}, { "Mining", 10}, { "Attack", 4}, { "Defence", 1 }
            })
        };
    }
}
