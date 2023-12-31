﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;


public class Chessman : MonoBehaviour
{
    //References to objects in our Unity Scene
    public GameObject controller;
    public GameObject movePlate;
    public GameObject forwardMove;

    //Position for this Chesspiece on the Board
    //The correct position will be set later
    private int xBoard = -1;
    private int yBoard = -1;

    //Variable for keeping track of the player it belongs to "black" or "white"
    private string player;



    public Sprite blackKing, blackQueen, blackCommander, blackElephant, blackCamel, blackCatapult,
        blackDebbabe, blackGiraffe, blackHorse, blackRoof, blackKingPawn, blackQueenPawn,
        blackCommanderPawn, blackElephantPawn, blackCamelPawn, blackCatapultPawn,
        blackDebbabePawn, blackGiraffePawn, blackHorsePawn, blackRoofPawn, blackPawnPawn,
        blackPrince,blackPawnPawnFirstPromote, blackPawnPawnSecondPromote;

    public Sprite whiteKing, whiteQueen, whiteCommander, whiteElephant, whiteCamel, whiteCatapult,
        whiteDebbabe, whiteGiraffe, whiteHorse, whiteRoof, whiteKingPawn, whiteQueenPawn,
        whiteCommanderPawn, whiteElephantPawn, whiteCamelPawn, whiteCatapultPawn,
        whiteDebbabePawn, whiteGiraffePawn, whiteHorsePawn, whiteRoofPawn, whitePawnPawn,
        whitePrince, whitePawnPawnFirstPromote, whitePawnPawnSecondPromote;

    public string GetPlayer()
    {
        return player;
    }

    public void SetPlayer(string player)
    {
        this.player = player;
    }

    public Vector2Int GetPosition()
    {
        return new Vector2Int(xBoard, yBoard);
    }

    public void SetPosition(int x, int y)
    {
        xBoard = x;
        yBoard = y;
    }

    public void Activate()
    {
        //Get the game controller
        controller = GameObject.FindGameObjectWithTag("GameController");

        //Take the instantiated location and adjust transform
        SetCoords();


        switch (this.name)
        {
            case "blackKing": this.GetComponent<SpriteRenderer>().sprite = blackKing; player = "black"; break;
            case "blackQueen": this.GetComponent<SpriteRenderer>().sprite = blackQueen; player = "black"; break;
            case "blackCommander": this.GetComponent<SpriteRenderer>().sprite = blackCommander; player = "black"; break;
            case "blackElephant": this.GetComponent<SpriteRenderer>().sprite = blackElephant; player = "black"; break;
            case "blackCamel": this.GetComponent<SpriteRenderer>().sprite = blackCamel; player = "black"; break;
            case "blackCatapult": this.GetComponent<SpriteRenderer>().sprite = blackCatapult; player = "black"; break;
            case "blackDebbabe": this.GetComponent<SpriteRenderer>().sprite = blackDebbabe; player = "black"; break;
            case "blackGiraffe": this.GetComponent<SpriteRenderer>().sprite = blackGiraffe; player = "black"; break;
            case "blackHorse": this.GetComponent<SpriteRenderer>().sprite = blackHorse; player = "black"; break;
            case "blackRoof": this.GetComponent<SpriteRenderer>().sprite = blackRoof; player = "black"; break;
            case "blackKingPawn": this.GetComponent<SpriteRenderer>().sprite = blackKingPawn; player = "black"; break;
            case "blackQueenPawn": this.GetComponent<SpriteRenderer>().sprite = blackQueenPawn; player = "black"; break;
            case "blackCommanderPawn": this.GetComponent<SpriteRenderer>().sprite = blackCommanderPawn; player = "black"; break;
            case "blackElephantPawn": this.GetComponent<SpriteRenderer>().sprite = blackElephantPawn; player = "black"; break;
            case "blackCamelPawn": this.GetComponent<SpriteRenderer>().sprite = blackCamelPawn; player = "black"; break;
            case "blackCatapultPawn":this.GetComponent<SpriteRenderer>().sprite = blackCatapultPawn;player = "black";break;
            case "blackDebbabePawn": this.GetComponent<SpriteRenderer>().sprite = blackDebbabePawn; player = "black"; break;
            case "blackGiraffePawn": this.GetComponent<SpriteRenderer>().sprite = blackGiraffePawn; player = "black"; break;
            case "blackHorsePawn": this.GetComponent<SpriteRenderer>().sprite = blackHorsePawn; player = "black"; break;
            case "blackRoofPawn": this.GetComponent<SpriteRenderer>().sprite = blackRoofPawn; player = "black"; break;
            case "blackPawnPawn": this.GetComponent<SpriteRenderer>().sprite = blackPawnPawn; player = "black"; break;


            case "whiteKing": this.GetComponent<SpriteRenderer>().sprite = whiteKing; player = "white"; break;
            case "whiteQueen": this.GetComponent<SpriteRenderer>().sprite = whiteQueen; player = "white"; break;
            case "whiteCommander": this.GetComponent<SpriteRenderer>().sprite = whiteCommander; player = "white"; break;
            case "whiteElephant": this.GetComponent<SpriteRenderer>().sprite = whiteElephant; player = "white"; break;
            case "whiteCamel": this.GetComponent<SpriteRenderer>().sprite = whiteCamel; player = "white"; break;
            case "whiteCatapult": this.GetComponent<SpriteRenderer>().sprite = whiteCatapult; player = "white"; break;
            case "whiteDebbabe": this.GetComponent<SpriteRenderer>().sprite = whiteDebbabe; player = "white"; break;
            case "whiteGiraffe": this.GetComponent<SpriteRenderer>().sprite = whiteGiraffe; player = "white"; break;
            case "whiteHorse": this.GetComponent<SpriteRenderer>().sprite = whiteHorse; player = "white"; break;
            case "whiteRoof": this.GetComponent<SpriteRenderer>().sprite = whiteRoof; player = "white"; break;
            case "whiteKingPawn": this.GetComponent<SpriteRenderer>().sprite = whiteKingPawn; player = "white"; break;
            case "whiteQueenPawn": this.GetComponent<SpriteRenderer>().sprite = whiteQueenPawn; player = "white"; break;
            case "whiteCommanderPawn": this.GetComponent<SpriteRenderer>().sprite = whiteCommanderPawn; player = "white"; break;
            case "whiteElephantPawn": this.GetComponent<SpriteRenderer>().sprite = whiteElephantPawn; player = "white"; break;
            case "whiteCamelPawn": this.GetComponent<SpriteRenderer>().sprite = whiteCamelPawn; player = "white"; break;
            case "whiteCatapultPawn": this.GetComponent<SpriteRenderer>().sprite = whiteCatapultPawn; player = "white"; break;
            case "whiteDebbabePawn": this.GetComponent<SpriteRenderer>().sprite = whiteDebbabePawn; player = "white"; break;
            case "whiteGiraffePawn": this.GetComponent<SpriteRenderer>().sprite = whiteGiraffePawn; player = "white"; break;
            case "whiteHorsePawn": this.GetComponent<SpriteRenderer>().sprite = whiteHorsePawn; player = "white"; break;
            case "whiteRoofPawn": this.GetComponent<SpriteRenderer>().sprite = whiteRoofPawn; player = "white"; break;
            case "whitePawnPawn": this.GetComponent<SpriteRenderer>().sprite = whitePawnPawn; player = "white"; break;
        }
    }

    public void SetCoords()
    {
        //Get the board value in order to convert to xy coords
        float x = xBoard;
        float y = yBoard;

        
        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }
    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    private void OnMouseUp()
    {
        if (!controller.GetComponent<Game>().IsGameOver() && controller.GetComponent<Game>().GetCurrentPlayer() == player)
        {
            //Remove all moveplates relating to previously selected piece
            DestroyMovePlates();
            //Create new MovePlates
            InitiateMovePlates();

        }
    }

    public void DestroyMovePlates()
    {
        //Destroy old MovePlates
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]); //Be careful with this function "Destroy" it is asynchronous
        }
    }

    public void InitiateMovePlates()
    {
        switch (this.name)
        {
            case "blackPawnPawn":
                BlackPawnMovePlate();
                break;
            case "whitePawnPawn":
                WhitePawnMovePlate();
                break;
            case "blackPawnPawnFirstPromote":
                if (yBoard == 9 && player == "black")
                {
                    Game sc = controller.GetComponent<Game>();
                    if (sc.PositionOnBoard(xBoard, yBoard))
                    {
                        for (int i = 1; i < 9; i++)
                        {
                            for (int j = 1; j < 11; j++)
                            {

                                GameObject cp1 = sc.GetPosition(j - 1, yBoard - i);

                                GameObject cp2 = sc.GetPosition(j + 1, yBoard - i);

                                GameObject cp3 = sc.GetPosition(j, yBoard - (i + 1));

                                GameObject cp4 = sc.GetPosition(j, yBoard - (i));

                                if (cp1 != null && cp2 != null && cp3 == null && cp4 == null &&
                                cp1.GetComponent<Chessman>().player != player &&
                                cp2.GetComponent<Chessman>().player != player
                                )
                                {
                                    PointMovePlate(j, yBoard - (i + 1));
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                }
                BlackPawnMovePlate();
                break;
            case "whitePawnPawnFirstPromote":
                if (yBoard == 0 && player == "white")
                {
                    Game sc = controller.GetComponent<Game>();
                    if (sc.PositionOnBoard(xBoard, yBoard))
                    {
                        for (int i = 1; i < 9; i++)
                        {
                            for (int j = 1; j < 11; j++)
                            {

                                GameObject cp1 = sc.GetPosition(j - 1, yBoard + i);

                                GameObject cp2 = sc.GetPosition(j + 1, yBoard + i);

                                GameObject cp3 = sc.GetPosition(j, yBoard + (i + 1));

                                GameObject cp4 = sc.GetPosition(j, yBoard + (i));

                                if (cp1 != null && cp2 != null && cp3 == null && cp4 == null &&
                                cp1.GetComponent<Chessman>().player != player &&
                                cp2.GetComponent<Chessman>().player != player
                                )
                                {
                                    PointMovePlate(j, yBoard + (i + 1));
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                }
                WhitePawnMovePlate();
                break;
            case "blackCatapultPawn":
                BlackPawnMovePlate();
                break;
            case "whiteCatapultPawn":
                WhitePawnMovePlate();
                break;
            case "blackCamelPawn":
                BlackPawnMovePlate();
                break;
            case "whiteCamelPawn":
                WhitePawnMovePlate();
                break;

            case "blackElephantPawn":
                BlackPawnMovePlate();
                break;
            case "whiteElephantPawn":
                WhitePawnMovePlate();
                break;

            case "blackCommanderPawn":
                BlackPawnMovePlate();
                break;
            case "whiteCommanderPawn":
                WhitePawnMovePlate();
                break;

            case "blackKingPawn":
                BlackPawnMovePlate();
                break; 
            case "whiteKingPawn":
                WhitePawnMovePlate();
                break;

            case "blackQueenPawn":
                BlackPawnMovePlate();
                break;
            case "whiteQueenPawn":
                WhitePawnMovePlate();
                break;

            case "blackGiraffePawn":
                BlackPawnMovePlate();
                break;
            case "whiteGiraffePawn":
                WhitePawnMovePlate();
                break;

            case "blackDebbabePawn":
                BlackPawnMovePlate();
                break;
            case "whiteDebbabePawn":
                WhitePawnMovePlate();
                break;

            case "blackHorsePawn":
                BlackPawnMovePlate();
                break;
            case "whiteHorsePawn":
                WhitePawnMovePlate();
                break;

            case "blackRoofPawn":
                BlackPawnMovePlate();
                break;
            case "whiteRoofPawn":
                WhitePawnMovePlate();
                break;
            //---------------------------------------------------------
            case "blackKing":
                BlackKingMovePlateWithoutParameter();
                break;
            case "whiteKing":
                WhiteKingMovePlateWithoutParameter();
                break;
            case "blackQueen":
            case "whiteQueen":
                QueenMovePlate();
                break;
            case "blackCommander":
            case "whiteCommander":
                CommanderMovePlate();
                break;
            case "blackRoof":
            case "whiteRoof":
                RoofMovePlate();
                break;
            case "blackHorse":
            case "whiteHorse":
                HorseMovePlate();
                break;
            case "blackCamel":
            case "whiteCamel":
                CamelMovePlate();
                break;
            case "blackCatapult":
            case "whiteCatapult":
                CatapultMovePlate();
                break;
            case "blackGiraffe":
            case "whiteGiraffe":
                GiraffeMovePlate();
                break;
            case "blackElephant":
            case "whiteElephant":
                ElephantMovePlate();
                break;
            case "blackDebbabe":
            case "whiteDebbabe":
                DebbabeMovePlate();
                break;
            case "blackPrince":
                BlackKingMovePlateWithoutParameter();
                break;
            case "whitePrince":
                WhiteKingMovePlateWithoutParameter();
                break;


        }
    }

    public void OneLineMovePlate(int xIncrement, int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();
        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;


        if (sc.PositionOnBoard(x, y))
        {
            Chessman targetChessman = sc.GetPosition(x, y)?.GetComponent<Chessman>();

            

            if (targetChessman == null)
            {
                
                MovePlateSpawn(x, y);
            }
            else
            {
                
                if (targetChessman.player != player)
                {
                    GameObject cp = sc.GetPosition(x, y);

                    if (cp.name == "blackPawnPawn" && targetChessman.GetPosition().y == 9
                            || cp.name == "whitePawnPawn" && targetChessman.GetPosition().y == 0
                            || cp.name == "blackKing" || cp.name == "whiteKing")
                    {

                    }
                    else
                    {
                        MovePlateAttackSpawn(x, y);
                    }
                }
            }
        }

    }

    public void LineMovePlate(int xIncrement, int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) == null)
        {
            MovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;
        }

        if (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<Chessman>().player != player)
        {
            GameObject cp = sc.GetPosition(x, y);
            Chessman targetChessman = sc.GetPosition(x, y)?.GetComponent<Chessman>();

            if (cp.name == "blackPawnPawn" && targetChessman.GetPosition().y == 9
                    || cp.name == "whitePawnPawn" && targetChessman.GetPosition().y == 0
                    || cp.name == "blackKing" || cp.name == "whiteKing")
            {

            }
            else
            {
                MovePlateAttackSpawn(x, y);
            }

        }
    }

    public void PointMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {

            GameObject cp = sc.GetPosition(x, y);
            Chessman targetChessman = sc.GetPosition(x, y)?.GetComponent<Chessman>();

            if (cp == null)
            {
                MovePlateSpawn(x, y);
            }
            else if (cp.GetComponent<Chessman>().player != player)
            {
                if (cp.name == "blackPawnPawn" && targetChessman.GetPosition().y == 9
                    || cp.name == "whitePawnPawn" && targetChessman.GetPosition().y == 0
                    || cp.name == "blackKing" || cp.name == "whiteKing")
                {

                }
                else
                {
                    MovePlateAttackSpawn(x, y);
                }
            }
        }
    }

    public void BlackKingMovePlate(int xIncrement, int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();
        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;


        int ownChessmanX = xBoard;
        int ownChessManY = yBoard;
        Chessman myChessman = sc.GetPosition(ownChessmanX, ownChessManY)?.GetComponent<Chessman>();

        Vector2Int chessmanPosition = myChessman.GetPosition();

        if (chessmanPosition.x == 1 && chessmanPosition.y == 8 ||
            chessmanPosition.x == 1 && chessmanPosition.y == 9 ||
            chessmanPosition.x == 1 && chessmanPosition.y == 7)
        {
            MovePlateSpawn(0, 8);
        }
        if (chessmanPosition.x == 11 && chessmanPosition.y == 0 ||
            chessmanPosition.x == 11 && chessmanPosition.y == 1 ||
            chessmanPosition.x == 11 && chessmanPosition.y == 2)
        {
            MovePlateSpawn(12, 1);
        }



        if (sc.PositionOnBoard(x, y))
        {
            Chessman targetChessman = sc.GetPosition(x, y)?.GetComponent<Chessman>();

            if (targetChessman == null)
            {

                MovePlateSpawn(x, y);
            }
            else
            {

                if (targetChessman.player != player)
                {
                    GameObject cp = sc.GetPosition(x, y);

                    if (cp.name == "blackPawnPawn" && targetChessman.GetPosition().y == 9
                            || cp.name == "whitePawnPawn" && targetChessman.GetPosition().y == 0
                            || cp.name == "blackKing" || cp.name == "whiteKing")
                    {

                    }
                    else
                    {
                        MovePlateAttackSpawn(x, y);
                    }
                }
            }
        }

    }

    public void WhiteKingMovePlate(int xIncrement, int yIncrement)
    {


        Game sc = controller.GetComponent<Game>();
        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;



        int ownChessmanX = xBoard;
        int ownChessmanY = yBoard;
        Chessman myChessman = sc.GetPosition(ownChessmanX, ownChessmanY)?.GetComponent<Chessman>();

        Vector2Int chessmanPosition = myChessman.GetPosition();

        if (chessmanPosition.x == 1 && chessmanPosition.y == 8 ||
            chessmanPosition.x == 1 && chessmanPosition.y == 9 ||
            chessmanPosition.x == 1 && chessmanPosition.y == 7)
        {
            MovePlateSpawn(0, 8);
        }

        if (chessmanPosition.x == 11 && chessmanPosition.y == 0 ||
            chessmanPosition.x == 11 && chessmanPosition.y == 1 ||
            chessmanPosition.x == 11 && chessmanPosition.y == 2)
        {
            MovePlateSpawn(12, 1);
        }

        if (sc.PositionOnBoard(x, y))
        {
            Chessman targetChessman = sc.GetPosition(x, y)?.GetComponent<Chessman>();

            if (targetChessman == null)
            {

                MovePlateSpawn(x, y);
            }
            else
            {

                if (targetChessman.player != player)
                {
                    GameObject cp = sc.GetPosition(x, y);

                    if (cp.name == "blackPawnPawn" && targetChessman.GetPosition().y == 9
                            || cp.name == "whitePawnPawn" && targetChessman.GetPosition().y == 0
                            || cp.name == "blackKing" || cp.name == "whiteKing")
                    {

                    }
                    else
                    {
                        MovePlateAttackSpawn(x, y);
                    }
                }
            }




        }
    }

    public void PawnMovePlate(int xIncrement, int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();
        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;


        if (sc.PositionOnBoard(x, y))
        {

            Chessman targetChessman = sc.GetPosition(x, y)?.GetComponent<Chessman>();

            if (targetChessman == null)
            {
                MovePlateSpawn(x, y);
            }
            if (sc.PositionOnBoard(x + 1, y)
            && sc.GetPosition(x + 1, y) != null
            && sc.GetPosition(x + 1, y).name != "blackKing"
            && sc.GetPosition(x + 1, y).name != "whiteKing"
            && sc.GetPosition(x + 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x + 1, y);
            }
            if (sc.PositionOnBoard(x - 1, y)
            && sc.GetPosition(x - 1, y) != null
            && sc.GetPosition(x - 1, y).name != "blackKing"
            && sc.GetPosition(x - 1, y).name != "whiteKing"
            && sc.GetPosition(x - 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x - 1, y);
            }



        }


    }

    // Pieces move function
    public void BlackPawnMovePlate()
    {
        PawnMovePlate(0, 1);
    }

    public void WhitePawnMovePlate()
    {
        PawnMovePlate(0, -1);
    }

    public void QueenMovePlate()
    {
        OneLineMovePlate(1, 0);
        OneLineMovePlate(0, 1);
        OneLineMovePlate(0, -1);
        OneLineMovePlate(-1, 0);
    }

    public void CommanderMovePlate()
    {
        OneLineMovePlate(1, 1);
        OneLineMovePlate(-1, 1);
        OneLineMovePlate(1, -1);
        OneLineMovePlate(-1, -1);
    }

    public void BlackKingMovePlateWithoutParameter()
    {
        BlackKingMovePlate(1, 0);
        BlackKingMovePlate(0, 1);
        BlackKingMovePlate(1, 1);
        BlackKingMovePlate(-1, 0);
        BlackKingMovePlate(0, -1);
        BlackKingMovePlate(-1, -1);
        BlackKingMovePlate(-1, 1);
        BlackKingMovePlate(1, -1);
    }

    public void WhiteKingMovePlateWithoutParameter()
    {
        WhiteKingMovePlate(1, 0);
        WhiteKingMovePlate(0, 1);
        WhiteKingMovePlate(1, 1);
        WhiteKingMovePlate(-1, 0);
        WhiteKingMovePlate(0, -1);
        WhiteKingMovePlate(-1, -1);
        WhiteKingMovePlate(-1, 1);
        WhiteKingMovePlate(1, -1);
    }

    public void RoofMovePlate()
    {
        LineMovePlate(1, 0);
        LineMovePlate(0, 1);
        LineMovePlate(0, -1);
        LineMovePlate(-1, 0);
    }

    public void HorseMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }

    public void CamelMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 3);
        PointMovePlate(xBoard - 1, yBoard + 3);
        PointMovePlate(xBoard + 3, yBoard + 1);
        PointMovePlate(xBoard + 3, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 3);
        PointMovePlate(xBoard - 1, yBoard - 3);
        PointMovePlate(xBoard - 3, yBoard + 1);
        PointMovePlate(xBoard - 3, yBoard - 1);
    }
    public void CatapultMovePlate()
    {
        PointMovePlate(xBoard + 2, yBoard);
        PointMovePlate(xBoard - 2, yBoard);
        PointMovePlate(xBoard, yBoard + 2);
        PointMovePlate(xBoard, yBoard - 2);
    }

    public void ElephantMovePlate()
    {
        PointMovePlate(xBoard + 2, yBoard+2);
        PointMovePlate(xBoard + 2, yBoard-2);
        PointMovePlate(xBoard-2, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 2);

        PointMovePlate(xBoard + 3, yBoard + 3);
        PointMovePlate(xBoard + 3, yBoard - 3);
        PointMovePlate(xBoard - 3, yBoard - 3);
        PointMovePlate(xBoard - 3, yBoard + 3);
    }

    // Debbabe move ----------------------------------------------------------------------
    public void DebbabeMovePlate()
    {
            for (int i = 2; i < 11; i++)
            {
                if (!HasPieceInDiagonalDirection(xBoard, yBoard, xBoard + i, yBoard + i))
                {
                    PointMovePlate(xBoard + i, yBoard + i);
                }

                if (!HasPieceInDiagonalDirection(xBoard, yBoard, xBoard + i, yBoard - i))
                {
                    PointMovePlate(xBoard + i, yBoard - i);
                }

                if (!HasPieceInDiagonalDirection(xBoard, yBoard, xBoard - i, yBoard - i))
                {
                    PointMovePlate(xBoard - i, yBoard - i);
                }

                if (!HasPieceInDiagonalDirection(xBoard, yBoard, xBoard - i, yBoard + i))
                {
                    PointMovePlate(xBoard - i, yBoard + i);
                }
            }
        
    }

    public bool HasPieceInDiagonalDirection(int startX, int startY, int endX, int endY)
    {
        int dx = Mathf.Abs(endX - startX);
        int dy = Mathf.Abs(endY - startY);

        // Çapraz yönde hareket etmiyorsa false döndür
        if (dx != dy)
        {
            return false;
        }

        int xIncrement = (endX > startX) ? 1 : -1;
        int yIncrement = (endY > startY) ? 1 : -1;

        int x = startX + xIncrement;
        int y = startY + yIncrement;

        while (x != endX && y != endY)
        {
            Game sc = controller.GetComponent<Game>();
            if (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) != null)
            {
                return true; // Çaprazda taş var
            }
            x += xIncrement;
            y += yIncrement;
        }

        return false; // Çaprazda taş yok
    }
    // -----------------------------------------------------------------------------------


    // Giraffe move ----------------------------------------------------------------------
    public void GiraffeMovePlate()
    {
        for (int i = 4; i < 11; i++)
        {
            if (CanMoveTo(xBoard + 1, yBoard + i) && NoObstaclesOnPath(xBoard + 1, yBoard, xBoard + 1, yBoard + i))
                PointMovePlate(xBoard + 1, yBoard + i);

            if (CanMoveTo(xBoard - 1, yBoard + i) && NoObstaclesOnPath(xBoard - 1, yBoard, xBoard - 1, yBoard + i))
                PointMovePlate(xBoard - 1, yBoard + i);

            if (CanMoveTo(xBoard + i, yBoard + 1) && NoObstaclesOnPath(xBoard, yBoard + 1, xBoard + i, yBoard + 1))
                PointMovePlate(xBoard + i, yBoard + 1);

            if (CanMoveTo(xBoard + i, yBoard - 1) && NoObstaclesOnPath(xBoard, yBoard - 1, xBoard + i, yBoard - 1))
                PointMovePlate(xBoard + i, yBoard - 1);

            if (CanMoveTo(xBoard + 1, yBoard - i) && NoObstaclesOnPath(xBoard + 1, yBoard, xBoard + 1, yBoard - i))
                PointMovePlate(xBoard + 1, yBoard - i);

            if (CanMoveTo(xBoard - 1, yBoard - i) && NoObstaclesOnPath(xBoard - 1, yBoard, xBoard - 1, yBoard - i))
                PointMovePlate(xBoard - 1, yBoard - i);

            if (CanMoveTo(xBoard - i, yBoard + 1) && NoObstaclesOnPath(xBoard, yBoard + 1, xBoard - i, yBoard + 1))
                PointMovePlate(xBoard - i, yBoard + 1);

            if (CanMoveTo(xBoard - i, yBoard - 1) && NoObstaclesOnPath(xBoard, yBoard - 1, xBoard - i, yBoard - 1))
                PointMovePlate(xBoard - i, yBoard - 1);
        }
    }

    public bool CanMoveTo(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject cp = sc.GetPosition(x, y);
            // Eğer hedef kare boş veya farklı bir oyuncuya aitse hareket edilebilir
            return cp == null || cp.GetComponent<Chessman>().player != player;
        }
        return false;
    }

    public bool NoObstaclesOnPath(int xStart, int yStart, int xEnd, int yEnd)
    {
        // Yol üzerinde herhangi bir taş kontrolü yapar
        int dx = xEnd - xStart;
        int dy = yEnd - yStart;
        int steps = Mathf.Max(Mathf.Abs(dx), Mathf.Abs(dy));

        if (steps <= 1)
            return true;

        int xIncrement = Mathf.RoundToInt((float)dx / steps);
        int yIncrement = Mathf.RoundToInt((float)dy / steps);

        for (int i = 1; i < steps; i++)
        {
            int xNext = xStart + xIncrement * i;
            int yNext = yStart + yIncrement * i;

            Game sc = controller.GetComponent<Game>();
            if (sc.PositionOnBoard(xNext, yNext))
            {
                GameObject cp = sc.GetPosition(xNext, yNext);
                if (cp != null)
                    return false;
            }
        }
        return true;
    }
    //-------------------------------------------------------------------------------------

    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        //Get the board value in order to convert to xy coords
        float x = matrixX;
        float y = matrixY;
        
        
        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -1.0f), Quaternion.identity);
        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetCoords(matrixX, matrixY);
        mpScript.SetReference(gameObject);
        
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        //Get the board value in order to convert to xy coords
        float x = matrixX;
        float y = matrixY;
        
        
        
            GameObject mp = Instantiate(movePlate, new Vector3(x, y, -1.0f), Quaternion.identity);
            MovePlate mpScript = mp.GetComponent<MovePlate>();
            mpScript.attack = true;
            mpScript.SetReference(gameObject);
            mpScript.SetCoords(matrixX, matrixY);
    }

    public void Update()
    {   
        switch (this.name)
        {
            case "blackCatapultPawn":
                if (yBoard == 9 && player == "black")
                {
                    this.GetComponent<SpriteRenderer>().sprite = blackCatapult;
                    this.name = "blackCatapult";
                }
                break;
            case "whiteCatapultPawn":
                if (yBoard == 0 && player == "white")
                {
                    this.GetComponent<SpriteRenderer>().sprite = whiteCatapult;
                    this.name = "whiteCatapult";
                }
                break;
            case "blackCamelPawn":
                if (yBoard == 9 && player == "black")
                {
                    this.GetComponent<SpriteRenderer>().sprite = blackCamel;
                    this.name = "blackCamel";
                }
                break;
            case "whiteCamelPawn":
                if (yBoard == 0 && player == "white")
                {
                    this.GetComponent<SpriteRenderer>().sprite = whiteCamel;
                    this.name = "whiteCamel";
                }
                break;

            case "blackElephantPawn":
                if (yBoard == 9 && player == "black")
                {
                    this.GetComponent<SpriteRenderer>().sprite = blackElephant;
                    this.name = "blackElephant";
                }
                break;
            case "whiteElephantPawn":
                if (yBoard == 0 && player == "white")
                {
                    this.GetComponent<SpriteRenderer>().sprite = whiteElephant;
                    this.name = "whiteElephant";
                }
                break;

            case "blackCommanderPawn":
                if (yBoard == 9 && player == "black")
                {
                    this.GetComponent<SpriteRenderer>().sprite = blackCommander;
                    this.name = "blackCommander";
                }
                break;
            case "whiteCommanderPawn":
                if (yBoard == 0 && player == "white")
                {
                    this.GetComponent<SpriteRenderer>().sprite = whiteCommander;
                    this.name = "whiteCommander";
                }
                break;

            case "blackKingPawn":
                if (yBoard == 9 && player == "black")
                {
                    this.GetComponent<SpriteRenderer>().sprite = blackPrince;
                    this.name = "blackPrince";
                }
                break;
            case "whiteKingPawn":
                if (yBoard == 0 && player == "white")
                {
                    this.GetComponent<SpriteRenderer>().sprite = whitePrince;
                    this.name = "whitePrince";
                }
                break;

            case "blackQueenPawn":
                if (yBoard == 9 && player == "black")
                {
                    this.GetComponent<SpriteRenderer>().sprite = blackQueen;
                    this.name = "blackQueen";
                }
                break;
            case "whiteQueenPawn":
                if (yBoard == 0 && player == "white")
                {
                    this.GetComponent<SpriteRenderer>().sprite = whiteQueen;
                    this.name = "whiteQueen";
                }
                break;

            case "blackGiraffePawn":
                if (yBoard == 9 && player == "black")
                {
                    this.GetComponent<SpriteRenderer>().sprite = blackGiraffe;
                    this.name = "blackGiraffe";
                }
                break;
            case "whiteGiraffePawn":
                if (yBoard == 0 && player == "white")
                {
                    this.GetComponent<SpriteRenderer>().sprite = whiteGiraffe;
                    this.name = "whiteGiraffe";
                }
                break;

            case "blackDebbabePawn":
                if (yBoard == 9 && player == "black")
                {
                    this.GetComponent<SpriteRenderer>().sprite = blackDebbabe;
                    this.name = "blackDebbabe";
                }
                break;
            case "whiteDebbabePawn":
                if (yBoard == 0 && player == "white")
                {
                    this.GetComponent<SpriteRenderer>().sprite = whiteDebbabe;
                    this.name = "whiteDebbabe";
                }
                break;

            case "blackHorsePawn":
                if (yBoard == 9 && player == "black")
                {
                    this.GetComponent<SpriteRenderer>().sprite = blackHorse;
                    this.name = "blackHorse";
                }
                break;
            case "whiteHorsePawn":
                if (yBoard == 0 && player == "white")
                {
                    this.GetComponent<SpriteRenderer>().sprite = whiteHorse;
                    this.name = "whiteHorse";
                }
                break;

            case "blackRoofPawn":
                if (yBoard == 9 && player == "black")
                {
                    this.GetComponent<SpriteRenderer>().sprite = blackRoof;
                    this.name = "blackRoof";
                }
                break;
            case "whiteRoofPawn":
                if (yBoard == 0 && player == "white")
                {
                    this.GetComponent<SpriteRenderer>().sprite = whiteRoof;
                    this.name = "whiteRoof";
                }
                break;

            case "blackPawnPawn":
                if (yBoard == 9 && player == "black")
                {
                    this.GetComponent<SpriteRenderer>().sprite = blackPawnPawnFirstPromote;
                    this.name = "blackPawnPawnFirstPromote";
                }
                break;

            case "whitePawnPawn":
                if (yBoard == 0 && player == "white")
                {
                    this.GetComponent<SpriteRenderer>().sprite = whitePawnPawnFirstPromote;
                    this.name = "whitePawnPawnFirstPromote";
                }
                break;
            case "blackKing":
                if (xBoard == 0 && yBoard == 8 && player == "black")
                {
                    controller.GetComponent<Game>().Winner("Black");
                }
                break;
            case "whiteKing":
                if (xBoard == 12 && yBoard == 1 && player == "white")
                {
                    controller.GetComponent<Game>().Winner("White");
                }
                break;
            case "blackPrince":
                if (xBoard == 0 && yBoard == 8 && player == "black")
                {
                    controller.GetComponent<Game>().Winner("Black");
                }
                break;
            case "whitePrince":
                if (xBoard == 12 && yBoard == 1 && player == "white")
                {
                    controller.GetComponent<Game>().Winner("White");
                }
                break;
        }
    }



}
