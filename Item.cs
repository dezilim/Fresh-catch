using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
    public enum ItemType {
        Stone,
        BlueFish,
        YellowFish,
        GreenFish,
        Coins,
    }

    public ItemType itemType; 
    public int amount; 

    public Sprite GetSprite(){
            switch (itemType){
            default:
            case ItemType.BlueFish:     return ItemAssets.Instance.spr_BlueFish;
            case ItemType.YellowFish:   return ItemAssets.Instance.spr_YellowFish;
            case ItemType.GreenFish:    return ItemAssets.Instance.spr_GreenFish;
            case ItemType.Coins:        return ItemAssets.Instance.spr_Coins;
        }
    }

}
