using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Container : MonoBehaviour
{

    [SerializeField] public Player player;

    private InventoryObj containerInventory;

    private Transform slotContainer;
    private Transform slotTemplate;

    private Button exitButton;

    private GameObject chestGameObject;

    private UnityAction stopInteractingAction;

    public string containerName;



    private void Awake()
    {
        slotContainer = transform.Find("itemSlotContainer");
        slotTemplate = slotContainer.Find("itemSlotTemplate");
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void SetInventory(InventoryObj inventory, string name)
    {
        containerInventory = inventory;
        containerName = name;
        Text containerText = transform.Find("ContainerText").GetComponent<Text>();
        containerText.text = containerName;
        FindChestItems();
    }

    private void FindChestItems()
    {
        //find and implement inventory items into the UI
        FillInventory();
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 115f;
        foreach (InventoryItem invItem in containerInventory.inventoryList)
        {
            RectTransform slotRectTransform = Instantiate(slotTemplate, slotContainer).GetComponent<RectTransform>();
            slotRectTransform.gameObject.SetActive(true);
            slotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            Image itemImage = slotRectTransform.Find("itemImage").GetComponent<Image>();
            itemImage.sprite = invItem.item.itemIcon;
            Text itemQuantity = slotRectTransform.Find("itemQuantity").GetComponent<Text>();
            if (invItem.amount > 1)
            {
                itemQuantity.text = invItem.amount.ToString();
            }

            x++;
            if (x > containerInventory.InventorySize)
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
        while (i <= containerInventory.InventorySize)
        {
            RectTransform slotRectTransform = Instantiate(slotTemplate, slotContainer).GetComponent<RectTransform>();
            slotRectTransform.gameObject.SetActive(true);
            slotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Transform imageTransform = slotRectTransform.Find("itemImage");
            imageTransform.gameObject.SetActive(false);
            Transform imageBackground = slotRectTransform.Find("Background");
            imageBackground.gameObject.SetActive(false);
            x++;
            if (x > containerInventory.InventorySize)
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
