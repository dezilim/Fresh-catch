using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Collidable
{

    protected bool interacted;
    // This ensures that this script is only for player to object interaction. 
    protected override void OnCollide(Collider2D coll)
    {
        Debug.Log("INTERACTABLE");
        // if you meet the player, you want the player to have you. We are a collectable. 
        if (coll.name == "Player"){
            Debug.Log("INTERACTING WITH PLAYER");
            if (Input.GetMouseButtonDown(0)){
                OnInteract();
            }
            
        }
    }
    // This is only ever called if is player interacting with this. 
    protected virtual void OnInteract()
    {
        interacted = true;
        Debug.Log("Default Interactable");

    }
}
