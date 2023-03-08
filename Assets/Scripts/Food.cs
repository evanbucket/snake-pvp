using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public BoxCollider2D gridArea;
    private AngryController angry;
    private SadController sad;

    public void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Round the values to ensure it aligns with the grid
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        // Prevent food from spawning on snakes
        while (angry.Occupies(x, y) || sad.Occupies(x,y)) {
            x++;

            if (x > bounds.max.x) {
                x = bounds.min.x;
                y++;

                if (y > bounds.max.y) {
                    y = bounds.min.y;
                }
            }
        }

        // Assign the final position
        transform.position = new Vector2(x, y);
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomizePosition();
    }

    private void Awake()
    {
        angry = FindObjectOfType<AngryController>();
        sad = FindObjectOfType<SadController>();
    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            RandomizePosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
