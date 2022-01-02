using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private Sequence _flashSq;

    public bool isSelected = false;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _flashSq = DOTween.Sequence();
        
        _flashSq.Append(_spriteRenderer.DOColor(Color.blue, 0.5f))
            .Insert(0.5f, _spriteRenderer.DOColor(Color.white, 0.5f));
    }

    public void Flash()
    {
        StartCoroutine(FlashCo());
    } 
    
    IEnumerator FlashCo()
    {
        _spriteRenderer.DOColor(Color.blue, 0.5f);
        yield return new WaitForSeconds(0.5f);
        _spriteRenderer.DOColor(Color.white, 0.5f);
    }

    public void Filled()
    {
        StopAllCoroutines();
        _spriteRenderer.DOColor(Color.red, 0.5f);
    }
}
