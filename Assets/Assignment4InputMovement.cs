using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4InputMovement : ProcessingLite.GP21

{
    Vector2 posP1;
    Vector2 posP2;
    float diameter = 1.0f;

    Vector2 velocityP1;
    Vector2 velocityP2;
    Vector2 acceleration;
    Vector2 deceleration;
    Vector2 gravity;
    
    float speed = 5.0f;
    float maxSpeed = 0.05f;

    bool isGravityOn = false;
    float gravityForce = 10f;


    // Start is called before the first frame update
    void Start()
    {
        // Start position player 1
        posP1 = new Vector2((Width / 2) - 2, (Height / 2));

        // Start position player 2
        posP2 = new Vector2((Width / 2) + 2, (Height / 2));
    }

    // Update is called once per frame
    void Update()
    {

        Background(50);

        // Player 1 
        //Fill(0, 0, 255);
        //StrokeWeight(0.25f);
        //player1Movement();
        //Circle(posP1.x, posP1.y, diameter);

        //Player 2
        Fill(255, 0, 0);
        StrokeWeight(0.25f);
        Circle(posP2.x, posP2.y, diameter);

        gravity = new Vector2(0f, gravityForce);
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            // This acts as a toggle
            isGravityOn = !isGravityOn;
        }

        if (isGravityOn)
        {
            if (posP2.y < 0)
            {
                velocityP2.y += 1;
            }

            posP2.y -= gravity.y * Time.deltaTime;
        }
        else
        {
            isGravityOn = isGravityOn;
            ScreenWrap();
        }

        player2Movement();
    }

    private void player1Movement()
    {
        float xP1 = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float yP1 = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        posP1 += new Vector2(xP1, yP1);
    }

    private void player2Movement()
    {
        float xP2 = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float yP2 = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        // Acceleration is controlled by inputs
        acceleration = new Vector2(xP2, yP2);
        velocityP2 += acceleration * Time.deltaTime;

        // Control amount of decelaration and gravity
        deceleration = new Vector2(0.99f, 0.99f);

        if (velocityP2.magnitude > maxSpeed)
        {
            velocityP2 = velocityP2.normalized * maxSpeed;
        }
        else if (acceleration == Vector2.zero && velocityP2.magnitude > 0)
        {
            velocityP2 *= deceleration;
        }

        posP2 += velocityP2;
    }

    private void ScreenWrap()
    {
        // Player 1
        posP1.x = (posP1.x + Width) % Width;
        posP1.y = (posP1.y + Height) % Height;

        // Player 2
        posP2.x = (posP2.x + Width) % Width;
        posP2.y = (posP2.y + Height) % Height;
    }
}


// ************************* CODE BEFORE LESSON **************************
//{
//    Vector2 posP1;
//    Vector2 posP2;
//    float diameter = 1.0f;

//    float velocityP1 = 10.0f;
//    float newVelocityP1;
//    float velocityP2 = 1.0f;
//    float newVelocityP2;
//    float maxSpeed = 10.0f;
//    float acceleration = 2.0f;

//    float xAxisP1;
//    float yAxisP1;
//    float xAxisP2;
//    float yAxisP2;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Start position player 1
//        posP1 = new Vector2((Width / 2) - 2, (Height / 2));

//        // Start position player 2
//        posP2 = new Vector2((Width / 2) + 2, (Height / 2));
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Background(50);

//        // Player 1 
//        Fill(0, 0, 255);
//        StrokeWeight(0.25f);
//        Circle(posP1.x, posP1.y, diameter);
//        p1Movement();

//        // Player 2
//        Fill(255, 0, 0);
//        StrokeWeight(0.25f);
//        Circle(posP2.x, posP2.y, diameter);
//        p2Movement();

//        ScreenWrap();
//        SpeedClamp();
//    }

//    private void p1Movement()
//    {
//        // Left
//        if (Input.GetAxisRaw("Horizontal") == -1)
//        {
//            xAxisP1 = -1;
//            posP1.x += xAxisP1 * Time.deltaTime * velocityP1;
//            newVelocityP1 = velocityP1;

//            if (Input.GetAxisRaw("Vertical") == 0)
//            {
//                yAxisP1 = 0;
//            }
//        }
//        // RIght
//        if (Input.GetAxisRaw("Horizontal") == 1)
//        {
//            xAxisP1 = 1;
//            posP1.x += xAxisP1 * Time.deltaTime * velocityP1;
//            newVelocityP1 = velocityP1;

//            if (Input.GetAxisRaw("Vertical") == 0)
//            {
//                yAxisP1 = 0;
//            }
//        }
//        // Up
//        if (Input.GetAxisRaw("Vertical") == 1)
//        {
//            yAxisP1 = 1;
//            posP1.y += yAxisP1 * Time.deltaTime * velocityP1;
//            newVelocityP1 = velocityP1;

//            if (Input.GetAxisRaw("Horizontal") == 0)
//            {
//                xAxisP1 = 0;
//            }
//        }
//        // Down
//        if (Input.GetAxisRaw("Vertical") == -1)
//        {
//            yAxisP1 = -1;
//            posP1.y += yAxisP1 * Time.deltaTime * velocityP1;
//            newVelocityP1 = velocityP1;

//            if (Input.GetAxisRaw("Horizontal") == 0)
//            {
//                xAxisP1 = 0;
//            }
//        }
//        // No input --- Deceleration
//        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && newVelocityP1 > 0)
//        {
//            posP1.x += xAxisP1 * Time.deltaTime * newVelocityP1;
//            posP1.y += yAxisP1 * Time.deltaTime * newVelocityP1;
//            newVelocityP1 -= acceleration * Time.deltaTime;
//        }
//    }
//    private void p2Movement()
//    {

//        // Acceleration and Deceleration
//        //When directional button is pressed or released, corresponding float saved in another variable (x/yAxisP2). That variable is then updated in the movement equation. The current velocity is updated and stored in a new variable which will slow the bal down to a standstill without affecting it's initial velocity

//        // Left
//        if (Input.GetAxisRaw("Horizontal") == -1)
//        {
//            xAxisP2 = -1;
//            posP2.x += xAxisP2 * Time.deltaTime * velocityP2;
//            velocityP2 += acceleration * Time.deltaTime;
//            newVelocityP2 = velocityP2;

//            if (Input.GetAxisRaw("Vertical") == 0)
//            {
//                yAxisP2 = 0;
//            }
//        }
//        // Right
//        if (Input.GetAxisRaw("Horizontal") == 1)
//        {
//            xAxisP2 = 1;
//            posP2.x += xAxisP2 * Time.deltaTime * velocityP2;
//            velocityP2 += acceleration * Time.deltaTime;
//            newVelocityP2 = velocityP2;

//            if (Input.GetAxisRaw("Vertical") == 0)
//            {
//                yAxisP2 = 0;
//            }
//        }
//        // Up
//        if (Input.GetAxisRaw("Vertical") == 1)
//        {
//            yAxisP2 = 1;
//            posP2.y += yAxisP2 * Time.deltaTime * velocityP2;
//            velocityP2 += acceleration * Time.deltaTime;
//            newVelocityP2 = velocityP2;

//            if (Input.GetAxisRaw("Horizontal") == 0)
//            {
//                xAxisP2 = 0;
//            }
//        }
//        // Down
//        if (Input.GetAxisRaw("Vertical") == -1)
//        {
//            yAxisP2 = -1;
//            posP2.y += yAxisP2 * Time.deltaTime * velocityP2;
//            velocityP2 += acceleration * Time.deltaTime;
//            newVelocityP2 = velocityP2;

//            if (Input.GetAxisRaw("Horizontal") == 0)
//            {
//                xAxisP2 = 0;
//            }
//        }
//        // No Input ---Deceleration
//        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && newVelocityP2 > 0)
//        {
//            posP2.x += xAxisP2 * Time.deltaTime * newVelocityP2;
//            posP2.y += yAxisP2 * Time.deltaTime * newVelocityP2;
//            newVelocityP2 -= acceleration * Time.deltaTime;
//            velocityP2 = newVelocityP2;
//        }
//    }

//    private void SpeedClamp()
//    {
//        if (maxSpeed < velocityP2)
//        {
//            velocityP2 = maxSpeed;
//        }
//        else if (velocityP2 > maxSpeed)
//        {
//            velocityP2 = maxSpeed;
//        }
//    }

//    private void ScreenWrap()
//    {
//        // Player 1
//        if (posP1.x > Width)
//        {
//            posP1.x = 0;
//            //posP1.x -= Width;
//        }
//        else if (posP1.x < 0)
//        {
//            posP1.x = Width;
//            //posP1.x += Width;
//        }

//        if (posP1.y > Height)
//        {
//            posP1.y = 0;
//        }
//        else if (posP1.y < 0)
//        {
//            posP1.y = Height;
//        }

//        // Player 2
//        if (posP2.x > Width)
//        {
//            posP2.x = 0;
//        }
//        else if (posP2.x < 0)
//        {
//            posP2.x = Width;
//        }

//        if (posP2.y > Height)
//        {
//            posP2.y = 0;
//        }
//        else if (posP2.y < 0)
//        {
//            posP2.y = Height;
//        }
//    }
//}
