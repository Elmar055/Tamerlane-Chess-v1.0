using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is to be added as a component to the MovePlate prefab.
public class MovePlate : MonoBehaviour
{
    // Reference to controller object with GameController tag
    public GameObject controller;

    // To show the moveplate path
    GameObject reference = null;

    // Moveplate position coordinates
    int matrixX;
    int matrixY;

    // Function for gt positions of moveplate
    public Vector2Int GetPosition()
    {
        return new Vector2Int(matrixX, matrixY);
    }

    // Function that adjusts the moveplate position
    public void SetPosition(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    // This is used for detect attack
    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
            // Change color on attack
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 0 ,  0 , 0.6f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack)
        {
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);


            if (cp.name == "whiteKing") controller.GetComponent<Game>().Winner("Black");
            if (cp.name == "blackKing") controller.GetComponent<Game>().Winner("White");

            Destroy(cp);
        }

        //Set the Chesspiece's original location to be empty
        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Chessman>().GetXBoard(),
            reference.GetComponent<Chessman>().GetYBoard());

        //Move reference chess piece to this position
        reference.GetComponent<Chessman>().SetXBoard(matrixX);
        reference.GetComponent<Chessman>().SetYBoard(matrixY);
        reference.GetComponent<Chessman>().SetCoords();

        //Update the matrix
        controller.GetComponent<Game>().SetPosition(reference);

        controller.GetComponent<Game>().NextTurn();

        reference.GetComponent<Chessman>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }

    

}
