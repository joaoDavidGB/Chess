using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    [SerializeField] private Color _color1, _color2, _highlightColor;
    [SerializeField] private MeshRenderer _renderer;
    private Color _originalColor;
    private bool isSelected;
    private GenerateBoard _board;
    // Start is called before the first frame update
    public void Init(bool isOffset, GenerateBoard board)
    {
        Debug.Log("Init");
        _originalColor = isOffset ? _color1 : _color2;
        setColor(_originalColor);
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
        if (!isSelected)
        {
            setColor(_highlightColor);
        }
    }
    private void OnMouseExit()
    {
        if (!isSelected)
        {
            setColor(_originalColor);
        }
    }
}
