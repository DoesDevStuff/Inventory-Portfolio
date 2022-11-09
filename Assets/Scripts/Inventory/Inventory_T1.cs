using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_T1 : MonoBehaviour {
    public List<Item_T1> inventItems = new List<Item_T1>();
    public ItemDatabase_T1 itemDatabase;
    public UIInventory_T1 inventUI;

    void Start()
    {
        GiveItem(1);
        GiveItem(0);
        RemoveItem(1);
        GiveItem(0);
        GiveItem(1);
        GiveItem(2);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            inventUI.gameObject.SetActive(!inventUI.gameObject.activeSelf);
        }
    }
    // Give a player an item via id
    public void GiveItem(int id)
    {
        Item_T1 itemAdd = itemDatabase.GetItem(id);
        inventItems.Add(itemAdd);
        inventUI.AddItem(itemAdd);
        Debug.Log("Added item: " + itemAdd.title);
    }

    // Give a player an item via itemName
    public void GiveItem(string itemName)
    {
        Item_T1 itemAdd = itemDatabase.GetItem(itemName);
        inventItems.Add(itemAdd);
        inventUI.AddItem(itemAdd);
        Debug.Log("Added item: " + itemAdd.title);
    }

    // Checks to see if a player has a given item, if he does can be used to take it away from them for something like a quest.
    public Item_T1 CheckItems(int id)
    {
        return inventItems.Find(item => item.id == id);
    }


    public void RemoveItem(int id)
    {
        Item_T1 itemRemove = CheckItems(id);
        // Item was found and therefore isn't null, so remove it from the list.
        if(itemRemove != null)
        {
            inventItems.Remove(itemRemove);
            inventUI.RemoveItem(itemRemove);
            Debug.Log("Remove Item: " + itemRemove.title);
        }
    }
}
