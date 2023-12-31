using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MOVEMENT : MonoBehaviour
{
    [SerializeField] private Transform obstacle;
    [SerializeField] private float y;
    private void Start()
    {
        var moveY = obstacle.DOMoveY(y, 2f);
        var sequence = DOTween.Sequence(obstacle);
        sequence
            .Append(moveY)
            //.SetEase(Ease.InBounce) cainayaLongchibay
            .SetLoops(-1, LoopType.Yoyo)
            .Play()
            ;
            
    }
}
