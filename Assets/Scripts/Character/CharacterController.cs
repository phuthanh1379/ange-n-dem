using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private ProfileController profileController;
    [SerializeField] private PhysicsController physicsController;
    [SerializeField] private AttackController attackController;
    [SerializeField] private MoveController moveController;
    [SerializeField] private AnimationController animationController;

    //[SerializeField] private List<SpriteRenderer> spriteRenderers = new();
    [SerializeField] private float deadDuration;

    private CharacterState _characterState;

    private void Awake()
    {
        Init();

        physicsController.CollideObstacle += OnCollideObstacle;
        profileController.PlayerDead += OnPlayerDead;
    }

    private void Update()
    {
        if (attackController.CheckEnemy())
        {
            Debug.Log($"{name} attacking");
            OnChangeState(CharacterState.Attack);
        } 
        else
        {
            Debug.Log($"{name} moving");
            OnChangeState(CharacterState.Move);
        }
    }

    private void OnDestroy()
    {
        physicsController.CollideObstacle -= OnCollideObstacle;
        profileController.PlayerDead -= OnPlayerDead;
    }

    private void OnChangeState(CharacterState characterState)
    {
        _characterState = characterState;
        switch (characterState)
        {
            case CharacterState.Move:
                OnMove();
                break;

            case CharacterState.Attack:
                OnAttack();
                break;

            case CharacterState.Die:
                OnDie();
                break;
        }
    }

    private void OnMove()
    {
        moveController.Move();
        animationController.Walk();
    }

    private void OnAttack()
    {
        attackController.Attack();
        animationController.Attack();
    }

    private void OnDie()
    {
        animationController.Dead();
        Invoke(nameof(SelfDestroy), deadDuration);

        //var sequence = DOTween.Sequence();
        //foreach (var spriteRenderer in spriteRenderers)
        //{

        //    var tween = spriteRenderer
        //    .DOFade(0f, deadDuration)
        //    ;

        //    sequence.Join(tween);

        //}

        //sequence
        //    .OnComplete(() =>
        //    {
        //        Destroy(this.gameObject);
        //    })
        //    .Play();

    }

    private void OnPlayerDead()
    {
        OnChangeState(CharacterState.Die);
    }

    private void OnCollideObstacle(int obstaclePoint)
    {
        profileController.AddPlayerHealth(obstaclePoint);

        if (obstaclePoint < 0)
        {
            //animationController.Hurt();
        }
    }

    private void Init()
    {
        OnChangeState(CharacterState.Move);
    }

    public void SetDirection(Direction direction)
    {
        moveController.SetDirection(direction);
    }

    public void Hurt(int damage)
    {
        if (_characterState == CharacterState.Die)
        {
            return;
        }

        profileController.AddPlayerHealth(-damage);
    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }

    public void LoadData(CharacterData characterData)
    {
        profileController.LoadData(characterData);
        profileController.ResetHP();
        // var model = Instantiate(characterData.Model, transform.position, Quaternion.identity);
        // model.transform.SetParent(this.transform);
        // animationController.SetAnimator(model.Anim);
        attackController.SetEnemyCheckRadius(characterData.EnemyCheckRadius);
    }

    public void SetEnemyLayer(LayerMask layer)
    {
        attackController.SetEnemyLayer(layer);
    }
}
