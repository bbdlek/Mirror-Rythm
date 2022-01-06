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

    public float bpmTime;

    private void Awake()
    {
        instance = this;
    }
}
