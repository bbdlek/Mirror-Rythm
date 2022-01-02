using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Metronome : MonoBehaviour
{
    private PlayerController _playerController;
    
    private float musicBPM = 60f;
    private float stdBPM = 60f;
    private float musicTempo = 4f;
    private float stdTempo = 4f;
    
    private float tikTime = 0;
    private float nextTime = 0;

    public Text _AccuracyTxt;

    public float ClickDuration = 1f;
    private bool clicking = false;
    private float totalDownTime = 0;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        CheckClick();
        
        tikTime = (stdBPM / musicBPM) * (musicTempo / stdTempo);

        nextTime += Time.deltaTime;

        if (nextTime > tikTime)
        {
            StartCoroutine(Playtik(tikTime));
            nextTime = 0;
        }
    }

    IEnumerator Playtik(float tikTime)
    {
        Debug.Log(nextTime);
        _playerController.FlashTile();
        yield return new WaitForSeconds(tikTime);
    }

    private void CheckAccuracy()
    {
        float accuracy = 0;
            if (nextTime > 0.5f)
                accuracy = nextTime * 100;
            else accuracy = (1f - nextTime) * 100;

            if (accuracy > 95f)
            {
                _AccuracyTxt.text = "Perfect!";
                _playerController.NextTile();
            }
            else if (accuracy > 80f)
            {
                _AccuracyTxt.text = "Great!";
                _playerController.NextTile();
            }
            else if (accuracy > 70f)
            {
                _AccuracyTxt.text = "Good!";
                _playerController.NextTile();
            }
            else
                _AccuracyTxt.text = "Bad!";
            //Debug.LogWarning(accuracy);
    }

    private void CheckClick()
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
                Debug.Log("Long click");
                _playerController.FillTile();
                clicking = false;
            }
        }
        if (clicking && Input.GetMouseButtonUp(0))
        {
            CheckAccuracy();
            clicking = false;
        }
    }
}
