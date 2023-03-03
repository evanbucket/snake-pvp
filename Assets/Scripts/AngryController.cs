using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryController : MonoBehaviour
{
    private Rigidbody2D rb;
    // Change when making sad snake to change direction
    private Vector2 direction = Vector2.right;
    private Vector2 input;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public GameObject sadSnake;
    public GameObject foodFruit;
    public int initialSize = 3;
    private bool isResettingEnemyState = false;

    //Start is called before the first frame update
    void Start()
    {
        // Allows the snake to start at size 3 at the start of the game by resetting the state of the game
        ResetAngryState();
    }

    //Update is called once per frame
    void Update()
    {
        // Only allow turning up or down while moving in the x-axis
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W)) {
                input = Vector2.up;
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                input = Vector2.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.A)) {
                input = Vector2.left;
            }
            
            if (Input.GetKeyDown(KeyCode.D)) {
                input = Vector2.right;
            }
        }
        // I KNOW WHAT THE INPUT PROBLEM IS!
        // When there are 2 inputs while the snake is on one tile, the game only inputs the first one, instead of both of them in sequence.
        // How to fix this: I have no idea. BUT NOW I KNOW WHAT THE PROBLEM IS! its not fps I don't think
    } 

    void FixedUpdate()
    {
        // Set the new direction based on the input
        if (input != Vector2.zero) {
            direction = input;
        }
        // Set each segment's position to be the same as the one it follows.
        // We must do this in reverse order so the position is set to the previous
        // position, otherwise they will all be stacked ontop of each other.
        for (int i = segments.Count - 1; i > 0; i--) {
            segments[i].position = segments[i - 1].position;
        }

        // Move the snake in the direction it is facing
        // Round the values to ensure it aligns to the grid
        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }
    private void ResetEnemyState()
    {
        isResettingEnemyState = true;
        sadSnake.GetComponent<SadController>().ResetSadState();
        foodFruit.GetComponent<Food>().RandomizePosition();
        isResettingEnemyState = false;
    }

    public void ResetAngryState()
    {
        if(isResettingEnemyState) {
            return;
        }
        ResetEnemyState();
        direction = Vector2.right;
        input = Vector2.right;
        this.transform.position = new Vector3(-11, 0, 0);

        // Start at 1 to skip destroying the head
        for (int i = 1; i < segments.Count; i++) {
            Destroy(segments[i].gameObject);
        }

        // Clear the list but add back this as the head
        segments.Clear();
        segments.Add(transform);

        // -1 since the head is already in the list
        for (int i = 1; i < this.initialSize; i++) {
            Grow();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // collision with food and obstacle/player.
        if (other.tag == "Food") {
            Grow();
        } else if (other.tag == "Obstacle" || other.tag == "Player") {
            ResetAngryState(); 

            // Lose a life!
            /* Debug.Log("Angry is taking damage"); */
            GetComponent<AngryHeartSystem>().TakeDamage(1);
        }
    } 
}
