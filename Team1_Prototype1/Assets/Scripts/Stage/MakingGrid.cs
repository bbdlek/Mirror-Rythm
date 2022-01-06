using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MakingGrid : MonoBehaviour
{
    [SerializeField] private GameObject _up_no;
    [SerializeField] private GameObject _up_yes;

    [SerializeField] private GameObject upside;

    [SerializeField] private List<GameObject> Up_List;
    
    [SerializeField] private GameObject _down_tile;
    [SerializeField] private GameObject downside;
    [SerializeField] private List<GameObject> Down_List;

    private void Start()
    {
        NbyNGridUp(10, 10);
        NbyNGridDown(10, 10);
    }

    public void NbyNGridUp(int width, int height)
    {
        for (int i = 0; i < width; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < height; j++)
                {
                    GameObject tile;
                    tile = Instantiate(SelectedTile(), upside.transform);
                    tile.transform.position = tile.transform.position + new Vector3(0, j) + new Vector3(i, 0);
                    Up_List.Add(tile);
                }                
            }
            else if (i % 2 == 1)
            {
                for (int j = height; j > 0; j--)
                {
                    GameObject tile;
                    tile = Instantiate(SelectedTile(), upside.transform);
                    tile.transform.position = tile.transform.position + new Vector3(0, j - 1) + new Vector3(i, 0);
                    Up_List.Add(tile);
                }  
            }
            
        }

        float scale = 3 / (float) width;
        upside.transform.localScale = new Vector3(scale, scale, scale);
        //Debug.Log(scale);
        upside.transform.position = new Vector3(scale * (width / 2 - 0.5f) * -1, 0, 0);
    }
    
    private GameObject SelectedTile()
    {
        int i = Random.Range(0, 3);
        if (i == 0)
        {
            return _up_yes;
        }
        else
        {
            return _up_no;
        }
    }
    
    public void NbyNGridDown(int width, int height)
    {
        for (int i = 0; i < width; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < height; j++)
                {
                    GameObject tile;
                    tile = Instantiate(_down_tile, downside.transform);
                    tile.transform.position = tile.transform.position - new Vector3(0, j) + new Vector3(i, 0);
                    Down_List.Add(tile);
                }                
            }
            else if (i % 2 == 1)
            {
                for (int j = height; j > 0; j--)
                {
                    GameObject tile;
                    tile = Instantiate(_down_tile, downside.transform);
                    tile.transform.position = tile.transform.position - new Vector3(0, j - 1) + new Vector3(i, 0);
                    Down_List.Add(tile);
                }  
            }
            
        }

        float scale = 3 / (float) width;
        downside.transform.localScale = new Vector3(scale, scale, scale);
        //Debug.Log(scale);
        downside.transform.position = new Vector3(scale * (width / 2 - 0.5f) * -1, -1, 0);
    }

    
}
