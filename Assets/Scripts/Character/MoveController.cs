using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isMoving = default;
    public Direction direction;

    public void Move()
    {
        isMoving = true;

        var moveTarget = Vector3.zero;
        if (direction == Direction.Right)
        {
            moveTarget = Vector3.right;
        }
        else
        {
            moveTarget = Vector3.left;
        }

        transform.position += moveTarget * speed * Time.deltaTime;
    }

    public void SetDirection(Direction direction)
    {
        this.direction = direction;
        switch (direction)
        {
            case Direction.Left:
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case Direction.Right:
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
    }
}
