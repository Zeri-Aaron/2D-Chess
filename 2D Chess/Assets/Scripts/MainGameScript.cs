using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameScript : MonoBehaviour
{
    // referring to the ChessPiece object in the game
    public GameObject chessPiece;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(chessPiece, new Vector3(924, 1, -1), Quaternion.identity);
    }
}
