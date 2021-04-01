using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Joystick joystick;
    public float Speed;
    float Move_X, Move_Y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move_();
    }
    private void FixedUpdate()
    {
        MoveMent(new Vector2(Move_X,Move_Y));
    }
    void Move_()
    {
        if (joystick.Horizontal >= .2f)
        {
            Move_X = Speed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            Move_X = -Speed;
        }
        else
        {
            Move_X = 0;

        }
        /////////////////////////////////////
        if (joystick.Vertical >= .2f)
        {
            Move_Y = Speed;
        }
        else if (joystick.Vertical <= -.2f)
        {
            Move_Y = -Speed;
        }
        else
        {
            Move_Y = 0;

        }
    }
    public void MoveMent(Vector2 XY)
    {      
      rb2D.MovePosition((Vector2)transform.position + ( XY *Speed * Time.deltaTime));
       
    }
}
