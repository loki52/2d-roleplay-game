using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Chest : MonoBehaviour
{

    [SerializeField] public Player player;

    private Inventory chestInventory;

    private Transform slotContainer;
    private Transform slotTemplate;

    private Button exitButton;

    private GameObject chestGameObject;

    private UnityAction stopInteractingAction;



    private void Awake()
    {
        slotContainer = transform.Find("itemSlotContainer");
        slotTemplate = slotContainer.Find("itemSlotTemplate");
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void SetInventory(Inventory inventory)
    {
        chestInventory = inventory;
        FindChestItems();
    }

    private void FindChestItems()
    {
        //find and implement inventory items into the UI
        FillInventory();
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 115f;
        foreach (Item item in chestInventory.inventoryList)
        {
            RectTransform slotRectTransform = Instantiate(slotTemplate, slotContainer).GetComponent<RectTransform>();
            slotRectTransform.gameObject.SetActive(true);
            slotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            Image itemImage = slotRectTransform.Find("itemImage").GetComponent<Image>();
            itemImage.sprite = item.GetIcon();

            x++;
            if (x > chestInventory.InventorySize)
            {
                x = 0;
                y++;
            }

        }
    }

    private void FillInventory()
    {
        //fill inventory with empty frames first
        int i = 1;
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 115f;
        while (i <= chestInventory.InventorySize)
        {
            RectTransform slotRectTransform = Instantiate(slotTemplate, slotContainer).GetComponent<RectTransform>();
            slotRectTransform.gameObject.SetActive(true);
            slotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Transform imageTransform = slotRectTransform.Find("itemImage");
            imageTransform.gameObject.SetActive(false);
            Transform imageBackground = slotRectTransform.Find("Background");
            imageBackground.gameObject.SetActive(false);
            x++;
            if (x > chestInventory.InventorySize)
            {
                x = 0;
                y++;
            }
            i++;
        }
    }

    public void ShowInventory()
    {
        this.gameObject.SetActive(true);
    }

    public void HideInventory()
    {
        this.gameObject.SetActive(false);
    }

}
