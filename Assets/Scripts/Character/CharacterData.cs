using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character", fileName = "CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private int hitPoint;
    public int HitPoint
    {
        get => hitPoint;
        private set => hitPoint = value;
    }

    [SerializeField] private int maxHitPoint;
    public int MaxHitPoint
    {
        get => maxHitPoint;
        private set => maxHitPoint = value;
    }

    [SerializeField] private int damage;
    public int Damage
    {
        get => damage;
        private set => damage = value;
    }

    [SerializeField] private AttackType attackType;
    public AttackType Type
    {
        get => attackType;
        private set => attackType = value;
    }

    // [SerializeField] private CharacterModel characterModel;
    // public CharacterModel Model
    // {
    //     get => characterModel;
    //     private set => characterModel = value;
    // }

    [SerializeField] private float enemyCheckRadius;
    public float EnemyCheckRadius
    {
        get => enemyCheckRadius;
        private set => enemyCheckRadius = value;
    }

    public void AddHealth(int health)
    {
        if (health < 0)
        {
            var dmg = health;
            this.HitPoint += dmg;
        }
        else
        {
            this.HitPoint += health;
        }
    }

    public void ResetHitPoint()
    {
        this.HitPoint = this.MaxHitPoint;
    }

}

public enum AttackType
{
    Melee = 0,
    Range = 1
}


