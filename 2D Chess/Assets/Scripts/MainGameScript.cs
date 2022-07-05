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
            Create("White Rook", 0, 0), Create("White Knight", 1, 0), Create("White Bishop", 2, 0),
            Create("White Queen", 3, 0), Create("White King", 4, 0), Create("White Bishop", 5, 0),
            Create("White Knight", 6, 0), Create("White Rook", 7, 0), Create("White Pawn", 0, 1),
            Create("White Pawn", 1, 1), Create("White Pawn", 2, 1), Create("White Pawn", 3, 1),
            Create("White Pawn", 4, 1), Create("White Pawn", 5, 1), Create("White Pawn", 6, 1),
            Create("White Pawn", 7, 1)
        };

        blackPlayer = new GameObject[]
        {
            Create("Black Rook", 0, 7), Create("Black Knight", 1, 7), Create("Black Bishop", 2, 7),
            Create("Black Queen", 3, 7), Create("Black King", 4, 7), Create("Black Bishop", 5, 7),
            Create("Black Knight", 6, 7), Create("Black Rook", 7, 7), Create("Black Pawn", 0, 6),
            Create("Black Pawn", 1, 6), Create("Black Pawn", 2, 6), Create("Black Pawn", 3, 6),
            Create("Black Pawn", 4, 6), Create("Black Pawn", 5, 6), Create("Black Pawn", 6, 6),
            Create("Black Pawn", 7, 6)
        };

        for (int i=0;i<whitePlayer.Length;i++)
        {
            SetPosition(whitePlayer[i]);
            SetPosition(blackPlayer[i]);
        }
    }

    // Placing the chess pieces when the game starts
    public GameObject Create(string name, int x, int y)
    {
        GameObject chessObj = Instantiate(chessPiece, new(0, 0, -3), Quaternion.identity);
        ChessPiecesPlaces cpp = chessObj.GetComponent<ChessPiecesPlaces>();
        cpp.name = name;
        cpp.SetXBoard(x);
        cpp.SetYBoard(y);
        cpp.Activate();
        return chessObj;
    }

    // Setting the chess pieces' right positoins at whole on the chessboard
    public void SetPosition(GameObject chessObj)
    {
        ChessPiecesPlaces cpp = chessObj.GetComponent<ChessPiecesPlaces>();

        positions[cpp.GetXBoard(), cpp.GetYBoard()] = chessObj;
    }


    // Getters and setters for the positions
    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }


    // LOGIC: if a chess piece is out of the board then return false, otherwise it is inside the board return true
    public bool PositionPieceOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1))
            return false;
        return true;
    }
}
