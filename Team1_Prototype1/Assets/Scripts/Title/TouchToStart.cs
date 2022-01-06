using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchToStart : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("MainMenu");
    }
}
