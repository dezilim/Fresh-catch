using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // NPC STUFF
    public bool isAngry;
    public SpriteRenderer sprite;
    public ParticleSystem die;
    public float delay = 2f;

    public Animator animator;

    // PLAYER STUFF
    public GameObject playerGO, cage, thisCage;
    public Vector3 playerPos, newPos;


    public float[] choices = {-1,1};
    public float transitionSpeed = 5f;
    public float deltaX;
    // Start is called before the first frame update
    void Start()
    {
        isAngry = false; 
        StartCoroutine(InfiniteWander(8f));
    }


// I dont understand sia 
//  help 

    IEnumerator InfiniteWander(float waitingTime){
        while(true){
            StartCoroutine(Walk());
            yield return new WaitForSeconds(waitingTime);
            
        }
    }

    IEnumerator Walk(){
        animator.SetBool("isWalking", true);
        float walkTime = 2f;
        // float walkTime = Random.Range(1f, 4f);
        int rando = (int)Random.Range(0,2);
        float dir = choices[rando];
        if (dir < 0){
            sprite.flipX = true; 

        }
        else if (dir > 0){
            sprite.flipX = false;
        }


        while (walkTime > 0){
            Debug.Log("Walking");
            transform.Translate(Vector2.right * dir  * Time.deltaTime * transitionSpeed/2);
            walkTime -= Time.deltaTime;
            yield return null;
        }
        animator.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Pier.stealing){
            isAngry = true;
            animator.SetBool("isAngry", isAngry);
            playerPos = playerGO.transform.position; 
            newPos = new Vector3(playerPos.x, transform.position.y, transform.position.z);
            deltaX = newPos.x - transform.position.x; 

            if (deltaX < 0){
                sprite.flipX = true; 

            }
            else if (deltaX > 0){
                sprite.flipX = false;
            }
            // we want if it's not chasing to be showing the idle anim! 
            if (Mathf.Abs(deltaX) < 1f){
                Debug.Log("Cat caught!");
                playerGO.GetComponent<Player>().enabled = false; 
                thisCage = Instantiate(cage, playerPos, Quaternion.identity);
                thisCage.transform.parent = playerGO.transform;
                
                // reset as we have done what is neccessary.
                Pier.stealing = false; 

            }
            // LERP IS BEING WEIRD AND CHUNKY 
            // transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * transitionSpeed);
            // transform.position = new (deltaX/(Math.Abs(deltaX))*Time.deltaTime , 0f);
            transform.Translate(Vector2.right *deltaX/(Mathf.Abs(deltaX))  * Time.deltaTime * transitionSpeed);
        }
        else {
            isAngry = false; 
            animator.SetBool("isAngry", isAngry);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Stone"){
            // ?Pier.nb_stone -= 1;
            // ParticleSystem ps = Instantiate(die, transform.position, Quaternion.identity);
            die.Play();
            Destroy(other.gameObject);
            Destroy(gameObject, 1f);
        }
    }


  
}
