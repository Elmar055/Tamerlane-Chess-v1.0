using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject chesspiece;

    public GameObject[,] positions = new GameObject[13, 10];// 13 olmanin sebebi 2 ekstra xanadir.


    public GameObject[] playerBlack = new GameObject[21];
    public GameObject[] playerWhite = new GameObject[21];

    //white starts game
    //private string currentPlayer = "white";

    //private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {

        playerBlack = new GameObject[] { Create("blackElephant", 1, 0), Create("blackCamel", 3, 0), Create("blackCatapult", 5, 0),
        Create("blackCatapult", 7, 0), Create("blackCamel", 9, 0), Create("blackElephant",11, 0),Create("blackRoof", 1, 1),
        Create("blackHorse", 2, 1),Create("blackDebbabe", 3, 1),Create("blackGiraffe", 4, 1),Create("blackCommander", 5, 1),
        Create("blackKing", 6, 1),Create("blackQueen", 7, 1),Create("blackGiraffe", 8, 1),Create("blackDebbabe", 9, 1),
        Create("blackHorse", 10, 1),Create("blackRoof", 11, 1),Create("blackPawnPawn", 1, 2),Create("blackCatapultPawn", 2, 2),
        Create("blackCamelPawn", 3, 2),Create("blackElephantPawn", 4, 2),Create("blackCommanderPawn", 5, 2),
        Create("blackKingPawn", 6, 2), Create("blackQueenPawn", 7, 2), Create("blackGiraffePawn", 8, 2),
        Create("blackDebbabePawn", 9, 2),Create("blackHorsePawn", 10, 2),Create("blackRoofPawn", 11, 2)};



        playerWhite = new GameObject[] { Create("whiteElephant", 1, 9), Create("whiteCamel", 3, 9), Create("whiteCatapult", 5, 9),
        Create("whiteCatapult", 7, 9), Create("whiteCamel", 9, 9), Create("whiteElephant",11, 9),Create("whiteRoof", 1, 8),
        Create("whiteHorse", 2, 8),Create("whiteDebbabe", 3, 8),Create("whiteGiraffe", 4, 8),Create("whiteCommander", 7, 8),
        Create("whiteKing", 6, 8),Create("whiteQueen", 5, 8),Create("whiteGiraffe", 8, 8),Create("whiteDebbabe", 9, 8),
        Create("whiteHorse", 10, 8),Create("whiteRoof", 11, 8), Create("whiteRoofPawn", 1, 7), Create("whiteHorsePawn", 2, 7),
        Create("whiteDebbabePawn", 3, 7),Create("whiteGiraffePawn", 4, 7),Create("whiteQueenPawn", 5, 7),
        Create("whiteKingPawn", 6, 7),Create("whiteCommanderPawn", 7, 7),Create("whiteElephantPawn", 8, 7),
        Create("whiteCamelPawn", 9, 7),Create("whiteCatapultPawn", 10, 7),Create("whitePawnPawn", 11, 7)};

        for (int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }


    }

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

    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }


    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 1 || y < 0 || x >= positions.GetLength(0)-1 || y >= positions.GetLength(1)) return false;
        return true;
    }




}
