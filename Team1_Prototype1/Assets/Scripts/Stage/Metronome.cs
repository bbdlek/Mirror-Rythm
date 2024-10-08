using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Metronome : MonoBehaviour
{

    private float musicBPM = 83f;
    private float stdBPM = 60f;

    public float tikTime = 0;
    private float nextTime = 0;
    public float sync = 0;

    private float offsetForSample;
    private float nextSample;

    //public Text _AccuracyTxt;

    public float ClickDuration = 1f;
    private bool clicking = false;
    private float totalDownTime = 0;

    [SerializeField] private AudioSource _audio;

    private MoveManager _moveManager;

    [SerializeField] private bool isSuccess = false;

    //private bool isMusic = false;

    private void Start()
    {
        _moveManager = GetComponent<MoveManager>();
        _audio = GetComponent<AudioSource>();
        _audio.Play();

        tikTime = stdBPM / musicBPM;
        GameManager.instance.bpmTime = tikTime;
        ClickDuration = tikTime;

        nextTime += sync;
    }

    private void Update()
    {

        CheckClick();


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

    public void CheckAccuracy()
    {
        if (nextTime < tikTime * 0.3f || nextTime > tikTime * 0.7f)
        {
            Debug.Log("Success");
            isSuccess = true;
        }
        else
        {
            Debug.Log("Failed");
            Camera.main.GetComponent<CameraController>().ShakeCam();
            GetComponent<MoveManager>()._selectedTile.GetComponent<TileController>().ShakeTile();
            GetComponent<MoveManager>()._selectedTile_up.GetComponent<TileController>().ShakeTile();
            isSuccess = false;
        }
    }

    private void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckAccuracy();
            totalDownTime = 0;
            clicking = true;
        }
        if (clicking && Input.GetMouseButton(0) && isSuccess)
        {
            totalDownTime += Time.deltaTime;

            if (totalDownTime >= ClickDuration)
            {
                _moveManager.CheckTile();
                clicking = false;
            }
        }
        if (clicking && Input.GetMouseButtonUp(0) && isSuccess)
        {
            _moveManager.MoveTile();
            clicking = false;
        }
    }
}
