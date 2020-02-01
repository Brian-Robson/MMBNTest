using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject playerCharacter;
    public GameObject testEnemy;
    public GameObject battleTile;

    // Player Variables
    public int playerHP;
    public int playerMaxHP;

    GameObject[,] battleArray = new GameObject[3, 6];

    void Awake()
    {
        InitializeBattle();
    }

    void InitializeBattle() // Generates the battle tiles, the player object, enemies, etc.
    {
        for (int y = 0; y < 3; y++) // This loop generates the 6x3 of tiles needed for combat
        {
            for (int x = 0; x < 6; x++)
            {
                battleArray[y, x] = Instantiate(battleTile, new Vector3(x * 0.4f - 1, y * 0.24f, 0), Quaternion.identity);
                if (x < 3) // Conditional sets tile ownership
                {
                    UpdateTileColour(battleArray[y, x], Color.red, true);
                }
                else
                {
                    UpdateTileColour(battleArray[y, x], Color.blue, false);
                }
            }
        }
        GameObject playerInstance = Instantiate(playerCharacter, GetDestination(1, 1), Quaternion.identity);
        playerInstance.GetComponent<PlayerController>().Constructor(this, playerHP, playerMaxHP);
    }

    void UpdateTileColour(GameObject targetTile, Color targetColour, bool playerTile)
    {
        targetTile.transform.GetChild(0).GetComponent<SpriteRenderer>().color = targetColour;
        targetTile.GetComponent<TileProperties>().tileOwnership = playerTile;
    }

    public bool ValidMove(int y, int x)
    {
        if (y < 0 || y > 2 || x < 0 || x > 5)
        {
            return false;
        }
        else return battleArray[y, x].GetComponent<TileProperties>().tileOwnership;
    }

    public Vector3 GetDestination(int y, int x)
    {
        Vector3 destination = battleArray[y, x].transform.position;
        return destination + new Vector3(0, 0.1f, 0);
    }
}