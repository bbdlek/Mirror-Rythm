using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBall : MonoBehaviour
{
    [SerializeField] private GameObject targetBall;
    [SerializeField] private float speed;

    public bool isSelected;

    private void Update()
    {
        if(isSelected)
            transform.RotateAround(targetBall.transform.position, Vector3.down, speed);
    }
}
