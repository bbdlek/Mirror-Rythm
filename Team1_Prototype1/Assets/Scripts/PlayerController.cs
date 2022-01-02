using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private List<GameObject> Tiles;
    [SerializeField] private GameObject _selectedTile;

    public int idx_Tile = 0;

    private void FindTiles()
    {
        Transform _downSide = GameObject.Find("DownSide").transform;
        foreach (Transform child in _downSide)
        {
            child.GetComponent<TileController>().isSelected = false;
            Tiles.Add(child.gameObject);
        }
    }

    private void Start()
    {
        FindTiles();
        idx_Tile = 0;
        _selectedTile = Tiles[idx_Tile];
    }

    public void NextTile()
    {
        if (idx_Tile == (Tiles.Count - 1))
            return;
        
        idx_Tile++;
        _selectedTile = Tiles[idx_Tile];
    }

    public void FlashTile()
    {
        _selectedTile.GetComponent<TileController>().Flash();
    }

    public void FillTile()
    {
        _selectedTile.GetComponent<TileController>().Filled();
        NextTile();
    }
}
