using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Item> itemList; 

    // basic constructor
    public Inventory(){
        itemList = new List<Item>();
        // AddItem(new Item {itemType = Item.ItemType.BlueFish, amount = 1});
        // AddItem(new Item {itemType = Item.ItemType.YellowFish, amount = 1});
        // AddItem(new Item {itemType = Item.ItemType.GreenFish, amount = 1});


    }
        // Start is called before the first frame update
    public void AddItem(Item item){
        bool itemInInventory = false;
        foreach(Item inventoryItem in itemList){
            if (item.itemType == inventoryItem.itemType) {
                inventoryItem.amount += item.amount;
                itemInInventory = true;
            }
        }
        if (!itemInInventory){
            itemList.Add(item);
        }
        

    }
    // we use this when your itemList is currently private. Use to expose the itemlist 
    public List<Item> GetItemList(){
        return itemList;
    }
}
