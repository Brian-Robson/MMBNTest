using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject playerCharacter;
    public GameObject testEnemy;
    public GameObject battleTile;
    GameObject[,] battleArray = new GameObject[3, 6];

    void Awake()
    {
        InitializeBattle();
    }

    void InitializeBattle() // Generates the battle tiles, the player object, enemies, etc.
    {
        for (int y = 0; y < 3; y++) // Really nothing else I need to do with this
        {
            for (int x = 0; x < 6; x++)
            {
                battleArray[y, x] = Instantiate(battleTile, new Vector3(x * 0.4f - 1, y * 0.24f, 0), Quaternion.identity);
            }
        }
        for (int y = 0; y < 3; y++) // Sets the player character's 3x3 tiles
        {
            for (int x = 0; x < 3; x++)
            {
                UpdateTileColour(battleArray[y, x], Color.red, true);
            }
        }
        for (int y = 0; y < 3; y++) // Sets the enemy 3x3 tiles
        {
            for (int x = 3; x < 6; x++)
            {
                UpdateTileColour(battleArray[y, x], Color.blue, false);
            }
        }
        GameObject temp = Instantiate(playerCharacter, GetDestination(1, 1), Quaternion.identity);
        temp.GetComponent<PlayerController>().gameManager = this;
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
