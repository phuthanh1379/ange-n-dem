using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMove : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb2d;
    //[SerializeField] private IsometricDirection direction;

    private float _horizontal;
    private float _vertical;

    private bool _isRun => (_horizontal != 0 || _vertical != 0);
    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("x", _horizontal);
        animator.SetFloat("y", _vertical);
        animator.SetBool("IsRun", _isRun);
       /* if (_horizontal > 0)
        {
            if (_vertical > 0)
            {
                direction = IsometricDirection.NorthEast;
            }
            else if (_vertical < 0)
            {
                direction = IsometricDirection.SouthEast;
            }
        }
        else if (_horizontal < 0)
        {
            if (_vertical > 0)
            {
                direction = IsometricDirection.NorthWest;
            }
            else if (_vertical < 0)
            {
                direction = IsometricDirection.SouthWest;
            }
        }
       
        PlayAnimation(direction, (_horizontal != 0 && _vertical != 0));
       */
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(_horizontal, _vertical);
    }

    private void PlayAnimation(IsometricDirection isometricDirection, bool isMoving)
    {
        switch (isometricDirection)
        {
            case IsometricDirection.NorthEast:
                animator.Play(isMoving ? "Run-NE" : "Idle-NE");
                break;

            case IsometricDirection.NorthWest:
                animator.Play(isMoving ? "Run-NW" : "Idle-NW");
                break;

            case IsometricDirection.SouthEast:
                animator.Play(isMoving ? "Run-SE" : "Idle-SE");
                break;

            case IsometricDirection.SouthWest:
                animator.Play(isMoving ? "Run-SW" : "Idle-SW");
                break;
        }
    }
}

public enum IsometricDirection
{
    NorthEast = 0,
    NorthWest = 1,
    SouthEast = 2,
    SouthWest = 3,
}