using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_T1 {
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item_T1(int id, string title, string description, Dictionary<string, int> stats)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        /// <summary>
        /// Sets the path to where the item is 
        /// change the path to local path for where items are placed in project
        /// </summary>
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + title); 
        this.stats = stats;
    }

    public Item_T1(Item_T1 item_t1)
    {
        this.id = item_t1.id;
        this.title = item_t1.title;
        this.description = item_t1.description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item_t1.title);
        this.stats = item_t1.stats;
    }
}
