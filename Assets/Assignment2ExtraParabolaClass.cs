using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola : ProcessingLite.GP21
{
    public Vector2 axis1;
    public Vector2 axis2;
    public float numberOfLines;
    public float linesX;
    public float linesY;
    float xLinesCounter;
    float yLinesCounter;

    public Parabola(Vector2 axis1, Vector2 axis2, float numberOfLines)
    {
        this.axis1 = axis1;
        this.axis2 = axis2;
        this.numberOfLines = numberOfLines;

        linesX = Width / numberOfLines;
        linesY = Height / numberOfLines;
    }

    public void DrawBottomLeft()
    {
        for (int i = 0; i <= numberOfLines; i++)
        {
            xLinesCounter = i * linesX;
            yLinesCounter = i * linesY;

            Line(axis1.x, axis1.y + yLinesCounter, axis2.x - xLinesCounter, axis2.y);

            if (axis2.x - xLinesCounter <= axis1.x)
            {
                break;
            }
        }
    }

    public void DrawBottomRight()
    {
        for (int i = 0; i <= numberOfLines; i++)
        {
            xLinesCounter = i * linesX;
            yLinesCounter = i * linesY;

            Line(axis1.x + xLinesCounter, axis1.y, axis2.x, axis2.y + yLinesCounter);

            if (axis1.x + xLinesCounter >= axis2.x)
            {
                break;
            }
        }
    }

    public void DrawTopLeft()
    {
        for (int i = 0; i <= numberOfLines; i++)
        {
            xLinesCounter = i * linesX;
            yLinesCounter = i * linesY;

            Line(axis1.x, axis1.y - yLinesCounter, axis2.x - xLinesCounter, axis2.y);

            if (axis2.x - xLinesCounter <= axis1.x)
            {
                break;
            }
        }
    }
    public void DrawTopRight()
    {
        for (int i = 0; i <= numberOfLines; i++)
        {
            xLinesCounter = i * linesX;
            yLinesCounter = i * linesY;

            Line(axis1.x + xLinesCounter, axis1.y, axis2.x, axis2.y - yLinesCounter);

            if (axis1.x + xLinesCounter >= axis2.x)
            {
                break;
            }
        }
    }

    // ToDo: figure out how to make a 'Star Trek' looking symbol - then set each up in thr three corners of a triangle
    public void StarTrek()
    {
        for (int i = 0; i <= numberOfLines; i++)
        {
            xLinesCounter = i * linesX;
            yLinesCounter = i * linesY;

            Line(axis1.x + xLinesCounter * 0.5f, axis1.y + yLinesCounter * 0.5f, axis2.x - xLinesCounter, axis2.y);
        }
    }
}


public class Assignment2ExtraParabolaClass : ProcessingLite.GP21
{
    Parabola parabola;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Background(180, 100, 80);
        StrokeWeight(0.2f);

        // ToDo: why do the parabolas exceed the screen size? Shouldn't Height/Width provide the limit?
        parabola = new Parabola(new Vector2(0, Height / 4), new Vector2(Width, Height / 4), 70);
        parabola.DrawBottomLeft();
        parabola.DrawBottomRight();
        parabola.DrawTopLeft();
        parabola.DrawTopRight();

        //parabola = new Parabola(new Vector2(Width / 2, Height / 2), new Vector2(Width, Height / 2), 20);
        //parabola.DrawBottomLeft();
        //parabola.DrawBottomRight();
        //parabola.DrawTopLeft();
        //parabola.DrawTopRight();

        //parabola = new Parabola(new Vector2(0, 0), new Vector2(Width, 0), 10);
        //parabola.StarTrek();
    }
}
