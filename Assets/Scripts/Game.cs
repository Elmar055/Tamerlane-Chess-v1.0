using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


// This script is to be added as a component to the Controller object.
public class Game : MonoBehaviour
{
    // Add chesspiece prefab to this reference
    public GameObject chesspiece;

    //We set up the board consisting of 13 columns and 10 rows as an array.
    //Normally the board consists of 11 columns and 10 rows.
    //But here we take it as 13x10 because there is an extra cell on
    //the sides of the leftmost column and the rightmost column.
    public GameObject[,] positions = new GameObject[13, 10];

    //Arrays to hold black and white pieces
    public GameObject[] playerBlack = new GameObject[21];
    public GameObject[] playerWhite = new GameObject[21];

    private string currentPlayer;
    private bool gameOver = false;
    public TextMeshProUGUI messageText;


    // Start is called before the first frame update
    void Start()
    {
        // When Game starts. Create chesspieces in positions array
        // In here index starts 1 in x axis.
        // Because 11x10 matrix rows start from 1.
        playerBlack = new GameObject[] 
        { 
            Create("blackElephant", 1, 0), Create("blackCamel", 3, 0), Create("blackCatapult", 5, 0), 
            Create("blackCatapult", 7, 0), Create("blackCamel", 9, 0), Create("blackElephant",11, 0),
            Create("blackRoof", 1, 1), Create("blackHorse", 2, 1), Create("blackDebbabe", 3, 1),
            Create("blackGiraffe", 4, 1),Create("blackCommander", 5, 1), Create("blackKing", 6, 1),
            Create("blackQueen", 7, 1),Create("blackGiraffe", 8, 1), Create("blackDebbabe", 9, 1), 
            Create("blackHorse", 10, 1),Create("blackRoof", 11, 1), Create("blackPawnPawn", 1, 2),
            Create("blackCatapultPawn", 2, 2), Create("blackCamelPawn", 3, 2),Create("blackElephantPawn", 4, 2),
            Create("blackCommanderPawn", 5, 2), Create("blackKingPawn", 6, 2), Create("blackQueenPawn", 7, 2), 
            Create("blackGiraffePawn", 8, 2), Create("blackDebbabePawn", 9, 2),Create("blackHorsePawn", 10, 2),
            Create("blackRoofPawn", 11, 2)
        };

        //-------------------------------------------------------------------------------------------------------------

        playerWhite = new GameObject[] 
        { 
            Create("whiteElephant", 1, 9), Create("whiteCamel", 3, 9), Create("whiteCatapult", 5, 9),
            Create("whiteCatapult", 7, 9), Create("whiteCamel", 9, 9), Create("whiteElephant",11, 9),
            Create("whiteRoof", 1, 8), Create("whiteHorse", 2, 8),Create("whiteDebbabe", 3, 8),
            Create("whiteGiraffe", 4, 8),Create("whiteQueen", 5, 8), Create("whiteKing", 7, 3),
            Create("whiteCommander", 7, 8),Create("whiteGiraffe", 8, 8),Create("whiteDebbabe", 9, 8),
            Create("whiteHorse", 10, 8),Create("whiteRoof", 11, 8), Create("whiteRoofPawn", 1, 7), 
            Create("whiteHorsePawn", 2, 7), Create("whiteDebbabePawn", 3, 7),Create("whiteGiraffePawn", 4, 7),
            Create("whiteQueenPawn", 5, 7), Create("whiteKingPawn", 6, 7),Create("whiteCommanderPawn", 7, 7),
            Create("whiteElephantPawn", 8, 7), Create("whiteCamelPawn", 9, 7),Create("whiteCatapultPawn", 10, 7),
            Create("whitePawnPawn", 11, 7)
        };

        // Place the stones in the correct position according to the index numbers of the positions array.
        for (int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }


        int randomNumber = Random.Range(0, 2);

        if (randomNumber == 0)
        {
            
            currentPlayer = "white";
            messageText.text = "White Starts";
        }else
        {
            currentPlayer = "black";
            messageText.text = "Black Starts";
        }

        StartCoroutine(HideMessageAfterSeconds());

        
        
        

    }
    
    private IEnumerator HideMessageAfterSeconds()
    {
        // 
        yield return new WaitForSeconds(3f);

        // 
        messageText.text = "";
    }



    //This function creates the chesspieces with the given name at the given coordinates.
    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }




    // Activate the object in the given position according to the indexes of the array
    // and move it to the position in the real scene
    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    // Return null at given position
    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    // Return the object at the index of the positions array
    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    // Limiting the movements of the pieces on the board.
    // Here, the stones can only move along the x arrow from the 1 index of the array to the 11 index.
    // Only the king will be able to move to the extra two cells.
    // This will be done in the king stone moveplate function.
    public bool PositionOnBoard(int x, int y)
    {
        if (x < 1 || y < 0 || x >= positions.GetLength(0)-1 || y >= positions.GetLength(1)) return false;
        return true;
    }


    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    
    public void NextTurn()
    {

        
        if (currentPlayer == "white")
        {
            currentPlayer = "black";
        }
        else
        {
            currentPlayer = "white";
        }
        



    }

    public void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;

            //Using UnityEngine.SceneManagement is needed here
            SceneManager.LoadScene("Game"); //Restarts the game by loading the scene over again
        }
    }

    public void Winner(string playerWinner)
    {
        gameOver = true;

        //Using UnityEngine.UI is needed here
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<TextMeshProUGUI>().text = playerWinner + " is the winner";

    }

}
