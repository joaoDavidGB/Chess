using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    [SerializeField] private Color _color1, _color2, _highlightColor;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private GameObject highlighObject;
    private Color _originalColor;
    private bool isSelected;
    private GenerateBoard _board;
    private Piece currentPiece;
    private int row, col;
    private bool isHighlighted;
    // Start is called before the first frame update
    public void Init(int row, int col, GenerateBoard board)
    {
        bool isOffset = (row % 2 == 0 && col % 2 != 0) || (row % 2 != 0 && col % 2 == 0);
        this.row = row;
        this.col = col;
        _originalColor = isOffset ? _color1 : _color2;
        setColor(_originalColor);
        this._board = board;
    }

    void setColor(Color color)
    {
        Debug.Log("SET COLOR OF " + row + "-" + col + " to " + color.ToString());
        _renderer.material.color = color;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            var renderer = gameObject.GetComponent<Renderer>();
            // Casts the ray and get the first game object hit
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == gameObject.name)
                {
                    Debug.Log(gameObject.name + " hit at " + hit.point);
                    _renderer.material.color = Color.red;
                    isSelected = true;
                    _board.setSelectedCell(this);
                } else if (isSelected == true)
                {
                    isSelected = false;
                    setColor(_originalColor);
                }
            }
        }
    }

    private void OnMouseEnter()
    {
        if (!isSelected && !isHighlighted)
        {
            setColor(_highlightColor);
        }
    }
    private void OnMouseExit()
    {
        if (!isSelected && !isHighlighted)
        {
            setColor(_originalColor);
        }
    }

    public Piece getCurrentPiece()
    {
        return this.currentPiece;
    }

    public int getRow()
    {
        return this.row;
    }

    public int getCol()
    {
        return this.col;
    }

    public void setCurrentPiece(Piece piece)
    {
        this.currentPiece = piece;
    }

    public void highlightMove()
    {
        Debug.Log("Highlight Cell " + row + "-" + col);
        isHighlighted = true;
        highlighObject.SetActive(true);
    }

    public void removeMove()
    {
        isHighlighted = false;
        highlighObject.SetActive(false);
    }
}
