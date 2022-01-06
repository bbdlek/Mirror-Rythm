using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private Sequence _sequence;
    [SerializeField] private bool isShaking = false;

    public void ShakeTile()
    {
        if (!isShaking)
        {
            isShaking = true;
            _sequence = DOTween.Sequence();
            this.transform.DOShakePosition(0.5f, 0.2f, 10, 30f, false, true)
                .OnComplete(() =>
                {
                    isShaking = false;
                    this.transform.DOKill();
                });
        }
    }
}
