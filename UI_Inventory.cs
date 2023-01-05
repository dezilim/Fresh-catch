using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public Inventory inventory; 

    
    // these are two empty objects as the basis for our container and the template item
    public Transform itemSlotContainer, itemSlotTemplate;
    // take the inventory from player. 


    private void Awake(){
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }
    public void SetInventory(Inventory inventory){
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems() {
        foreach (Transform child in itemSlotContainer){
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 200f;
        foreach(Item item in inventory.GetItemList()){
            Debug.Log("Going through item list");

            // Debug.Log(item.itemType);
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x* itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Button").GetComponent<Image>();
            image.sprite = item.GetSprite();

            Text thisText = itemSlotRectTransform.Find("ButtonText").GetComponent<Text>();
            thisText.text = item.amount.ToString();
            // switch (item.itemType){
            //     default:
            //     case item.ItemType.BlueFish:     image.sprite = spr_BlueFish;
            //     case item.ItemType.YellowFish:   image.sprite = spr_YellowFish;
            //     case item.ItemType.GreenFish:    image.sprite = spr_GreenFish;
            //     case item.ItemType.Coins:        image.sprite = spr_Coins;
            // }
            
            x++;
            if ( x > 4){
                x = 0; 
                y ++;
            }
        
        }
    }
}
