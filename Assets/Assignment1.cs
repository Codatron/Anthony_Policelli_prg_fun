using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    // Dimensions
    float topBoundaryName = 7.0f;
    float bottomBoundaryName = 4.0f;
    private float topBoundaryScreen = 15.0f;
    private float bottomBoundaryScreen = -5.0f;

    // Background colours
    float bgRed = 1.0f;
    float bgGreen = 90.0f;
    float bgBlue = 1.0f;

    // Text colours
    float strokeMin = 70;
    float strokeMax = 200;

    // Letters
    // A
    Vector2 aLeftStart = new Vector2(0.25f, 4.0f);
    Vector2 aRightStart = new Vector2(0.75f, 7.0f);
    Vector2 aLeftStop = new Vector2(0.25f, 4.0f);
    Vector2 aRightStop = new Vector2(0.75f, 7.0f);
    Vector2 aMidStart = new Vector2(0.45f, 5.0f);
    Vector2 aMidStop = new Vector2(0.45f, 5.0f);
    float letterAPosX = 2.0f;
    float letterAPosY = 0.0f;

    // N1
    Vector2 n1LeftStart = new Vector2(1.5f, 4.0f);
    Vector2 n1LeftStop = new Vector2(1.5f, 4.0f);
    Vector2 n1MidStart = new Vector2(1.5f, 7.0f);
    Vector2 n1MidStop = new Vector2(1.5f, 7.0f);
    Vector2 n1RightStart = new Vector2(2.5f, 4.0f);
    Vector2 n1RightStop = new Vector2(2.5f, 4.0f);
    float letterN1PosX = 2.0f;
    float letterN1PosY = 0.0f;

    // T
    Vector2 tMidStart = new Vector2(3.25f, 7.0f);
    Vector2 tMidStop = new Vector2(3.25f, 7.0f);
    Vector2 tLeftStart = new Vector2(2.75f, 7.0f);
    Vector2 tLeftStop = new Vector2(2.75f, 7.0f);
    Vector2 tRightStart = new Vector2(3.75f, 7.0f);
    Vector2 tRightStop = new Vector2(3.75f, 7.0f);
    float letterTPosX = 2.0f;
    float letterTPosY = 0.0f;

    // H
    Vector2 hLeftStart = new Vector2(4.0f, 4.0f);
    Vector2 hLeftStop = new Vector2(4.0f, 4.0f);
    Vector2 hMidStart = new Vector2(4.0f, 5.5f);
    Vector2 hMidStop = new Vector2(4.0f, 5.5f);
    Vector2 hRightStart = new Vector2(5.0f, 7.0f);
    Vector2 hRightStop = new Vector2(5.0f, 7.0f);
    float letterHPosX = 2.0f;
    float letterHPosY = 0.0f;

    // O
    float oWidth = 0.0f;
    float oHeight = 0.0f;
    float letterOPosX = 2.0f;
    float letterOPosY = 0.0f;

    // N2
    Vector2 n2LeftStart = new Vector2(6.5f, 7.0f);
    Vector2 n2LeftStop = new Vector2(6.5f, 7.0f);
    Vector2 n2MidStart = new Vector2(7.5f, 4.0f);
    Vector2 n2MidStop = new Vector2(7.5f, 4.0f);
    Vector2 n2RightStart = new Vector2(7.5f, 7.0f);
    Vector2 n2RightStop = new Vector2(7.5f, 7.0f);
    float letterN2PosX = 2.0f;
    float letterN2PosY = 0.0f;

    // Y
    Vector2 yMidStart = new Vector2(8.25f, 4.0f);
    Vector2 yMidStop = new Vector2(8.25f, 4.0f);
    Vector2 yLeftStart = new Vector2(8.25f, 5.5f);
    Vector2 yLeftStop = new Vector2(8.25f, 5.5f);
    Vector2 yRightStart = new Vector2(8.25f, 5.5f);
    Vector2 yRightStop = new Vector2(8.25f, 5.5f);
    float letterYPosX = 2.0f;
    float letterYPosY = 0.0f;

    float spaceBetweenLines = 1.0f;

    // Circles
    private Vector2 circlePosition = new Vector2(2.75f, 11.0f);
    private Vector2 circlePosition1 = new Vector2(2.75f, 7.2f);
    private Vector2 circlePosition2 = new Vector2(7.75f, 9.0f);
    private float diameter = 0.50f;
    private float speedCircle = 2.5f;
    

    void Start()
    {

    }
    void Update()
    {
        // Colour Shifts
        ChangeBackgroundColour();

        Stroke((int)0);
        ChangeLetterColour();

        // Letters
        LetterA(letterAPosX, letterAPosY);

        LetterN1(letterN1PosX, letterN1PosY);

        LetterT(letterTPosX, letterTPosY);

        LetterH(letterHPosX, letterHPosY);

        Fill((int)bgRed, (int)bgGreen, (int)bgBlue);
        LetterO(letterOPosX, letterOPosY);

        LetterN2(letterN2PosX, letterN2PosY);

        LetterY(letterYPosX, letterYPosY);

        // Ball
        Fill(175);
        StrokeWeight(0.3f);
        Stroke(15);
        BallBounce();
        StrokeWeight(1.0f);
    }

    private void LetterA(float x, float y)
    {
        // Left
        BeginShape();
        Vertex(x + aLeftStart.x, y + aLeftStart.y);
        Vertex(x + aLeftStop.x, y + aLeftStop.y);
        EndShape();

        // Right
        BeginShape();
        Vertex(x + aRightStart.x, y + aRightStart.y);
        Vertex(x + aRightStop.x, y + aRightStop.y);
        EndShape();

        // Mid
        BeginShape();
        Vertex(x + aMidStart.x, y + aMidStart.y);
        Vertex(x + aMidStop.x, y + aMidStop.y);
        EndShape();

        DrawA();
    }

    private void LetterN1(float x, float y)
    {
        // Left
        BeginShape();
        Vertex(x + n1LeftStart.x, y + n1LeftStart.y);
        Vertex(x + n1LeftStop.x, y + n1LeftStop.y);
        EndShape();

        // Mid
        BeginShape();
        Vertex(x + n1MidStart.x, y + n1MidStart.y);
        Vertex(x + n1MidStop.x, y + n1MidStop.y);
        EndShape();

        // Right
        BeginShape();
        Vertex(x + n1RightStart.x, y + n1RightStart.y);
        Vertex(x + n1RightStop.x, y + n1RightStop.y);
        EndShape();

        DrawN1();
        //Line(1.5f, 4.0f, 1.5f, 7.0f);
        //Line(1.5f, 6.97f, 2.5f, 4.03f);
        //Line(2.5f, 4.0f, 2.5f, 7.0f);
    }

    private void LetterT(float x, float y)
    {
        // Mid
        BeginShape();
        Vertex(x + tMidStart.x, y + tMidStart.y);
        Vertex(x + tMidStop.x, y + tMidStop.y);
        EndShape();

        // Top Right
        BeginShape();
        Vertex(x + tRightStart.x, y + tRightStart.y);
        Vertex(x + tRightStop.x, y + tRightStop.y);
        EndShape();

        // Top Left
        BeginShape();
        Vertex(x + tLeftStart.x, y + tLeftStart.y);
        Vertex(x + tLeftStop.x, y + tLeftStop.y);
        EndShape();

        DrawT();
    }

    private void LetterH(float x, float y)
    {
        // Top Left
        BeginShape();
        Vertex(x + hLeftStart.x, y + hLeftStart.y);
        Vertex(x + hLeftStop.x, y + hLeftStop.y);
        EndShape();

        // Mid
        BeginShape();
        Vertex(x + hMidStart.x, y + hMidStart.y);
        Vertex(x + hMidStop.x, y + hMidStop.y);
        EndShape();

        // Top Right
        BeginShape();
        Vertex(x + hRightStart.x, y + hRightStart.y);
        Vertex(x + hRightStop.x, y + hRightStop.y);
        EndShape();

        DrawH();
    }

    private void LetterO(float x, float y)
    {
        Ellipse(x + 5.75f, y + 5.5f, oWidth, oHeight);
        DrawO();
    }

    private void LetterN2(float x, float y)
    {
        // Left
        BeginShape();
        Vertex(x + n2LeftStart.x, y + n2LeftStart.y);
        Vertex(x + n2LeftStop.x, y + n2LeftStop.y);
        EndShape();

        // Mid
        BeginShape();
        Vertex(x + n2MidStart.x, y + n2MidStart.y);
        Vertex(x + n2MidStop.x, y + n2MidStop.y);
        EndShape();

        // Right
        BeginShape();
        Vertex(x + n2RightStart.x, y + n2RightStart.y);
        Vertex(x + n2RightStop.x, y + n2RightStop.y);
        EndShape();

        DrawN2();
    }

    private void LetterY(float x, float y)
    {
        // Mid
        BeginShape();
        Vertex(x + yMidStart.x, y + yMidStart.y);
        Vertex(x + yMidStop.x, y + yMidStop.y);
        EndShape();

        // Left
        BeginShape();
        Vertex(x + yLeftStart.x, y + yLeftStart.y);
        Vertex(x + yLeftStop.x, y + yLeftStop.y);
        EndShape();

        // Right
        BeginShape();
        Vertex(x + yRightStart.x, y + yRightStart.y);
        Vertex(x + yRightStop.x, y + yRightStop.y);
        EndShape();

        DrawY();
    }
    private void DrawA()
    {
        if (aLeftStop.x < 0.75f && aLeftStop.y < topBoundaryName)
        {
            aLeftStop.x += 0.00015f;
            aLeftStop.y += 0.001f;
        }
        if (aRightStop.x < 1.25f && aRightStop.y > bottomBoundaryName)
        {
            aRightStop.x += 0.00015f;
            aRightStop.y -= 0.001f;
        }
        if (aMidStop.x < 1.05f && aLeftStop.y > 5.0f)
        {
            aMidStop.x += 0.000325f;
        }
    }
    private void DrawN1()
    {
        if (n1LeftStop.y < topBoundaryName)
        {
            n1LeftStop.y += 0.001f;
        }
        if (n1MidStop.x < 2.5f && n1MidStop.y > bottomBoundaryName)
        {
            n1MidStop.x += 0.000325f;
            n1MidStop.y -= 0.001f;
        }
        if (n1RightStop.y < topBoundaryName)
        {
            n1RightStop.y += 0.001f;
        }
    }
    private void DrawT()
    {
        if (tLeftStop.x < 3.25f)
        {
            tLeftStop.x += 0.0005f;
        }
        if (tRightStop.x > 3.25f)
        {
            tRightStop.x -= 0.0005f;
        }
        if (tMidStop.y > bottomBoundaryName && tLeftStop.x > 3.24)
        {
            tMidStop.y -= 0.00175f;
        }
    }
    private void DrawH()
    {
        if (hLeftStop.y < topBoundaryName)
        {
            hLeftStop.y += 0.001f;
        }
        if (hRightStop.y > bottomBoundaryName)
        {
            hRightStop.y -= 0.001f;
        }
        if (hLeftStop.y > 5.5f && hMidStop.x < 5.0f)
        {
            hMidStop.x += 0.000625f;
        }
    }
    private void DrawO()
    {
        if (oWidth < 1.0f)
        {
            oWidth += 0.000375f;
        }
        if (oHeight < 3.0f)
        {
            oHeight += 0.00125f;
        }
    }
    private void DrawN2()
    {
        if (n2LeftStop.y > bottomBoundaryName)
        {
            n2LeftStop.y -= 0.001f;
        }
        if (n2MidStop.x > 6.5f && n2MidStop.y < topBoundaryName)
        {
            n2MidStop.x -= 0.000325f;
            n2MidStop.y += 0.001f;
        }
        if (n2RightStop.y > bottomBoundaryName)
        {
            n2RightStop.y -= 0.001f;
        }
    }
    private void DrawY()
    {
        if (yMidStop.y < 5.5f)
        {
            yMidStop.y += 0.001f;
        }
        if (yMidStop.y > 5.4f && yLeftStop.x > 7.5f && yLeftStop.y < topBoundaryName)
        {
            yLeftStop.x -= 0.000325f;
            yLeftStop.y += 0.001f;
        }
        if (yMidStop.y > 5.4f && yRightStop.x < 9.5f && yRightStop.y < topBoundaryName)
        {
            yRightStop.x += 0.000325f;
            yRightStop.y += 0.001f;
        }
    }
    private void ChangeLetterColour()
    {
        Stroke((int)strokeMin);
        if (strokeMin < strokeMax)
        {
            strokeMin += 20 * Time.deltaTime;
        }
    }

    private void ChangeBackgroundColour()
    {
        Background((int)bgRed, (int)bgGreen, (int)bgBlue);
        // Background(Color.x);
        if (bgRed < 120)
        {
            bgRed += 20 * Time.deltaTime;
        }
        if (bgGreen < 120 && bgGreen > 20)
        {
            bgGreen -= 20 * Time.deltaTime;
        }
        if (bgBlue < 160)
        {
            bgBlue += 40 * Time.deltaTime;
        }
    }

    private void BallBounce()
    {
        Circle(circlePosition.x, circlePosition.y, diameter);
        if (circlePosition.y >= 7.2f)
        {
            circlePosition.y -= speedCircle * Time.deltaTime;
        }
        else
        {
            circlePosition.y = bottomBoundaryScreen;
        }

        if (circlePosition.y < 7.2f)
        {
            Circle(circlePosition1.x, circlePosition1.y, diameter);
            if (circlePosition1.x <= 7.75f)
            {
                circlePosition1.x += speedCircle * Time.deltaTime * 0.75f;
                circlePosition1.y += speedCircle * Time.deltaTime * 0.35f;
            }
            else
            {
                circlePosition1.y = topBoundaryScreen;
            }
        }

        if (circlePosition1.x > 7.75f)
        {
            Circle(circlePosition2.x, circlePosition2.y, diameter);

            if (circlePosition2.x < Width + 10)
            {
                circlePosition2.x += speedCircle * Time.deltaTime * 0.75f;
                circlePosition2.y -= speedCircle * Time.deltaTime * 0.35f;
            }
        }

        diameter += 0.07f * Time.deltaTime;
    }

    void Unused()
    {
        //Circle(circlePosition1.x, circlePosition1.y, diameter);
        //if (hitBottom = true)
        //{
        //    circlePosition1.y += speedCircle * Time.deltaTime;
        //    circlePosition1.x += (speedCircle / 2) * Time.deltaTime;
        //    hitBottom = false;
        //}
        //circleX += 2.0f;
        //circleY += dy;
        //if (circleY > 7.0f)
        //{
        //    dy = -dy;
        //    Circle(circleX, 9.5f, diameter);
        //    Debug.Log(circleY);
        //}
        //else
        //{
        //    dy = dy * 0.98f + 3;
        //    Circle(circleX, circleY, diameter);
        //}
        //if (circlePosition.y >= 8.0f /*topBoundaryName + 0.30f*/ /*&& aLeftStop.y > topBoundaryName - 1.0f*/)
        //{
        //    circlePosition.y -= speedCircle * Time.deltaTime;
        //    Debug.Log("Down" + circlePosition.y);
        //}
        //else if (circlePosition.y <= 11.0f /*topBoundaryName + 0.30f*/)
        //{
        //    circlePosition.y += speedCircle * Time.deltaTime; // when I change the operator to -=, the ball continues. Why won't it go back up?
        //    Debug.Log("Up" + circlePosition.y);
        //}

    }
}