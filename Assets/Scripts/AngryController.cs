using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            direction = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.S)) {
        direction = Vector2.down;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            direction = Vector2.left;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            direction = Vector2.right;
        }
    } 

    void FixedUpdate()
    {
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
        );
    }
}
