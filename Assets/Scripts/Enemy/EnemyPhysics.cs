using UnityEngine;

public class EnemyPhysics : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private EnemyProfile profile;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"collision.name={collision.collider.gameObject.name}");

        if (!collision.collider.CompareTag("Obstacle"))
        {
            return;
        }

        var obstacle = collision.collider.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            var obstaclePoint = obstacle.GetObstaclePoint();
            profile.AddEnemyHealth(obstaclePoint);
        }
    }



}