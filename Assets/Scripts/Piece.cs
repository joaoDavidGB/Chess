using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    private Color _color;
    private bool isSelected;
    private GenerateBoard _board;
    private CellScript currentCell;
    public int playerNum;

    public virtual void Init(int playerNum, GenerateBoard board)
    {
        Debug.Log("Init Piece");
        _color = playerNum == 1 ? Color.white : Color.black;
        setColor(_color);
        this.playerNum = playerNum;
        _board = board;
    }

    void setColor(Color color)
    {
        _renderer.material.color = color;
    }

    void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == gameObject.name)
                {
                    Debug.Log("PIECE HIT");
                    Debug.Log(gameObject.name + " hit at " + hit.point);
                    _renderer.material.color = Color.red;
                    isSelected = true;
                    _board.removePieceSelection();
                    _board.highlightMoves(this.getPossibleMoves());
                    _board.setSelectedPiece(this);
                }
                else if (isSelected == true)
                {
                    this.movePiece();
                    isSelected = false;
                    setColor(_color);
                } else
                {
                    //_board.removeMoves();
                }
            }
        }
    }

    public void setSelected(bool selected)
    {
        this.isSelected = selected;
    }

    private void movePiece()
    {
        Debug.Log("MOVE PIECE TO " + _board.getSelectedCell().getRow() + "-" + _board.getSelectedCell().getCol());
        if (this._board.getSelectedCell().getCurrentPiece() == null) {
            this.transform.position = _board.getSelectedCell().transform.position;
            _board.getSelectedCell().setCurrentPiece(this);
            this.currentCell.setCurrentPiece(null);
            _board.removeMoves();
        }
    }

    public virtual bool[,] getPossibleMoves()
    {
        Debug.Log("BASE POSSIBLE");
        return new bool[8, 8];
    }

    private void OnMouseEnter()
    {
        if (!isSelected)
        {
            setColor(Color.yellow);
        }
    }
    private void OnMouseExit()
    {
        if (!isSelected)
        {
            setColor(_color);
        }
    }
    public CellScript getCurrentCell()
    {
        return this.currentCell;
    }

    public void setCurrenCell(CellScript cell)
    {
        this.currentCell = cell;
    }

    public void rotate180()
    {
        this._renderer.transform.Rotate(new Vector3(0, 180, 0));
    }
}
