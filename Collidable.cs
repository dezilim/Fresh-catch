using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    public BoxCollider2D boxCollider;
    // this is how many objects u can "collide" with at a given moment 
    private Collider2D[] hits = new Collider2D[8];


    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Collision work. This takes the box collider on this script and check what is overlapping with it
        boxCollider.OverlapCollider(filter, hits);
        // hits now contains all the colliders that are colliding with THIS 
        for (int i = 0; i < hits.Length; i++){
            if (hits[i] == null){
                // when nothing inside 
                continue;
            }
            // ONCE WE GET ALL THE STUFF, we need to call oncollide.
            OnCollide(hits[i]);
            // Debug.Log(hits[i].name);
            // clean up the array. 
            hits[i] = null;
        }
    }

    // virtual so that we can overwrite the function from another script. 
    protected virtual void OnCollide(Collider2D coll){
        // name of object we are colliding with
        // THIS IS NOT BEING CALLED 
        Debug.Log(coll.name);
        // if (coll.name == "Player"){
        //     Destroy(gameObject);
        // }
    }
}
