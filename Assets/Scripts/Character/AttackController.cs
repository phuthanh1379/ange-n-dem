using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Transform enemyCheck;
    [SerializeField] private LayerMask enemyLayer;
    
    private float _enemyCheckRadius;
    private bool _isDead;
    private int _damage;

    public void Attack()
    {
        // if (_isDead)
        // {
        //     return;
        // }
    }

    public void SetEnemyLayer(LayerMask layer)
    {
        enemyLayer = layer;
    }

    public void SetEnemyCheckRadius(float radius)
    {
        _enemyCheckRadius = radius;
    }

    private void DoAttack()
    {

        var enemy = CheckEnemy();
        if ((bool)enemy)
        {
            enemy.GetComponent<CharacterController>().Hurt(_damage);
        }

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(enemyCheck.position, enemyCheckRadius);
    //}

    public Collider2D CheckEnemy()
    {
        return Physics2D.OverlapCircle(enemyCheck.position, _enemyCheckRadius, enemyLayer);
    }

}
