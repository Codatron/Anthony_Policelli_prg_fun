using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{
    int numberOfLines = 20;
    float lineSpacing = 0.2f;
    int selector = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ColourSelector", 0, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        Background(100, 126, 153);

        //Parabola();
        //HorizontalLines();
        //HorizontalLinesMovementT2B();
        //HorizontalLinesMovementB2T();
        //VerticalLineMovementL2R();
        //VerticalLineMovementR2L();
    }

    private void Parabola()
    {
        StrokeWeight(0.5f);
        // Bottom Left 
        for (int i = 0; i <= numberOfLines; i++)
        {
            float y1 = Height - i * Height / numberOfLines;
            float x2 = i * Width / numberOfLines;

            ChangeLineColour(i);
            Line(0,y1, x2, 0);
        }

        // Bottom right
        for (int i = 0; i <= numberOfLines; i++)
        {
            float x1 = i * Width / numberOfLines;
            float y2 = i * Height / numberOfLines;
            
            ChangeLineColour(i);
            Line(x1, 0, Width, y2);
        }
    }
    private void ColourSelector()
    {
        selector++;
        selector %= 3;
    }

    private void ChangeLineColour(int i)
    {
        if (i % 3 == selector)
        {
            Stroke(0);
        }
        else
        {
            Stroke(255);
        }
    }

    private void HorizontalLines()
    {
        for (int i = 0; i < Height / lineSpacing; i++)
        {
            float y = i * lineSpacing;
            Line(0, y, Width, y);
        }
    }

    private void HorizontalLinesMovementB2T()
    {
        for (int i = 0; i < Height / lineSpacing; i++)
        {
            float yLineSpace = i * lineSpacing;
            float y1Movement = (yLineSpace + Time.time) % Height;
            float y2Movement = (yLineSpace + Time.time) % Height;

            Line(0, y1Movement, Width, y2Movement);
        }
    }

    private void HorizontalLinesMovementT2B()
    {
        for (float i = Height / lineSpacing; i >= 0; i--)
        {
            float yLineSpace = i * lineSpacing;
            float y1Movement = (yLineSpace - Time.time) % Height;

            if (y1Movement < 0)
            {
                y1Movement *= -1;
                y1Movement = Height - y1Movement;
            }

            Line(0, y1Movement, Width, y1Movement);
        }
    }

    private void VerticalLines()
    {
        for (int i = 0; i < Width; i++)
        {
            float y = i * lineSpacing;
            Line(y, 0, y, Height);
        }
    }

    private void VerticalLineMovementL2R()
    {
        for (int i = 0; i < Width / lineSpacing; i++)
        {
            float xLineSpacing = i * lineSpacing;
            float x1Movement = (xLineSpacing + Time.time) % Width;
            float x2Movement = (xLineSpacing + Time.time) % Width;

            Line(x1Movement, 0, x2Movement, Height);
        }
    }

    private void VerticalLineMovementR2L()
    {
        for (float i = Width / lineSpacing; i >= 0; i--)
        {
            float xLineSpacing = i * lineSpacing;
            float xMovement = (xLineSpacing - Time.time) % Width;

            if (xMovement < 0)
            {
                xMovement *= -1;
                xMovement = Width - xMovement;
            }
            
            Line(xMovement, 0, xMovement, Height);
        }
    }

    // Functions below were previous code to test stuff out.
    // DO NOT USE
    private void Unused()
    {
        for (int i = 0; i < Height; i++)
        {
            //Increase y-cord each time loop run
            float y = i * lineSpacing;

            //Draw a line from left side of screen to the right
            // Parabola bottom right
            //Stroke(0, 255, 0);
            //Line(i, 0, Width, y);
            // Parabola top left
            //Line(i, Width, 0, y);
            // Parabola 
            //Stroke(255, 0, 0);
            //Line(0, Height - i, i, 0);
            //Line(0, i, y, 0);
            // Rays from bottom right
            //Stroke(255, 0, 0);
            //Line(Width, 0, i, y);
            // Diagonal ´line bottom left
            //Stroke(0, 0, 255);
            //Line(i, 0, 0, y);

            //Draw a line from left side of screen to the right
            //this time modify the height depending on time passed
            //Line(0, (y + Time.time) % Height, Width, (y + Time.time) % Height);
        }
    }

    private void UnusedParabola()
    {
        // Top right
        //for (int i = 0; i <= 10; i++)
        //{
        //    Line(10, i, 10 - i, 10); 
        //}

        // Top left
        //for (int i = 0; i <= Width; i++)
        //{
        //    Line(Width - i, 10, 0, 10 - i); 
        //}
    }
}
