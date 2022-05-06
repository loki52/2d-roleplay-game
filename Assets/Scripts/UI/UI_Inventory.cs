using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private InventoryObj playerInventory;

    private Transform slotContainer;
    private Transform slotTemplate;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        slotContainer = transform.Find("itemSlotContainer");
        slotTemplate = slotContainer.Find("itemSlotTemplate");
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void SetInventory(InventoryObj inventory)
    {
        playerInventory = inventory;
        FindInventoryItems();
    }

    private void FindInventoryItems()
    {
        //find and implement inventory items into the UI
        FillInventory();
        int itemSlotx = 0;
        int itemSloty = 0;
        float itemSlotCellSize = 115f;
        foreach (InventoryItem invItem in playerInventory.inventoryList)
        {
            Transform slotTransform = Instantiate(slotTemplate, slotContainer);
            RectTransform slotRectTransform = slotTransform.GetComponent<RectTransform>();
            //instantiates a new slot template and container and gets the RectTransform

            slotRectTransform.anchoredPosition = new Vector2(itemSlotx * itemSlotCellSize, itemSloty);
            //Anchors the new slot 115 units 

            Image itemImage = slotRectTransform.Find("itemImage").GetComponent<Image>();
            itemImage.sprite = invItem.item.itemIcon;
            Text itemQuantity = slotRectTransform.Find("itemQuantity").GetComponent<Text>();

            slotRectTransform.gameObject.SetActive(true);

            if (invItem.amount > 1)
            {
                itemQuantity.text = invItem.amount.ToString();
            }

            itemSlotx++;
        }
    }

    private void FillInventory()
    {
        //fill inventory with empty frames first
        int i = 1;
        int emptySlotx = 0;
        int emptySloty = 0;
        float itemSlotCellSize = 115f;
        while (i <= playerInventory.InventorySize)
        {
            Transform slotTransform = Instantiate(slotTemplate, slotContainer);
            RectTransform slotRectTransform = slotTransform.GetComponent<RectTransform>();

            slotRectTransform.gameObject.SetActive(true);
            slotRectTransform.anchoredPosition = new Vector2(emptySlotx * itemSlotCellSize, emptySloty);
            Transform imageTransform = slotRectTransform.Find("itemImage");
            imageTransform.gameObject.SetActive(false);
            Transform imageBackground = slotRectTransform.Find("Background");
            imageBackground.gameObject.SetActive(false);

            emptySlotx++;

            i++;
        }
    }

    public void ShowInventory()
    {
        this.gameObject.SetActive(true);
        audioManager.Play("OpenInventory");
    }

    public void HideInventory()
    {
        this.gameObject.SetActive(false);
        audioManager.Play("CloseInventory");
    }

}
