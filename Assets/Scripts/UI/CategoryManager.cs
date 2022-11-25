using System.Collections.Generic;
using Inventory.Model;
using Inventory.UI;
using UnityEngine;
using UnityEngine.UI;

public class CategoryManager : MonoBehaviour
{

    // [SerializeField] private Button[] categoryButtons;

    [SerializeField] private GridLayoutGroup inventoryGridContainer;
    [SerializeField] private InventorySO inventorySO;

    private int numberOfItemsInInventoryCategory;
    
    [SerializeField] private EquippableItemSO _swordSOType;
    [SerializeField] private EquippableItemSO _axeSOType;
    [SerializeField] private EdibleItemSO _potionSOType;
    

    private List<ItemSO> _axeItems = new List<ItemSO>();
    private List<ItemSO> _swordItems = new List<ItemSO>() ;
    private List<ItemSO> _potionItems = new List<ItemSO>();
    
    [SerializeField] private Sprite categoryInactive;
    [SerializeField] private Sprite categoryActive;
    
    [SerializeField] private UIInventoryItem[] itemButtons;
    [SerializeField] private Button[] paginatonButtons;

    public enum CateogryEnum
    {
        Sword,
        Axe,
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
            categoryListItem.CategoryButton.onClick.AddListener( () => CategorySelected(categoryListItem));
        }

        CategorizePlayerItems();
        CategorySelected(CategoryList[0]);
    }

    private void CategorySelected(CategoryClass selectedCategoryClass)
    {
        CateogryEnum selectedCategory;
        ItemSO[] categoryItems;
       
        for (int i = 0; i < CategoryList.Count; i++)
        {
            if (CategoryList[i] == selectedCategoryClass) {
                selectedCategoryClass.CategoryButton.image.sprite = categoryActive;
                selectedCategoryClass.CategoryButton.interactable = false;

                selectedCategory = selectedCategoryClass.CateogryEnum;

                bool shouldCheckPagination = true;
                
                switch (selectedCategory)
                {
                    case CateogryEnum.Sword:
                        PopulateInventoryCells(_swordItems);
                        break;
                    case CateogryEnum.Axe:
                        PopulateInventoryCells(_axeItems);
                        break;
                    case CateogryEnum.Potion:
                        print(_potionItems.Count);
                        PopulateInventoryCells(_potionItems);
                        break;
                    default:
                        shouldCheckPagination = false;
                        break;
                }

                if (shouldCheckPagination)
                {
                    
                }
            }
            else
            {
                CategoryList[i].CategoryButton.interactable = true;
                CategoryList[i].CategoryButton.image.sprite = categoryInactive;
            }
        }
    }

    // TODO - Should be called whenever the Inventory is opened
    private void CategorizePlayerItems()
    {
        foreach (var inventoryItem in inventorySO.inventoryItems)
        {
            switch (inventoryItem.item)
            {
                case EquippableItemSO:
                    print("Getting Equipable Item");
                    if (inventoryItem.item == _swordSOType)
                    {
                        _swordItems.Add((EquippableItemSO) inventoryItem.item);
                    } else if (inventoryItem.item == _axeSOType)
                    {
                        _axeItems.Add((EquippableItemSO) inventoryItem.item);
                    }
                    break;
                case EdibleItemSO:
                    print("Getting Edible Item");
                    print(inventoryItem.quantity);
                    _potionItems.Add((EdibleItemSO) inventoryItem.item);
                    break;
                default:
                    print("No Item found");
                    break;
            }
        }
    }

    // TODO - Should be called whenever the Inventory is opened + When the player changes the Inventory Category 
    private void PopulateInventoryCells(List<ItemSO> items)
    {
        foreach (var itemButton in itemButtons)
        {
            itemButton.ClearData();
        }
        
        for (int i = 0; i < items.Count; i++)
        {
            itemButtons[i].SetData(items[i].ItemImage, items[i].IsStackable, 0);
        }
        
        CheckPagination(items);
    }
    
    private void CheckPagination(List<ItemSO> itemList)
    {
        foreach (Button paginatonButton in paginatonButtons)
        {
            CanvasGroup paginationCanvasGroup = paginatonButton.GetComponent<CanvasGroup>();
            paginationCanvasGroup.alpha = 0;
            paginationCanvasGroup.interactable = false;
            paginationCanvasGroup.blocksRaycasts = false;
        }

        int inventoryContentGridSize = 21;
        int paginationAmount = Mathf.FloorToInt(itemList.Count / inventoryContentGridSize);

        if (paginationAmount > 1)
        {
            for (int i = 0; i < paginationAmount; i++)
            {
                CanvasGroup paginationCanvasGroup = paginatonButtons[i].GetComponent<CanvasGroup>();
                paginationCanvasGroup.alpha = 1;
                paginationCanvasGroup.interactable = true;
                paginationCanvasGroup.blocksRaycasts = true;
            }
        }
        
    }

    // private void FindItemsInInventory(CateogryEnum ateogryEnum)
    // {
    //
    //     int paginationAmount;
    //     
    //     switch (selectedCategory.CateogryEnum)
    //     {
    //         case CateogryEnum.Sword:
    //             paginationAmount = Mathf.FloorToInt(_swordItems.Count / 2);
    //             
    //             ShowPagination(paginationAmount);
    //             
    //             break;
    //         case CateogryEnum.Potion:
    //             break;
    //     }
    // }

    private void ShowPagination(int paginationAmount)
    {
        for (int i = 0; i < paginationAmount; i++)
        {
            CanvasGroup paginationCanvasGroup = paginatonButtons[i].GetComponent<CanvasGroup>();
            paginationCanvasGroup.alpha = 1;
            paginationCanvasGroup.interactable = true;
            paginationCanvasGroup.blocksRaycasts = true;
        }
    }


}
