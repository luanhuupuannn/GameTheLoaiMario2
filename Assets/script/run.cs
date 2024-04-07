using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;        // Movement speed
    [SerializeField] private float movementRange = 3.0f; // Half the patrol distance
    [SerializeField] private GameObject player;         // Reference to the player

    private float startingX;                            // Monster's starting X position
    private bool isChasingPlayer = false;               // Flag for chasing state
    private bool isPatrolling = true;                   // Flag for patrolling state 
    private float patrolDirection = 1;                  // 1 for right, -1 for left

    void Start()
    {
        startingX = transform.position.x;
    }

    void Update()
    {
        // Check if player is within range
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= 5.0f)
        {

            isChasingPlayer = true;
            isPatrolling = false; // Stop patrolling when chasing

            Vector3 flip = transform.localScale;
            flip.x = 3.51437f;
            transform.localScale = flip;
        }
        else if (distanceToPlayer > 5.0f && isChasingPlayer)
        {
            isChasingPlayer = false;
            isPatrolling = true; // Resume patrolling when player is out of range

            Vector3 flip = transform.localScale;
            flip.x = -3.5143f;
            transform.localScale = flip;
        }

        // Movement logic
        if (isChasingPlayer)
        {
            // Chase the player
            float targetX = player.transform.position.x;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
        else if (isPatrolling)
        {
            // Patrol back and forth
            float targetX = startingX + patrolDirection * movementRange;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime);

            if (Mathf.Abs(transform.position.x - targetX) < 0.1f) // If near target position
            {
                patrolDirection *= -1; // Reverse patrol direction
            }
        }
    }
}
