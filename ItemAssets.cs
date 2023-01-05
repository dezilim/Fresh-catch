using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {get; private set;}

    private void Awake(){
        Instance = this;
    }

    public Sprite spr_BlueFish;
    public Sprite spr_YellowFish;
    public Sprite spr_GreenFish;
    public Sprite spr_Coins;
}
