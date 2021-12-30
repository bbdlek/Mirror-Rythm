using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject Ball1;
    [SerializeField] private GameObject Ball2;
    [SerializeField] private GameObject Markball;

    public float ClickDuration = 2;

    private bool clicking = false;
    [SerializeField] private float totalDownTime = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            totalDownTime = 0;
            clicking = true;
        }

        if (clicking && Input.GetMouseButton(0))
        {
            totalDownTime += Time.deltaTime;

            if (totalDownTime >= ClickDuration)
            {
                Debug.Log("LongClick");
                Marking();
                clicking = false;
            }
        }
        
        if(clicking && Input.GetMouseButtonUp(0))
        {
            Debug.Log("ShortClick");
            Move();
            clicking = false;
        }
    }

    private void Move()
    {
        Ball1.GetComponent<TheBall>().isSelected = !Ball1.GetComponent<TheBall>().isSelected;
        Ball2.GetComponent<TheBall>().isSelected = !Ball2.GetComponent<TheBall>().isSelected;
    }

    private void Marking()
    {
        if (Ball1.GetComponent<TheBall>().isSelected)
            Instantiate(Markball, Ball2.transform.position, Quaternion.identity);
        else if(Ball2.GetComponent<TheBall>().isSelected)
        {
            Instantiate(Markball, Ball1.transform.position, Quaternion.identity);
        }
    }
}
