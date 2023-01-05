using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{

    // protected means that only you and your children can see. 
    protected bool collected; 
    // Start is called before the first frame update
    protected override void OnCollide(Collider2D coll)
    {
        // Debug.Log("COLLECTABLE");
        // if you meet the player, you want the player to have you. We are a collectable. 
        if (coll.name == "Player"){
            Debug.Log("COLLECTING BY PLAYER");
            OnCollect();
        }
    }

    // Update is called once per frame
    protected virtual void OnCollect()
    {
        Debug.Log("Default Collectable");
        // Player.isInteracting = true; 
        collected = true; 

        if (gameObject.tag == "Stone"){
            Pier.nb_stone += 1;
            Debug.Log("stone += 1");
        }
        else{
            Item thisItem = GetComponent<Item>();
            Debug.Log(thisItem.itemType);
            Debug.Log(thisItem.amount);
            if (thisItem != null){
                Debug.Log("ADD ITEM");
                Player.inventory.AddItem(thisItem);
                // Player.RefreshInventory();
                Player.toRefresh = true;
            }    
        }
        Destroy(gameObject);
    }
}
