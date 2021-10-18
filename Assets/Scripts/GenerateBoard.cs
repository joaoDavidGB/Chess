using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CellScript cell;
    [SerializeField] private Piece pawn;
    [SerializeField] private Piece king;
    [SerializeField] private Piece queen;
    [SerializeField] private Piece knight;
    [SerializeField] private Piece bishop;
    [SerializeField] private Piece rook;

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
                square.Init(row, col, this);
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
        initPiece(pawn, row, 1, lightPieces, "1P", 1);
        initPiece(pawn, row, 6, darkPieces, "2P", 2);
    }

    void initRooks()
    {
        initPiece(rook, 0, 0, lightPieces, "1R", 1);
        initPiece(rook, 7, 0, lightPieces, "1R", 1);
        initPiece(rook, 0, 7, darkPieces, "2R", 2);
        initPiece(rook, 7, 7, darkPieces, "2R", 2);
    }

    void initKnights()
    {
        initPiece(knight, 1, 0, lightPieces, "1N", 1);
        initPiece(knight, 6, 0, lightPieces, "1N", 1);
        initPiece(knight, 1, 7, darkPieces, "2N", 2);
        initPiece(knight, 6, 7, darkPieces, "2N", 2);
    }

    void initBishops()
    {
        initPiece(bishop, 2, 0, lightPieces, "1B", 1);
        initPiece(bishop, 5, 0, lightPieces, "1B", 1);
        initPiece(bishop, 2, 7, darkPieces, "2B", 2);
        initPiece(bishop, 5, 7, darkPieces, "2B", 2);
    }
    void initQueens()
    {
        initPiece(queen, 3, 0, lightPieces, "1Q", 1);
        initPiece(queen, 3, 7, darkPieces, "2Q", 2);
    }
    void initKings()
    {
        initPiece(king, 4, 0, lightPieces, "1K", 1);
        initPiece(king, 4, 7, darkPieces, "2K", 2);
    }

    void initPiece(Piece pieceType, int row, int col, GameObject parent, String name, int playerNum)
    {
        var pieceObject = Instantiate(pieceType, new Vector3(row, 0.2f, col), Quaternion.identity);
        pieceObject.transform.parent = parent.transform;
        pieceObject.name = name + (row + 1);
        pieceObject.Init(playerNum, this);
        boardCells[row, col].setCurrentPiece(pieceObject);
        pieceObject.setCurrenCell(boardCells[row, col]);
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

    public Piece getSelectedPiece()
    {
        return this.selectedPiece;
    }

    public void removePieceSelection()
    {
        this.selectedPiece = null;
        this.removeMoves();
    }

    public void highlightMoves(bool[,] possibleMoves)
    {
        removeMoves();
        Debug.Log("Highligh Moves " + possibleMoves);
        for (int row = 0; row < 8; ++row)
        {
            for (int col = 0; col < 8; ++col)
            {
                if (possibleMoves[row, col])
                {
                    Debug.Log("Possible to move to " + row + "-" + col);
                    boardCells[row, col].highlightMove();
                }
            }
        }
    }

    public void removeMoves()
    {
        for (int row = 0; row < 8; ++row)
        {
            for (int col = 0; col < 8; ++col)
            {
                boardCells[row, col].removeMove();
            }
        }
    }
}
