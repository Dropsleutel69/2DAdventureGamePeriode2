using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Movement speed of the enemy
    public float speed = 2f;

    // Points the enemy will move between
    public Transform[] points;

    // Index of the current target point
    private int i = 0;

    // Reference to the SpriteRenderer (used to flip the sprite)
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Set the target position (only move on X axis, keep current Y)
        Vector2 targetPosition = new Vector2(points[i].position.x, transform.position.y);

        // Check if the enemy is close to the current target point
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            i++; // Move to the next point

            // If we reached the last point, go back to the first
            if (i >= points.Length)
            {
                i = 0;
            }
        }

        // Move the enemy towards the target point
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        // Flip the sprite depending on movement direction
        spriteRenderer.flipX = (transform.position.x - points[i].position.x) < 0f;
    }
}