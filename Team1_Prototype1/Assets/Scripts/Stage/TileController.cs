using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private Sequence _shakeSequence;
    private Sequence _selectSequence;
    [SerializeField] private bool isShaking = false;

    public void ShakeTile()
    {
        if (!isShaking)
        {
            isShaking = true;
            _shakeSequence = DOTween.Sequence();
            this.transform.DOShakePosition(0.5f, 0.2f, 10, 30f, false, true)
                .OnComplete(() =>
                {
                    isShaking = false;
                    this.transform.DOKill();
                });
        }
    }

    public void SelectedEffect()
    {
        float duration = GameManager.instance.bpmTime/4f;
        _selectSequence = DOTween.Sequence();
        _selectSequence.Append(this.transform.DOScale(1, duration).SetEase(Ease.OutBounce))
            .Insert(duration, this.transform.DOScale(0.9f, duration).SetEase(Ease.OutBounce))
            .SetLoops(-1, LoopType.Restart);
    }

    public void EndSelect()
    {
        _selectSequence.Kill();
        transform.localScale = new Vector3(0.9f, 0.9f, 1f);
    }
}
