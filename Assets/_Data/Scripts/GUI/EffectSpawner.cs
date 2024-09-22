using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : SingleReference<EffectSpawner>
{
    [SerializeField] TextEffect textEffectPerfect;
    [SerializeField] TextEffect textEffectGreat;
    [SerializeField] TextEffect textEffectGood;
    [SerializeField] TextEffect textEffectCool;
    [SerializeField] private GameObject start;

    public void ShowTextEffectPerfect()
    {
        ClearChild();
        TextEffect text = Instantiate(textEffectPerfect, transform);
        text.PlayAnim();
        GameObject startParticle = Instantiate(start, transform);
    }

    public void ShowTextEffectGreat()
    {
        ClearChild();
        TextEffect text = Instantiate(textEffectGreat, transform);
        text.PlayAnim();
        GameObject startParticle = Instantiate(start, transform);
    }

    public void ShowTextEffectGood()
    {
        ClearChild();
        TextEffect text = Instantiate(textEffectGood, transform);
        text.PlayAnim();
        GameObject startParticle = Instantiate(start, transform);
    }

    public void ShowTextEffectCool()
    {
        ClearChild();
        TextEffect text = Instantiate(textEffectCool, transform);
        text.PlayAnim();
        GameObject startParticle = Instantiate(start, transform);
    }

    private void ClearChild()
    {
        foreach (Transform trans in transform)
        {
            Destroy(trans.gameObject);
        }
    }

}
