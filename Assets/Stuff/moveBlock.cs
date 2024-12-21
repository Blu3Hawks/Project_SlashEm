using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Transform location1;
    [SerializeField] private Transform location2;
    [SerializeField] private float speed = 5f;

    private Transform targetLocation;

    private void Start()
    {
        // Start by moving towards location1
        targetLocation = location1;
    }

    private void Update()
    {
        // Move the NavMeshObstacle towards the target location
        transform.position = Vector3.MoveTowards(transform.position, targetLocation.position, speed * Time.deltaTime);

        // Switch target location when the obstacle reaches the current target
        if (Vector3.Distance(transform.position, targetLocation.position) < 0.1f)
        {
            targetLocation = targetLocation == location1 ? location2 : location1;
        }
    }
}
