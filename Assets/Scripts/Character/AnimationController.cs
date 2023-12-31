using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    private static readonly int State = Animator.StringToHash("state");

    public void Attack()
    {
        animator.SetInteger(State, (int) CharacterState.Attack);
    }

    public void Dead()
    {
        // animator.SetTrigger("die");
        animator.SetInteger(State, (int) CharacterState.Die);
    }

    public void Walk()
    {
        // animator.SetBool("isAttacking", true);
        animator.SetInteger(State, (int) CharacterState.Move);
    }

    public void SetAnimator(Animator animator)
    {
        this.animator = animator;
    }
}