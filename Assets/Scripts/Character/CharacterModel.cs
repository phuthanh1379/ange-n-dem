using UnityEngine;

public class CharacterModel : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public Animator Anim
    {
        get => animator;
    }
}
