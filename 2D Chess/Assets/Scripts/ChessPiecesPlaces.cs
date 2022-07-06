using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiecesPlaces : MonoBehaviour
{
    // References (Objects)
    public GameObject gameController;
    // public GameObject moveMech;
    public GameObject referencePlate;

    // References (Sprites)
    public Sprite whitePawn, whiteKnight, whiteBishop, whiteRook, whiteQueen, whiteKing;
    public Sprite blackPawn, blackKnight, blackBishop, blackRook, blackQueen, blackKing;

    // Places and Positions
    private int xBoard = -1;
    private int yBoard = -1;

    // Chess Players (White and Black)
    private string player;

    // Activating the game controller, coordinates of each chess piece, and chess pieces
    public void Activate()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");

        // Set the starting point of the pieces transform
        SetCoordinates();

        switch (this.name)
        {
            case "White Pawn": this.GetComponent<SpriteRenderer>().sprite = whitePawn; player = "white"; break;
            case "White Knight": this.GetComponent<SpriteRenderer>().sprite = whiteKnight; player = "white"; break;
            case "White Bishop": this.GetComponent<SpriteRenderer>().sprite = whiteBishop; player = "white"; break;
            case "White Rook": this.GetComponent<SpriteRenderer>().sprite = whiteRook; player = "white"; break;
            case "White Queen": this.GetComponent<SpriteRenderer>().sprite = whiteQueen; player = "white"; break;
            case "White King": this.GetComponent<SpriteRenderer>().sprite = whiteKing; player = "white"; break;

            case "Black Pawn": this.GetComponent<SpriteRenderer>().sprite = blackPawn; player = "black"; break;
            case "Black Knight": this.GetComponent<SpriteRenderer>().sprite = blackKnight; player = "black"; break;
            case "Black Bishop": this.GetComponent<SpriteRenderer>().sprite = blackBishop; player = "black"; break;
            case "Black Rook": this.GetComponent<SpriteRenderer>().sprite = blackRook; player = "black"; break;
            case "Black Queen": this.GetComponent<SpriteRenderer>().sprite = blackQueen; player = "black"; break;
            case "Black King": this.GetComponent<SpriteRenderer>().sprite = blackKing; player = "black"; break;
        }
    }

    // Setting the coordinates where the chess pieces will spawn or initiate
    public void SetCoordinates()
    {
        float x = xBoard;
        float y = yBoard;

        // x1 = spaces in between, <- = close, -> = far
        // y1 = spaces in between, <- = close, -> = far
        // x2 = place, <- = left, -> = right
        // y2 = place, <- down, -> up
        x *= 0.924f;
        y *= 0.92f;

        x += -6.89f;
        y += -3.20f;

        this.transform.position = new Vector3(x, y, -3.0f);
    }

    // Getter and Setter Algorithm (Making the code cleaner and maintainable)
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

    // Built-in function in Unity that lets the user work with 2D Collider when mouse is clicked
    public void OnMouseUp()
    {
        DestroyReferencePlates();

        InitiateReferencePlates();
    }

    // Destroying each reference plate by finding objects with tag named "RefPlate" function
    public void DestroyReferencePlates()
    {
        GameObject[] referencePlates = GameObject.FindGameObjectsWithTag("RefPlate");
        for (int i=0;i<referencePlates.Length;i++)
        {
            Destroy(referencePlates[i]);
        }
    }

    // Movement algorithm of each chess piece on the board. Reference plates are applied as guide on placing the chess pieces correctly
    public void InitiateReferencePlates()
    {
        switch (this.name)
        {
            // References of the plates for the legal moves of each chess piece on the board
            case "White Pawn":
                if (yBoard == 1)
                {
                    PawnReferencePlate(xBoard, yBoard + 1);
                    PawnReferencePlate(xBoard, yBoard + 2);
                } 
                else
                {
                    PawnReferencePlate(xBoard, yBoard + 1);
                }
                break;
            case "Black Pawn":
                if (yBoard == 6)
                {
                    PawnReferencePlate(xBoard, yBoard - 1);
                    PawnReferencePlate(xBoard, yBoard - 2);
                }
                else
                {
                    PawnReferencePlate(xBoard, yBoard - 1);
                }
                break;

            case "White Knight":
            case "Black Knight":
                LShapeReferencePlate();
                break;

            case "White Bishop":
            case "Black Bishop":
                GeneralLineReferencePlate(1, 1);
                GeneralLineReferencePlate(-1, 1);
                GeneralLineReferencePlate(-1, -1);
                GeneralLineReferencePlate(1, -1);
                break;

            case "White Rook":
            case "Black Rook":
                GeneralLineReferencePlate(1, 0);
                GeneralLineReferencePlate(0, 1);
                GeneralLineReferencePlate(-1, 0);
                GeneralLineReferencePlate(0, -1);
                break;

            case "White Queen":
            case "Black Queen":
                GeneralLineReferencePlate(1, 0);
                GeneralLineReferencePlate(1, 1);
                GeneralLineReferencePlate(0, 1);
                GeneralLineReferencePlate(-1, 1);
                GeneralLineReferencePlate(-1, 0);
                GeneralLineReferencePlate(-1, -1);
                GeneralLineReferencePlate(0, -1);
                GeneralLineReferencePlate(1, -1);
                break;

            case "White King":
            case "Black King":
                OneReferencePlate();
                break;


        }
    }

    // Function of general movement pattern of chess pieces
    public void GeneralLineReferencePlate(int xDisplacement, int yDisplacement)
    {
        MainGameScript mainGame = gameController.GetComponent<MainGameScript>();

        int x = xBoard + xDisplacement;
        int y = yBoard + yDisplacement; 

        while (mainGame.PositionPieceOnBoard(x, y) && mainGame.GetPosition(x, y) == null)
        {
            ReferencePlateCreate(x, y);

            x += xDisplacement;
            y += yDisplacement;
        }

        if (mainGame.PositionPieceOnBoard(x, y) && 
            mainGame.GetPosition(x, y).GetComponent<ChessPiecesPlaces>().player != player)
        {
            ReferencePlateAttackCreate(x, y);
        }
    }

    // Special movement function for the Knight
    public void LShapeReferencePlate()
    {
        PlaceReferencePlate(xBoard + 2, yBoard + 1);
        PlaceReferencePlate(xBoard + 1, yBoard + 2); 
        PlaceReferencePlate(xBoard - 1, yBoard + 2); 
        PlaceReferencePlate(xBoard - 2, yBoard + 1);
        PlaceReferencePlate(xBoard - 2, yBoard - 1);
        PlaceReferencePlate(xBoard - 1, yBoard - 2);
        PlaceReferencePlate(xBoard + 1, yBoard - 2);
        PlaceReferencePlate(xBoard + 2, yBoard - 1);
    }

    // Special movement function for the King
    public void OneReferencePlate()
    {
        PlaceReferencePlate(xBoard + 1, yBoard);
        PlaceReferencePlate(xBoard + 1, yBoard + 1);
        PlaceReferencePlate(xBoard, yBoard + 1);
        PlaceReferencePlate(xBoard - 1, yBoard + 1);
        PlaceReferencePlate(xBoard - 1, yBoard);
        PlaceReferencePlate(xBoard - 1, yBoard - 1);
        PlaceReferencePlate(xBoard, yBoard - 1);
        PlaceReferencePlate(xBoard + 1, yBoard - 1);
    }

    // Function for the algorithm on placing the reference plates along with the selected chess pieces
    public void PlaceReferencePlate(int x, int y)
    {
        MainGameScript mainGame = gameController.GetComponent<MainGameScript>();
        if (mainGame.PositionPieceOnBoard(x, y))
        {
            GameObject chessPiecePosition = mainGame.GetPosition(x, y);

            if (chessPiecePosition == null)
            {
                ReferencePlateCreate(x, y);
            }
            else if (chessPiecePosition.GetComponent<ChessPiecesPlaces>().player != player)
            {
                ReferencePlateAttackCreate(x, y);
            }
        }
    }

    // Special algorithm for pawn movement
    public void PawnReferencePlate(int x, int y)
    {
        MainGameScript mainGame = gameController.GetComponent<MainGameScript>();

        if (mainGame.PositionPieceOnBoard(x, y))
        {
            if (mainGame.GetPosition(x, y) == null)
            {
                ReferencePlateCreate(x, y);
            }

            if (mainGame.PositionPieceOnBoard(x + 1, y) && mainGame.GetPosition(x + 1, y) != null
                && mainGame.GetPosition(x + 1, y).GetComponent<ChessPiecesPlaces>().player != player)
            {
                ReferencePlateAttackCreate(x + 1, y);
            }

            if (mainGame.PositionPieceOnBoard(x - 1, y) && mainGame.GetPosition(x - 1, y) != null
                && mainGame.GetPosition(x - 1, y).GetComponent<ChessPiecesPlaces>().player != player)
            {
                ReferencePlateAttackCreate(x - 1, y);
            }
        }
    }

    // Function for the movement of the chesspieces when ONLY MOVING and by showing or creating the reference plates
    public void ReferencePlateCreate(int positionX, int positionY)
    {
        float x = positionX;
        float y = positionY;

        // x1 = spaces in between, <- = close, -> = far
        // y1 = spaces in between, <- = close, -> = far
        // x2 = place, <- = left, -> = right
        // y2 = place, <- down, -> up
        x *= 0.925f;
        y *= 0.92f;

        x += -6.9f;
        y += -3.22f;

        GameObject placingPosition = Instantiate(referencePlate, new Vector3(x, y, -2.0f), Quaternion.identity);

        Plate plate = placingPosition.GetComponent<Plate>();
        plate.SetReference(gameObject);
        plate.SetCoordinates(positionX, positionY);
    }

    // Function for the movement of the chesspieces when ATTACKING and by showing or creating the reference plates
    public void ReferencePlateAttackCreate(int positionX, int positionY)
    {
        float x = positionX;
        float y = positionY;

        x *= 0.925f;
        y *= 0.92f;

        x += -6.9f;
        y += -3.22f;

        GameObject placingPosition = Instantiate(referencePlate, new Vector3(x, y, -2.0f), Quaternion.identity);

        Plate plate = placingPosition.GetComponent<Plate>();
        plate.attackingPiece = true;
        plate.SetReference(gameObject);
        plate.SetCoordinates(positionX, positionY);
    }
}
