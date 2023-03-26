using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIInventory_T1 : MonoBehaviour {

    public List<UIItem_T1> uiItems = new List<UIItem_T1>();
    public GameObject slotPrefab;
    public Transform slotPanel;

    void Awake()
    {
        for (int i = 0; i < 24; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);

            uiItems.Add(instance.GetComponentInChildren<UIItem_T1>());
        }
    }

    public void UpdateSlot(int slot, Item_T1 item)
    {
        uiItems[slot].UpdateItem(item);
    }

    public void AddItem(Item_T1 item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item_t1 == null), item);
    }

    public void RemoveItem(Item_T1 item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item_t1 == item), null);
    }
}
