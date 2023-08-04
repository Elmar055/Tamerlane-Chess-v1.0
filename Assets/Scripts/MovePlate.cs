using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    public bool attack = false;

    public void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;

            //transform.localScale = new Vector2(1.4f, 1.4f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack)
        {
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

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
