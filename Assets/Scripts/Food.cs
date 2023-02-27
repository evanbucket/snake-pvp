using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public BoxCollider2D gridArea;

    public void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomizePosition();
    }

    // This may have to change when second player is implemented! There will probably have to be a player 1 tag and a player 2 tag
    // Maybe have 2 different foods on the area for balance?
    
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
