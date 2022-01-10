using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public GameObject _selectedTile;
    public GameObject _selectedTile_up;

    /*public float ClickDuration = 1f;
    private bool clicking = false;
    private float totalDownTime = 0;*/

    private int num_selected;

    private Metronome _metronome;

    private void Start()
    {
        num_selected = 0;
        _metronome = GetComponent<Metronome>();
    }

    private void Update()
    {
        //CheckClick();
    }

    public void InitiateList()
    {
        _selectedTile = GameManager.instance.Down_List[num_selected];
        _selectedTile_up = GameManager.instance.Up_List[num_selected];
        _selectedTile.GetComponent<TileController>().SelectedEffect();
    }

    public void MoveTile()
    {
        if (GameManager.instance.Up_List[num_selected].CompareTag("YesTile"))
        {
            Camera.main.GetComponent<CameraController>().ShakeCam();
            GetComponent<MoveManager>()._selectedTile.GetComponent<TileController>().ShakeTile();
            GetComponent<MoveManager>()._selectedTile_up.GetComponent<TileController>().ShakeTile();
        }
        else if(GameManager.instance.Up_List[num_selected].CompareTag("NoTile"))
        {
            _selectedTile.GetComponent<TileController>().EndSelect();
            num_selected++;
            _selectedTile = GameManager.instance.Down_List[num_selected];
            _selectedTile_up = GameManager.instance.Up_List[num_selected];
            _selectedTile.GetComponent<TileController>().SelectedEffect();
        }
    }

    public void CheckTile()
    {
        if (GameManager.instance.Up_List[num_selected].CompareTag("YesTile"))
        {
            _selectedTile.GetComponent<SpriteRenderer>().color = Color.cyan;
            _selectedTile.GetComponent<TileController>().EndSelect();
            num_selected++;
            _selectedTile = GameManager.instance.Down_List[num_selected];
            _selectedTile_up = GameManager.instance.Up_List[num_selected];
            _selectedTile.GetComponent<TileController>().SelectedEffect();
        }
        else if(GameManager.instance.Up_List[num_selected].CompareTag("NoTile"))
        {
            Camera.main.GetComponent<CameraController>().ShakeCam();
            GetComponent<MoveManager>()._selectedTile.GetComponent<TileController>().ShakeTile();
            GetComponent<MoveManager>()._selectedTile_up.GetComponent<TileController>().ShakeTile();
        }
    }
}
