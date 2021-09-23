using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment3Vectors : ProcessingLite.GP21
{
    Vector2 circlePos;
    float diameter = 1.0f;
    public Vector2 velocity;
    float maxSpeed = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        circlePos = new Vector2(Width / 2, Height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Background(155);
        NoFill();
        Circle(circlePos.x, circlePos.y, diameter);

        if (Input.GetMouseButtonDown(0))
        {
            circlePos.x = MouseX;
            circlePos.y = MouseY;
            velocity *= maxSpeed;
        }

        if (Input.GetMouseButton(0))
        {
            Line(circlePos.x, circlePos.y, MouseX, MouseY);
        }

        if (Input.GetMouseButtonUp(0))
        {
            velocity = new Vector2(MouseX - circlePos.x, MouseY - circlePos.y);
        }

        if (velocity.magnitude > maxSpeed)
        {
            velocity.x = Mathf.Clamp(velocity.x,-maxSpeed, maxSpeed);
            velocity.y = Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed);
        }

        circlePos += velocity * Time.deltaTime;

        Bounce();
    }

    private void Bounce()
    {
        if (circlePos.x > Width || circlePos.x < 0)
        {
            velocity.x *= -1;
        }
        if (circlePos.y > Height || circlePos.y < 0)
        {
            velocity.y *= -1;
        }
    }
}
