using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.right;
    private List<Transform> segments;
    public Transform segmentPrefab;

    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            direction = Vector2.up;
        } 
        
        if (Input.GetKeyDown(KeyCode.S)) {
        direction = Vector2.down;
        }
        
        if (Input.GetKeyDown(KeyCode.A)) {
            direction = Vector2.left;
        }
        
        if (Input.GetKeyDown(KeyCode.D)) {
            direction = Vector2.right;
        }
    } 

    void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i++)
        {
            segments[i].position = segments /*START AGAIN HERE*/
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food") {
            Grow();
        }
    }
}
