using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody2D;
    public KeyCode upKey;
    public KeyCode downKey;
    public Color playerColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();  
        spriteRenderer.color = playerColor;
       
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(upKey))
        {

            rigidBody2D.velocity = Vector2.up;

        }else if(Input.GetKey(downKey))
        {

            rigidBody2D.velocity = Vector2.down;

        }
        else
        {

            rigidBody2D.velocity = Vector2.zero;

        }


    }
}
