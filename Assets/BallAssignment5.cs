using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAssignment5 : ProcessingLite.GP21
{
    public float diameter;
    public float diaHalfWidth;
    public float diaHalfHeight;
    public Vector2 position;
    public Vector2 velocity;
    public int r;
    public int g;
    public int b;

    public BallAssignment5()
    {
        position = new Vector2(Width / 2, Height / 2);
        diameter = Random.Range(0.5f, 2.0f);
        diaHalfWidth = diameter / 2;
        diaHalfHeight = diameter / 2;

        velocity = new Vector2(Random.Range(-0.0035f, 0.0035f), Random.Range(-0.0035f, 0.0035f));

        r = Random.Range(0, 255);
        g = Random.Range(0, 255);
        b = Random.Range(0, 255);
    }

    public void Draw()
    {
        Fill(r, g, b);
        Circle(position.x, position.y, diameter);
    }

    public void Movement()
    {
        position += velocity;
    }

    public void Boundary()
    {
        if (position.x < 0 + diaHalfWidth || position.x > Width - diaHalfWidth)
        {
            velocity.x *= -1;
        }
        if (position.y < 0 + diaHalfHeight || position.y > Height - diaHalfHeight)
        {
            velocity.y *= -1;
        }
    }
}
