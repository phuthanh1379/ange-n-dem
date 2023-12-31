using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_Jumping : MonoBehaviour
{
    [SerializeField] private Vector3 basePosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float jumpPower;
    [SerializeField] private int numJumps;
    [SerializeField] private float duration;
    [SerializeField] private int loops;

    private Sequence _sequence;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            _sequence = DOTween.Sequence();
            var jumpTween = transform.DOLocalJump(endPosition, jumpPower, numJumps, duration);
            var backTween = transform.DOMove(basePosition, duration);

            _sequence
                .Append(jumpTween)
                .Append(backTween)
                .SetLoops(loops);
            _sequence.Play();
          

        }
      
    }
    
}
