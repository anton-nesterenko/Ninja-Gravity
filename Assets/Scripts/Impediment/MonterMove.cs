using UnityEngine;
using System.Collections;

public class MonterMove : MonoBehaviour {
    public bool isXAxis = true;
    float speed = 40.0f;
    Rigidbody2D rig;
    // Vector3 vct;
    // Use this for initialization
    void Start () {
        // vct = transform.position;
        rig = GetComponent<Rigidbody2D> ();
        //rig.velocity = new Vector2 (rig.velocity.x, maxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(isXAxis) {
            // vct.x += Time.deltaTime * speed;
            rig.velocity = new Vector2 (Time.deltaTime * speed, rig.velocity.y);
        } else {
            //vct.y += Time.deltaTime * speed;
            rig.velocity = new Vector2 (rig.velocity.x, Time.deltaTime * speed);
        }
        //transform.position = vct;
    }

    void OnTriggerEnter2D (Collider2D other) {
        switch(other.tag) {
            case "Map": 
            case "Wall":
                speed = -speed;
                break;
            default:
                break;
        }
    }

    void OnCollisionEnter2D (Collision2D coll) {
        switch(coll.gameObject.tag) {
            case "Map": 
            case "Wall":
                speed = -speed;
                break;
            default:
                break;
        }
    }
}
