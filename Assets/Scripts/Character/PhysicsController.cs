using System;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    [SerializeField] private Collider2D playerCollider;
    public event Action<int> CollideObstacle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Obstacle"))
        {
            return;
        }

        var obstacle = collision.collider.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            var obstaclePoint = obstacle.GetObstaclePoint();
            CollideObstacle?.Invoke(obstaclePoint);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("PowerUp"))
        {
            return;
        }

        var obstacle = collision.GetComponent<PowerUp>();
        if (obstacle != null)
        {
            var powerUp = obstacle.PickUpPowerUp();
            switch (powerUp)
            {
                case PowerUpEnum.Armor:

                    break;

                case PowerUpEnum.HitPoint:
                    break;

                case PowerUpEnum.Damage:
                    break;

                case PowerUpEnum.Immortal:

                    break;
            }
        }
    }

}