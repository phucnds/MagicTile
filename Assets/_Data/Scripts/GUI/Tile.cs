using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField] private float fallSpeed = 5f;

    private Button button;
    private Transform endPoint;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public static Action<float> onTapCallBack;

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        if (transform.position.y <= endPoint.position.y)
        {
            CheckState();
        }

    }

    public void SetEndPoint(Transform ep)
    {
        endPoint = ep;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!button.interactable) return;
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, new Vector2(.9f, .9f), .15f).setEase(LeanTweenType.easeInOutCubic).setIgnoreTimeScale(true);

        OnTap();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!button.interactable) return;
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector2.one, .15f).setEase(LeanTweenType.easeOutElastic).setIgnoreTimeScale(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!button.interactable) return;
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector2.one, .15f).setEase(LeanTweenType.easeInOutCubic).setIgnoreTimeScale(true);
    }

    private void OnTap()
    {
        onTapCallBack?.Invoke(transform.position.y);
        button.interactable = false;
    }

    private void CheckState()
    {
        if (button.interactable)
        {
            GameManager.Instance.SetGameState(GameState.GAMEOVER);
        }

        Destroy(gameObject);
    }
}
