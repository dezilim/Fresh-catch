using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public GameObject Player; 
    public Rigidbody2D rb;
    public Vector2 home_respawn_point;

    // Start is called before the first frame update
    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
        // rb.gravityScale = 0; 
        Instantiate(Player, home_respawn_point, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
