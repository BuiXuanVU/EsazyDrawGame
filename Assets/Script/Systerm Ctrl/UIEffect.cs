using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class UIEffect : ComponentBehaviuor
{
    private Vector3 originalScale;
    protected void ScaleImage(Transform image)
    {
        originalScale = image.transform.localScale;
        image.DOScale(new Vector3(originalScale.x + 0.2f, originalScale.y + 0.2f, originalScale.z + 0.2f), 0.75f).OnComplete(() =>
        {
            image.transform.DOScale(originalScale, 0.75f).SetLoops(-1, LoopType.Yoyo);
        });
    }
}
