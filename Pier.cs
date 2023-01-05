using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pier : MonoBehaviour
{

    public static int nb_fish; 
    public static int nb_stone; 
    public static int nb_drink;
    public static bool inRedZone; 
    public static bool stealing; 
    
    public float time;
    public float roundedTime;
    public float colorValue;

    public Text nb_fish_text, nb_stone_text, time_text;
    public Text blue_text, yellow_text, green_text, coin_text; 

    public GameObject[] skies;


    // shooting stones
    public bool isDragging;
    public SpriteRenderer aiming_sprite;
    public GameObject stoneGO, aimingGO;
    public Vector3 mousePosition;


    // Start is called before the first frame update
    void Start()
    {
        nb_fish = 0;
        nb_stone = 0;
        nb_drink = 0;
        inRedZone = false; 

        isDragging = false;
        aiming_sprite = aimingGO.GetComponent<SpriteRenderer>();

        time = 0f; 

        // foreach(GameObject obj in skies){
        //     obj.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        // }
        // Debug.Log("change time");
    }

    void endGame(){
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        roundedTime = Mathf.Floor(time);
        
        colorValue = 1f-time* 0.02f;
        if (colorValue < 0.01f){
            endGame();
        }
        foreach(GameObject obj in skies){
            obj.GetComponent<SpriteRenderer>().color = new Color(colorValue,colorValue,colorValue);
        }
        // Debug.Log("change time");

        time_text.text = roundedTime.ToString();
        nb_fish_text.text = nb_fish.ToString();
        nb_stone_text.text = nb_stone.ToString();


        Debug.Log(isDragging);
        if (Input.GetMouseButtonDown(1)){

            
            aiming_sprite.enabled = true; 
            aimingGO.transform.position = new Vector3(mousePosition.x, mousePosition.z, 1f);

            isDragging = true; 
            // mousePosition = Input.mousePosition;
            // mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            
            // aimingGO.transform.position = mousePosition;
            // Instantiate(stoneGO, mousePosition, Quaternion.identity);

        }
        if (Input.GetMouseButtonUp(1)){
            isDragging = false; 
            aiming_sprite.enabled = false; 
            if (nb_stone > 0){
                Instantiate(stoneGO, new Vector3(mousePosition.x, mousePosition.y, 0f), Quaternion.identity);
                nb_stone -= 1;
            }
            
        }
        if (isDragging){
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            aimingGO.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
            

        }
    }

}
