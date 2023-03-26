using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem_T1 : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

    public Item_T1 item_t1;

    private Image spriteImage;
    private UIItem_T1 selectedItem;
    private ToolTip_T1 tooltip;

    void Awake()
    {
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem_T1>();
        tooltip = GameObject.Find("ToolTip").GetComponent<ToolTip_T1>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(Item_T1 item_t1)
    {
        this.item_t1 = item_t1;
        if(this.item_t1 != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = item_t1.icon;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // If the item exists, allow you to click it and drag it.
        if (this.item_t1 != null)
        {
            if (selectedItem.item_t1 != null)
            {
                Item_T1 newItem = new Item_T1(selectedItem.item_t1);
                selectedItem.UpdateItem(this.item_t1);
                UpdateItem(newItem);
            }
            else
            {
                selectedItem.UpdateItem(this.item_t1);
                UpdateItem(null);
            }
        }
        else if (selectedItem.item_t1 != null)
        {
            UpdateItem(selectedItem.item_t1);
            selectedItem.UpdateItem(null);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.item_t1 != null)
        {
            tooltip.GenerateTooltip(this.item_t1);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
