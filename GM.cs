using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{


    public static int chosen_player_skin;
    public static GameObject[] player_prefab_list;

    public static int nb_fish, nb_drink;



    public Vector2 home_respawn_point;
    public Vector2 pier_respawn_point; 
    // Start is called before the first frame update
    void Start()
    {
        // the game starts with a cutscene. 
        // then, you get to choose a player. 
        // we wanna spawn the player first. There will be a respawn point? for both the home and pier scene. 
        chosen_player_skin = 0;
        nb_fish = 0; 
        nb_drink = 0;


        // respawn points
        Instantiate(player_prefab_list[0], home_respawn_point, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
