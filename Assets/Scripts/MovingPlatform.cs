using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Speed at which the platform moves
    public float speed = 2f;

    // Points the platform will move between
    public Transform[] points;

    // Current target point index
    private int i;

    void Start()
    {
        // Set the starting position to the first point
        transform.position = points[0].position;
    }

    void Update()
    {
        // Check if the platform is very close to the current target point
        if (Vector2.Distance(transform.position, points[i].position) < 0.01f)
        {
            i++; // Move to the next point

            // If the last point is reached, loop back to the first
            if (i == points.Length)
            {
                i = 0;
            }
        }

        // Move the platform towards the current target point
        transform.position = Vector2.MoveTowards(
            transform.position,
            points[i].position,
            speed * Time.deltaTime
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player lands on the platform
        if (collision.gameObject.tag == "Player")
        {
            // Make the player a child of the platform
            // This ensures the player moves along with it
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // When the player leaves the platform
        if (collision.gameObject.tag == "Player")
        {
            // Remove the player from the platform
            collision.transform.SetParent(null);
        }
    }
}