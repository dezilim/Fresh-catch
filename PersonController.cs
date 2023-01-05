using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Red zone:",Pier.inRedZone);
        if (Pier.inRedZone){
            if (Input.GetMouseButtonDown(0)){
                Pier.stealing = true; 
            }
        }
        // Pier.stealing can be set false when cat is caught by npc. 
        animator.SetBool("stealing", Pier.stealing);
    }


    void OnTriggerStay2D(Collider2D other){
        if (other.tag == "Player"){
            Debug.Log("PLAYER IN ZONE");
            Pier.inRedZone = true; 
            // if (Input.GetMouseButtonDown(0)){
            //     stealing = true; 
            //     Debug.Log("Stealing!");
            //     animator.SetBool("stealing", true);
            // }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player"){
            Pier.inRedZone = false;
            if (Pier.stealing){
                Pier.stealing = false;
                // animator.SetBool("stealing", false);
            }
        }   
    }
}
