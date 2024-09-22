using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    [SerializeField] private float scale = 1.5f;
    [SerializeField] private float duration = .2f;
    [SerializeField] private float lifeTime = -1;

    public void PlayAnim()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one * scale;
        LeanTween.scale(gameObject, Vector3.one, duration).setOnComplete(() =>
        {
            if (lifeTime > 0)
            {
                LeanTween.scale(gameObject, Vector3.one * 0.8f, lifeTime);
                StartCoroutine(DestroySelf());
            }

        });
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
