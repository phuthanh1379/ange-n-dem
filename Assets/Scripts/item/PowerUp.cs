using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpEnum powerUp;
    [SerializeField] private int point;

    public PowerUpEnum PickUpPowerUp()
    {
        return powerUp;
    }
    public int GetPrincessPoint()
    {
        return point;
    }
}