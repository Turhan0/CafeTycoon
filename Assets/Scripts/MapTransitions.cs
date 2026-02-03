using UnityEngine;
using Unity.Cinemachine;

public class MapTransitions : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundary;
    CinemachineConfiner2D confiner;
    [SerializeField] Direction direction;
    [SerializeField] Transform teleportTargetPosition;
    [SerializeField] float offset;
    public GameObject interactIndicator;
    public KeyCode interactKey = KeyCode.E;
    private bool isPlayerInRange = false;
    private GameObject player;

    enum Direction { Up, Down, Left, Right, Teleport }


    void Update(){
        if(isPlayerInRange && Input.GetKeyDown(interactKey)){
            confiner.BoundingShape2D = mapBoundary;
            UpdatePlayerPosition(player);
        }
    }

    private void Awake()
    {
        interactIndicator = GameObject.Find("InteractIndicator");
        confiner = FindAnyObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // confiner.BoundingShape2D = mapBoundary;
            // UpdatePlayerPosition(collision.gameObject);
            player = collision.gameObject;
            interactIndicator.GetComponent<SpriteRenderer>().enabled = true;
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // confiner.BoundingShape2D = mapBoundary;
            // UpdatePlayerPosition(collision.gameObject);
            interactIndicator.GetComponent<SpriteRenderer>().enabled = false;
            isPlayerInRange = false;
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
