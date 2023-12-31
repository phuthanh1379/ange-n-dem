using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyProfile : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private EnemyData _enemyData;

    private AnimationEvent animationEvent;

    public event Action EnemyDead;
    public static event Action<EnemyData> BroadcastEnemyData;

    private void Awake()
    {
        //NewGame();
        Init();
    }

    private void Start()
    {
        BroadcastEnemyData?.Invoke(_enemyData);
    }

    private void Init()
    {
        healthBar.maxValue = _enemyData.HitPoint;
        healthBar.value = _enemyData.HitPoint;
    }

    private void NewGame()
    {
        _enemyData.ResetHitPoint();
    }

    public void AddEnemyHealth(int health)
    {
        _enemyData.AddHealth(health);
        healthBar.value = _enemyData.HitPoint;

        if (_enemyData.HitPoint <= 0)
        {
            EnemyDead?.Invoke();
        }
    }

    public void SetEnemyScore(int score)
    {
        _enemyData.SetScore(score);
    }

    public void AddEnemyScore(int score)
    {
        _enemyData.AddScore(score);
    }




}