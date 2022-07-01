using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiecesPlaces : MonoBehaviour
{
    // References (Objects)
    public GameObject gameController;
    // public GameObject moveMech;

    // References (Sprites)
    public Sprite whitePawn, whiteKnight, whiteBishop, whiteRook, whiteQueen, whiteKing;
    public Sprite blackPawn, blackKnight, blackBishop, blackRook, blackQueen, blackKing;

    // Places and Positions
    private int xBoard = -1;
    private int yBoard = -1;

    // Chess Players (White and Black)
    private string player;

    // Activated
    public void Activate()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");

        // Set the starting point of the pieces transform
        setCoordinates();

        switch (this.name)
        {
            case "whitePawn": this.GetComponent<SpriteRenderer>().sprite = whitePawn; break;
            case "whiteKnight": this.GetComponent<SpriteRenderer>().sprite = whiteKnight; break;
            case "whiteBishop": this.GetComponent<SpriteRenderer>().sprite = whiteBishop; break;
            case "whiteRook": this.GetComponent<SpriteRenderer>().sprite = whiteRook; break;
            case "whiteQueen": this.GetComponent<SpriteRenderer>().sprite = whiteQueen; break;
            case "whiteKing": this.GetComponent<SpriteRenderer>().sprite = whiteKing; break;

            case "blackPawn": this.GetComponent<SpriteRenderer>().sprite = blackPawn; break;
            case "blackKnight": this.GetComponent<SpriteRenderer>().sprite = blackKnight; break;
            case "blackBishop": this.GetComponent<SpriteRenderer>().sprite = blackBishop; break;
            case "blackRook": this.GetComponent<SpriteRenderer>().sprite = blackRook; break;
            case "blackQueen": this.GetComponent<SpriteRenderer>().sprite = blackQueen; break;
            case "blackKing": this.GetComponent<SpriteRenderer>().sprite = blackKing; break;
        }
    }

    public void setCoordinates()
    {
        float x = xBoard;
        float y = yBoard;

        // x1 = spaces in between, <- = close, -> = far
        // y1 = spaces in between, <- = close, -> = far
        // x2 = place, <- = left, -> = right
        // y2 = place, <- down, -> up
        x *= 0.925f;
        y *= 0.92f;

        x += -6.9f;
        y += -3.03f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int getXBoard()
    {
        return xBoard;
    }

    public int getYBoard()
    {
        return yBoard;
    }

    public void setXBoard(int x)
    {
        xBoard = x;
    }

    public void setYBoard(int y)
    {
        yBoard = y;
    }
}
