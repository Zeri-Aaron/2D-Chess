using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public GameObject gameController;

    GameObject referencePlate = null;

    // Board positions that is predefined
    int positionX;
    int positionY;

    // false = moving | true = attacking
    public bool attackingPiece = false;

    public void Start()
    {
        if (attackingPiece)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
        }
    }

    public void OnMouseUp()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");

        {
            if (attackingPiece)
            {
                GameObject chessPiece = gameController.GetComponent<MainGameScript>().
                    GetPosition(positionX, positionY);
                Destroy(chessPiece);
            }

            gameController.GetComponent<MainGameScript>().SetPositionEmpty(
                referencePlate.GetComponent<ChessPiecesPlaces>().GetXBoard(),
                referencePlate.GetComponent<ChessPiecesPlaces>().GetYBoard());

            referencePlate.GetComponent<ChessPiecesPlaces>().SetXBoard(positionX);
            referencePlate.GetComponent<ChessPiecesPlaces>().SetYBoard(positionY);
            referencePlate.GetComponent<ChessPiecesPlaces>().SetCoordinates();

            gameController.GetComponent<MainGameScript>().SetPosition(referencePlate);

            gameController.GetComponent<MainGameScript>().NextPlayerTurn();

            referencePlate.GetComponent<ChessPiecesPlaces>().DestroyReferencePlates();
        }
    }

    public void SetCoordinates(int x, int y)
    {
        positionX = x;
        positionY = y;
    }

    public void SetReference(GameObject gameObj)
    {
        referencePlate = gameObj;
    }

    public GameObject GetReference()
    {
        return referencePlate;
    }
}
