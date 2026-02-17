using UnityEngine;
using System.Linq;

public class WaypointMover : MonoBehaviour
{
    public Transform WaypointParent;
    public Transform InsideWaypointParent;
    public float Speed = 5f;
    public float waitTime = 1f;
    private Transform[] waypoints;
    private Transform[] insideWaypoints;
    private int currentWaypointIndex = 0;
    public bool isInside = false;
    public int npcID = 0;

    void Start()
    {
        waypoints = WaypointParent.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        insideWaypoints = InsideWaypointParent.GetComponentsInChildren<Transform>().Skip(1).ToArray();;
        Shuffle(waypoints);
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length > 0 && !isInside)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;

            if (waypoints[currentWaypointIndex].name == "Waypoint (5)")
            {
                Debug.Log("Reached Waypoint 5, pausing for 5 seconds before setting isInside to true");
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);

                StartCoroutine(PauseAndEnterShop());

                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
            

    }

                private System.Collections.IEnumerator PauseAndEnterShop()
            {
                
                yield return new WaitForSeconds(9f);
                
                isInside = true;
                var collider = GetComponent<BoxCollider2D>();
                if (collider != null)
                {
                    collider.isTrigger = false;
                }
                            Vector3 insideTargetPosition = insideWaypoints[npcID].position;
            transform.position = Vector3.MoveTowards(transform.position, insideTargetPosition, Speed * Time.deltaTime);
            }
    private void Shuffle<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
