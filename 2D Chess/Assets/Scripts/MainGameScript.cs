using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameScript : MonoBehaviour
{
    // referring to the ChessPiece object in the game
    public GameObject chessPiece;

    // Positions for the chesspieces in the Chessboard
    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] whitePlayer = new GameObject[16];
    private GameObject[] blackPlayer = new GameObject[16];

    // Logics
    private string currentPlayer = "WHITE";
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // Array for the positions for the chesspieces (Created transform)

        whitePlayer = new GameObject[]
        {
            Create("whiteRook", 0, 0), Create("whiteKnight", 1, 0), Create("whiteBishop", 2, 0),
            Create("whiteQueen", 3, 0), Create("whiteKing", 4, 0), Create("whiteBishop", 5, 0),
            Create("whiteKnight", 6, 0), Create("whiteRook", 7, 0), Create("whitePawn", 0, 1),
            Create("whitePawn", 1, 1), Create("whitePawn", 2, 1), Create("whitePawn", 3, 1),
            Create("whitePawn", 4, 1), Create("whitePawn", 5, 1), Create("whitePawn", 6, 1),
            Create("whitePawn", 7, 1)
        };

        blackPlayer = new GameObject[]
        {
            Create("blackRook", 0, 7), Create("blackKnight", 1, 7), Create("blackBishop", 2, 7),
            Create("blackQueen", 3, 7), Create("blackKing", 4, 7), Create("blackBishop", 5, 7),
            Create("blackKnight", 6, 7), Create("blackRook", 7, 7), Create("blackPawn", 0, 6),
            Create("blackPawn", 1, 6), Create("blackPawn", 2, 6), Create("blackPawn", 3, 6),
            Create("blackPawn", 4, 6), Create("blackPawn", 5, 6), Create("blackPawn", 6, 6),
            Create("blackPawn", 7, 6)
        };

        for (int i=0;i<whitePlayer.Length;i++)
        {
            setPosition(whitePlayer[i]);
            setPosition(blackPlayer[i]);
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject chessObj = Instantiate(chessPiece, new(0, 0, -1), Quaternion.identity);
        ChessPiecesPlaces cpp = chessObj.GetComponent<ChessPiecesPlaces>();
        cpp.name = name;
        cpp.setXBoard(x);
        cpp.setYBoard(y);
        cpp.Activate();
        return chessObj;
    }

    public void setPosition(GameObject chessObj)
    {
        ChessPiecesPlaces cpp = chessObj.GetComponent<ChessPiecesPlaces>();

        positions[cpp.getXBoard(), cpp.getYBoard()] = chessObj;
    }
}
