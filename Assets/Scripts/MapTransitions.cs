using UnityEngine;
using Unity.Cinemachine;

public class MapTransitions : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundary;
    CinemachineConfiner2D confiner;
    [SerializeField] Direction direction;
    [SerializeField] Transform teleportTargetPosition;
    [SerializeField] float offset;

    enum Direction { Up, Down, Left, Right, Teleport }


    private void Awake()
    {
        confiner = FindAnyObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundary;
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject player)
    {
        if (direction == Direction.Teleport)
        {
            player.transform.position = teleportTargetPosition.position;
            return;
        }

        Vector3 newPos = player.transform.position;

        float offset = 2f; // Distance to move the player

        switch (direction)
        {
            case Direction.Up:
                newPos.y += offset;
                break;
            case Direction.Down:
                newPos.y -= offset;
                break;
            case Direction.Left:
                newPos.x -= offset;
                break;
            case Direction.Right:
                newPos.x += offset;
                break;
        }

        player.transform.position = newPos;
    }
}
