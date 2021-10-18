using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GenerateBoard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CellScript cell;
    [SerializeField] private Piece pawn;
    public GameObject king;
    public GameObject queen;
    public GameObject knight;
    public GameObject bishop;
    public GameObject rook;

    public int width = 1;
    public float height = 0.3f;

    private string[] rows = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
    private int[] cols = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

    private CellScript[,] boardCells = new CellScript[8, 8];
    private Piece[] boardPieces = new Piece[32];
    private CellScript selectedCell;
    private Piece selectedPiece;

    private GameObject lightPieces;
    private GameObject darkPieces;

    void Start()
    {
        Debug.Log("AWAKE");
        initBoard();
        Debug.Log("Init Board");
        initPieces();
        Debug.Log("Init Pieces");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initBoard()
    {
        GameObject boardObject = new GameObject("board");
        boardObject.transform.parent = gameObject.transform;
        bool black = true;
        for (int row = 0; row < 8; ++row)
        {
            for (int col = 0; col < 8; ++col)
            {
                string name = rows[row] + cols[col];
                var square = Instantiate(cell, new Vector3(row, 0, col), Quaternion.identity);
                square.transform.parent = boardObject.transform;
                square.name = name;
                bool isOffset = (row % 2 == 0 && col % 2 != 0) || (row % 2 != 0 && col % 2 == 0);
                square.Init(isOffset, this);
                boardCells[row,col] = square;
                //board[row, col] = square;
            }
            black = !black;
        }
    }

    void initPieces()
    {
        GameObject piecesObject = new GameObject("pieces");
        piecesObject.transform.parent = gameObject.transform;
        lightPieces = new GameObject("Light");
        darkPieces = new GameObject("Dark");
        lightPieces.transform.parent = piecesObject.transform;
        darkPieces.transform.parent = piecesObject.transform;

        for (int row = 0; row < 8; ++row)
        {
            initPawns(row);
        }
        initRooks();
        initKnights();
        initBishops();
        initQueens();
        initKings();
    }

    void initPawns(int row)
    {
        //initPiece(pawn, row, 1, lightPieces, "P", false);
        //initPiece(pawn, row, 6, darkPieces, "P", true);
        var wpawn= Instantiate(pawn, new Vector3(row, 0.2f, 1), Quaternion.identity);
        wpawn.transform.parent = lightPieces.transform;
        wpawn.name = "1P" + (row + 1);
        var bpawn = Instantiate(pawn, new Vector3(row, 0.2f, 6), Quaternion.identity);
        bpawn.transform.parent = darkPieces.transform;
        bpawn.name = "2P" + (row + 1);
        wpawn.Init(1, this);
        bpawn.Init(2, this);
    }

    void initRooks()
    {
        initPiece(rook, 0, 0, lightPieces, "R", false);
        initPiece(rook, 7, 0, lightPieces, "R", false);
        initPiece(rook, 0, 7, darkPieces, "R", true);
        initPiece(rook, 7, 7, darkPieces, "R", true);
    }

    void initKnights()
    {
        initPiece(knight, 1, 0, lightPieces, "N", false);
        initPiece(knight, 6, 0, lightPieces, "N", false);
        initPiece(knight, 1, 7, darkPieces, "N", true);
        initPiece(knight, 6, 7, darkPieces, "N", true);
    }

    void initBishops()
    {
        initPiece(bishop, 2, 0, lightPieces, "B", false);
        initPiece(bishop, 5, 0, lightPieces, "B", false);
        initPiece(bishop, 2, 7, darkPieces, "B", true);
        initPiece(bishop, 5, 7, darkPieces, "B", true);
    }
    void initQueens()
    {
        initPiece(queen, 3, 0, lightPieces, "Q", false);
        initPiece(queen, 3, 7, darkPieces, "Q", true);
    }
    void initKings()
    {
        initPiece(king, 4, 0, lightPieces, "K", false);
        initPiece(king, 4, 7, darkPieces, "K", true);
    }

    void initPiece(GameObject piceType, int row, int col, GameObject parent, String name, bool black)
    {
        GameObject pieceObject = Instantiate(piceType, new Vector3(row, 0.2f, col), Quaternion.identity);
        pieceObject.transform.parent = parent.transform;
        pieceObject.name = name + (row + 1);
        if (black)
        {
            pieceObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }

    public void setSelectedCell(CellScript selected)
    {
        Debug.Log("PREVIOUS SELCTION " + this.selectedCell);
        this.selectedCell = selected;
        Debug.Log("SET SELECTED " + selected.name);
    }
    public void setSelectedPiece(Piece selected)
    {
        Debug.Log("PREVIOUS SELCTION " + this.selectedPiece);
        this.selectedPiece = selected;
        Debug.Log("SET SELECTED " + selected.name);
    }

    public CellScript getSelectedCell()
    {
        return this.selectedCell;
    }
}
