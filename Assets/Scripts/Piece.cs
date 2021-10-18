using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    private Color _color;
    private bool isSelected;
    private GenerateBoard _board;

    public void Init(int payerNum, GenerateBoard board)
    {
        Debug.Log("Init Piece");
        _color = payerNum == 1 ? Color.white : Color.black;
        setColor(_color);
        this._board = board;
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
                    _board.setSelectedPiece(this);
                }
                else if (isSelected == true)
                {
                    this.transform.position = this._board.getSelectedCell().transform.position;
                    isSelected = false;
                    setColor(_color);
                }
            }
        }
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
}
