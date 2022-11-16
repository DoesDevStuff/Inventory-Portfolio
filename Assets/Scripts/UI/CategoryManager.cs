using System.Collections.Generic;
using Inventory.Model;
using UnityEngine;
using UnityEngine.UI;

public class CategoryManager : MonoBehaviour
{

    // [SerializeField] private Button[] categoryButtons;

    [SerializeField] private GridLayoutGroup inventoryGridContainer;
    [SerializeField] private InventorySO inventorySO;

    private List<EquippableItemSO> _equippableItemsInInventory;
    private List<EdibleItemSO> _edibleItemsInInventory;
    
    public enum CateogryEnum
    {
        Sword,
        Potion
    }

    [System.Serializable]
    public class CategoryClass
    {
        public CateogryEnum CateogryEnum;
        public Button CategoryButton;
        // public 
    }

    public List<CategoryClass> CategoryList = new List<CategoryClass>();

    private void Start()
    {
        foreach (var categoryListItem in CategoryList)
        {
            categoryListItem.CategoryButton.onClick.AddListener( () => CategorySelected(categoryListItem.CateogryEnum));
        }
    }

    private void CategorySelected(CateogryEnum categoryEnum)
    {
        print( categoryEnum +" was selected");
        
        // TODO - Set as active category button (visual)
        // TODO - Unset the previous active category button (visual)
        // TODO - Clear the existing Inventory Grid
        // TODO - Call PopulateInventoryCells() with the associated category type, from the categoryEnum
        // TODO - Based on that category's List that's associated with that
    }

    // TODO - Should be called whenever the Inventory is opened
    private void CategorizePlayerItems()
    {
        foreach (var inventoryItem in inventorySO.inventoryItems)
        {
            // print(inventoryItem.item);
            switch (inventoryItem.item)
            {
                case EquippableItemSO:
                    print("Getting Equipable Item");
                    _equippableItemsInInventory.Add((EquippableItemSO) inventoryItem.item);
                    break;
                case EdibleItemSO:
                    _equippableItemsInInventory.Add((EquippableItemSO) inventoryItem.item);
                    print("Getting Edible Item");
                    break;
                default:
                    print("No Item found");
                    break;
            }
        }
    }

    // TODO - Should be called whenever the Inventory is opened + When the player changes the Inventory Category 
    private void PopulateInventoryCells()
    {
        
        
        
        // Instantie into inventoryGridContainer here   
    }


}
