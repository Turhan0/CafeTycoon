using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    public Transform WaypointParent;
    public float Speed = 5f;
    public float waitTime = 1f;
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;

    void Start()
    {
        waypoints = WaypointParent.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length > 0)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }
}
