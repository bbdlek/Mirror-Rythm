using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    
    public List<GameObject> Up_List;
    public List<GameObject> Down_List;
    
    public GameObject _effect;
    private Vector2 mousePos;

    public float bpmTime;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _effect.SetActive(true);
            _effect.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
            _effect.GetComponent<ParticleSystem>().Play();
        }
    }
}
