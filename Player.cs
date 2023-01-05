using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public UI_Inventory uiInventory;
    public static bool toRefresh;

    private float moveSpeed = 200f;
    private float jumpSpeed = 250f;
    public float distToGround;


    public Vector3 raycastOffset;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sprite;
    public static Inventory inventory;

    Vector2 movement;
    public Vector2 jumpHeight; 

    public bool isJumping; 
    public bool isSitting;
    public static bool isInteracting; 

    // note: detect all input keys using update funcction, instead of fixedupdate or triggers, as they are not called every frame.
    // UPDATE TO FIX 
    // =========================
    // - LERP IS BEING WEIRD AND CHUNKY in NPC
    // - ground detection is all fucked up lol

    void Start(){
        isJumping = false; 
        isSitting = false;
        isInteracting = false;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        toRefresh = false;
    }
    // Start is called before the first frame update
    void Update()
    {
        Debug.Log(inventory.itemList.Count);
        
        
        movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
        movement.y = 0;
        animator.SetFloat("Speed", Mathf.Pow(movement.x,2) + Mathf.Pow(movement.y,2));
        animator.SetBool("isJumping", false);
        // animator.SetBool("isSitting", isSitting);


        if (movement.x < 0){
            sprite.flipX = true;
        }
        else if (movement.x > 0){
            sprite.flipX = false;
        }
        // key detection must be in update instead of fixedupdate
        // isJumping = Input.GetButtonDown("Jump");
        if (Input.GetButtonDown("Jump") && (transform.position.y < -3f)){
            Debug.Log("Jump key pressed");
            isJumping = true;
            animator.SetBool("isJumping", true);
            // rb.velocity = Vector2.up * jumpSpeed * Time.deltaTime ; 
        }
        // rb.velocity = new Vector2(movement.x * moveSpeed * Time.deltaTime, rb.velocity.y);
        if (Input.GetButtonUp("Jump")){
            isJumping = false;
        }
        
        if (Input.GetKeyDown(KeyCode.E)){
            isSitting = !isSitting;
            animator.SetBool("isSitting", isSitting);
        }
        // animator.SetBool("isSitting", isSitting);
        
        if (toRefresh){
            uiInventory.RefreshInventoryItems();
            toRefresh = false;
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // rb.MovePosition(rb.position + movement * moveSpeed *Time.fixedDeltaTime);
        // rb.velocity += jumpPressed * Vector2.up * jumpSpeed; 

        // if (isJumping){
        //     rb.velocity = Vector2.up * jumpSpeed * Time.deltaTime ; 
        // }
        rb.velocity = new Vector2(movement.x * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        if (isJumping){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * Time.fixedDeltaTime);
        }

    }
    // public static void RefreshInventory(){
    //     uiInventory.RefreshInventoryItems();
    // }
    
}
