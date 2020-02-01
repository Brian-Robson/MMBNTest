using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameManager gameManager;
    int x = 1;
    int y = 1;
    public int maxHP;
    public int HP;
    float moveDelay = 0.2f;
    float currMoveDelay = 0.0f;
    bool alive = false; // Prevents function until properly initialized via Constructor function

    void Update()
    {
        if (alive)
        {
            if (currMoveDelay > 0)
            {
                currMoveDelay = currMoveDelay - 1 * Time.deltaTime;
            }
            if (currMoveDelay <= 0)
            {
                if (Input.GetKeyDown("up"))
                {
                    if (gameManager.ValidMove(y + 1, x))
                    {
                        transform.position = gameManager.GetDestination(y + 1, x);
                        y = y + 1;
                        currMoveDelay = moveDelay;
                    }
                }
                else if (Input.GetKeyDown("down"))
                {
                    if (gameManager.ValidMove(y - 1, x))
                    {
                        transform.position = gameManager.GetDestination(y - 1, x);
                        y = y - 1;
                        currMoveDelay = moveDelay;
                    }
                }
                else if (Input.GetKeyDown("left"))
                {
                    if (gameManager.ValidMove(y, x - 1))
                    {
                        transform.position = gameManager.GetDestination(y, x - 1);
                        x = x - 1;
                        currMoveDelay = moveDelay;
                    }
                }
                else if (Input.GetKeyDown("right"))
                {
                    if (gameManager.ValidMove(y, x + 1))
                    {
                        transform.position = gameManager.GetDestination(y, x + 1);
                        x = x + 1;
                        currMoveDelay = moveDelay;
                    }
                }
            }
        }
    }
    public void Constructor(GameManager gameManager, int HP, int maxHP)
    {
        this.gameManager = gameManager;
        this.HP = HP;
        this.maxHP = maxHP;
        this.alive = true;
    }
}