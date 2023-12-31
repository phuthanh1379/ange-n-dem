using System;
using UnityEngine;
using UnityEngine.UI;

public class ProfileController : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    private CharacterData data;
    public event Action PlayerDead;

    public void LoadData(CharacterData characterData)
    {
        data = characterData;
        Init();
    }

    private void Init()
    {
        healthBar.maxValue = data.HitPoint;
        healthBar.value = data.HitPoint;
    }

    public void ResetHP()
    {
        data.ResetHitPoint();
    }

    public void AddPlayerHealth(int health)
    {
        data.AddHealth(health);
        healthBar.value = data.HitPoint;

        if (data.HitPoint <= 0)
        {
            PlayerDead?.Invoke();
        }
    }

}