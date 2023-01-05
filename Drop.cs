using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Drop : Collectable : Collidable : Monobehaviour
// Collectable has boolean collected
public class Drop : Interactable
{
    public SpriteRenderer spriteRenderer;
    public Sprite emptySprite;



    protected override void OnInteract(){
        // can still call the original function by using base.OnCollide(coll)
        // this is to make sure the collected = true. can also call base.OnCollect();
        if (!interacted){
            
            
            interacted = true; 
            // GM.nb_drops += 1;
            Debug.Log("Get Drop");
                // Debug.Log("Total drops: " + GM.nb_drops);
                // drop logic
                // Destroy(gameObject);
            OnPickUp(); 
        }

    
    }

    void ChangeSprite(){
        spriteRenderer.sprite = emptySprite;
    }

    protected virtual void OnPickUp()
    {
        Debug.Log("ADD ITEM");

        if (gameObject.tag == "Stone"){
            Pier.nb_stone += 1;
            Debug.Log("stone += 1");
            Destroy(gameObject);
        }
        else{
            ChangeSprite();
            base.boxCollider.enabled = false;


            Item thisItem = GetComponent<Item>();
            if (thisItem != null){
                Debug.Log("ADD ITEM");
                Player.inventory.AddItem(thisItem);
                // Player.RefreshInventory();
                Player.toRefresh = true;
            }    
        }
        // Player.isInteracting = false; 
    }


}
