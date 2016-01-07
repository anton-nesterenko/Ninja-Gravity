using UnityEngine;
using System.Collections;

public class FlowerAmmo : MonoBehaviour {
    public GameObject ammo;

    float time = 0;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        if(time >= 2.0f) {
            time = 0;
            GameObject am = Instantiate (ammo, transform.position, transform.rotation) as GameObject;
            am.GetComponent<Rigidbody2D> ().AddForce (-transform.localScale.x * Vector2.right * 100);
        }
    }
}
