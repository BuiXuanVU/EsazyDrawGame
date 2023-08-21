using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class UIEffect : ComponentBehaviuor
{
    private Vector3 originalScale;
    protected void ScaleImage(Transform image,float scaleSize)
    {
        originalScale = image.transform.localScale;
        image.DOScale(new Vector3(originalScale.x + scaleSize, originalScale.y + scaleSize, originalScale.z + scaleSize), 0.75f).OnComplete(() =>
        {
            image.transform.DOScale(originalScale, 0.75f).SetLoops(-1, LoopType.Yoyo);
        });
    }
    protected void SkadeImage(Transform image)
    {
        image.DOShakeRotation(0.5f, new Vector3(0, 0, 55));
    }
    protected void MoveToOriginalLocation(Transform originalLocation, float xPos,float yPos)
    {
        Vector2 saveLocation = originalLocation.position;
        Debug.Log(saveLocation);
        originalLocation.position = new Vector2(saveLocation.x + xPos, saveLocation.y + yPos);
        Debug.Log(originalLocation.position);
        originalLocation.DOMove(saveLocation, 0.5f);
    }
}
