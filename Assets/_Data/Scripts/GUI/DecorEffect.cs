using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float startAlpha = .5f;
    [SerializeField] private float endAlpha = 1f;
    [SerializeField] private float startDuration = .2f;
    [SerializeField] private float endDuration = .5f;

    public void PlayAnim()
    {
        LeanTween.cancel(gameObject);
        LeanTween.alphaCanvas(canvasGroup, endAlpha, startDuration).setOnComplete(() => {
            LeanTween.alphaCanvas(canvasGroup, startAlpha, endDuration);
        });
    }
}

