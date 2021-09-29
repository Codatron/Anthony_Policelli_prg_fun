using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssignment5 : ProcessingLite.GP21
{
    public Vector2 position;
    public Vector2 velocity;
    public Vector2 acceleration;
    public Vector2 deceleration;
    public float diameter;
    public float diaHalfWidth;
    public float diaHalfHeight;
    public float speed = 10.0f;
    public float maxSpeed = 10.0f;
    public Color playerColour;

    public PlayerAssignment5(Color playerColour, float diameter)
    {

        position = new Vector2(0 + 1, Height / 2);

        this.diameter = diameter;
        diaHalfWidth = diameter / 2;
        diaHalfHeight = diameter / 2;
    }
    public void Draw()
    {
        Stroke(235);
        StrokeWeight(0.5f);
        //Fill(100, 58, 35);
        NoFill();
        Circle(position.x, position.y, diameter);
        Stroke(1);
    }
    public void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        acceleration = new Vector2(x, y);
        deceleration = new Vector2(0.99f, 0.99f);
        velocity += acceleration * Time.deltaTime;

        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        else if (acceleration == Vector2.zero && velocity.magnitude > 0)
        {
            velocity *= deceleration;
        }
        position += velocity;
    }
    public void Boundary()
    {
        if (position.x < 0 + diaHalfWidth)
        {
            position.x = 0 + diaHalfWidth;
        }
        if (position.x > Width - diaHalfWidth)
        {
            position.x = Width - diaHalfWidth;
        }
        if (position.y < 0 + diaHalfHeight)
        {
            position.y = 0 + diaHalfHeight;
        }
        if (position.y > Height - diaHalfHeight)
        {
            position.y = Height - diaHalfHeight;
        }
    }
}
