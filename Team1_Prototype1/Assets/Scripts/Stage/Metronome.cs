using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Metronome : MonoBehaviour
{

    private float musicBPM = 83f;
    private float stdBPM = 60f;

    private float tikTime = 0;
    private float nextTime = 0;

    private float offsetForSample;
    private float nextSample;

    //public Text _AccuracyTxt;

    //public float ClickDuration = 1f;
    //private bool clicking = false;
    //private float totalDownTime = 0;

    [SerializeField] private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }

    private void Update()
    {
        //CheckClick();

        tikTime = stdBPM / musicBPM;

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
        yield return new WaitForSeconds(tikTime);
    }

    /*private void CheckAccuracy()
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
    }*/
}
