using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Sequence _sequence;
    [SerializeField] private bool isShaking = false;

    public void ShakeCam()
    {
        if (!isShaking)
        {
            isShaking = true;
            _sequence = DOTween.Sequence();
            GetComponent<Camera>().DOShakePosition(0.5f, 0.01f, 10, 15f, true)
                .OnComplete(() =>
                {
                    isShaking = false;
                    GetComponent<Camera>().DOKill();
                });
        }
    }
}
