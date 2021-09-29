using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5ClassObject : ProcessingLite.GP21
{
    PlayerAssignment5 brenda;
    BallAssignment5 tony;
    BallAssignment5[] tonyBalls;
    public int numberOfBalls = 10;
    public bool isHit;
    public bool isGameOver = false;
    public float time;
    public float newTime;   // Add in a score tracker in Update isHit
    public float oldTime;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGameOver = false;
                Initialize();
            }
            else
            {
                return;
            }
        }

        Background(180);

        brenda.Movement();
        brenda.Boundary();
        brenda.Draw();

        for (int i = 0; i < tonyBalls.Length; i++)
        {
            tonyBalls[i].Movement();
            tonyBalls[i].Boundary();
            tonyBalls[i].Draw();

            isHit = BallCollision(brenda, tonyBalls[i]);

            if (isHit)
            {
                Fill(255, 0, 0);
                TextSize(35);
                Text("Game Over Dude!\n\n\n", Width / 2, Height / 2);
                Text("Your survival time was " + time + " seconds\n", Width / 2, Height / 2);
                Text("\n\n\nPress Space Bar to play again.", Width / 2, Height / 2);
                
                isGameOver = true;
                time = 0;
            }
        }      
    }

    private void Initialize()
    {
        brenda = new PlayerAssignment5(Color.clear, 1.25f);

        tonyBalls = new BallAssignment5[numberOfBalls];

        for (int i = 0; i < tonyBalls.Length; i++)
        {
            tonyBalls[i] = new BallAssignment5();
        }
    }
    bool BallCollision(PlayerAssignment5 brenda, BallAssignment5 tony)
    {
        this.brenda = brenda;
        this.tony = tony;

        float maxDistance = (brenda.diameter / 2) + (tony.diameter / 2);

        if (Mathf.Abs(brenda.position.x - tony.position.x) > maxDistance || Mathf.Abs(brenda.position.y - tony.position.y) > maxDistance)
        {
            return false;
        }
        else if (Vector2.Distance(new Vector2(brenda.position.x, brenda.position.y), new Vector2(tony.position.x, tony.position.y)) > maxDistance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
