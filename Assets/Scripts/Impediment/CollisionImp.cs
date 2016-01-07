using UnityEngine;
using System.Collections;

public class CollisionImp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D other) {
        switch(other.tag) {
            case "Map":
                Destroy (gameObject);
                break;
            default:
                break;
        }
    }

    void OnCollisionEnter2D (Collision2D coll) {
        switch(coll.gameObject.tag) {
            case "Map":
                Destroy (gameObject);
                break;
            default:
                break;
        }
    }
}
