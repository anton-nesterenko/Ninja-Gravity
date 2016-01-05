using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public UIInGameController uiInGameController;

    float maxSpeed = 2;
    bool facingRight = true, facingDown = true;

    Rigidbody2D rigiboydy;
    Animator anim;
    int xGravity, yGravity;
    bool xAxis = true;//, yAxis = false;
    //public float zRotation;

    const float gravityConst = -9.81f;

    // Use this for initialization
    void Start () {
        rigiboydy = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        setGravity (GameController.instance.xGravity, GameController.instance.yGravity);
        onChangeGaravity ();
    }

    // Update is called once per frame
    void Update () {
        if(xAxis) {
            // float move = Input.GetAxis ("Horizontal");
            float move = CFInput.GetAxis ("Horizontal");
            anim.SetFloat ("Speed", Mathf.Abs (move));
            rigiboydy.velocity = new Vector2 (move * maxSpeed, rigiboydy.velocity.y);
            if(facingRightUp) {
                if((move > 0) && !facingRight) {
                    FlipX ();
                } else if(move < 0 && facingRight) {
                    FlipX ();
                }
            } else {
                if((move > 0) && facingRight) {
                    FlipX ();
                } else if(move < 0 && !facingRight) {
                    FlipX ();
                }
            }
        } else {
            float move2 = CFInput.GetAxis ("Vertical");
            anim.SetFloat ("Speed", Mathf.Abs (move2));
            rigiboydy.velocity = new Vector2 (rigiboydy.velocity.x, move2 * maxSpeed * 2);
            if(facingRightUp) {
                if((move2 > 0) && facingRight) {
                    FlipX ();
                } else if(move2 < 0 && !facingRight) {
                    FlipX ();
                }
            } else {
                if((move2 > 0) && !facingRight) {
                    FlipX ();
                } else if(move2 < 0 && facingRight) {
                    FlipX ();
                }
            }
        }

        if(CFInput.GetKeyDown (KeyCode.A)) {
            FlipGravity ();
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        switch(other.tag) {
            case "Coint": {
                    float z = other.transform.localRotation.z;
                    if(Mathf.Abs (z) == Mathf.Abs (transform.localRotation.z)) {
                        Destroy (other.gameObject);

                        if(GameController.instance.currentLevel >= GameController.instance.openLockLevel) {
                            GameController.instance.openLockLevel += 1;
                        }
                        PlayerPrefs.SetInt ("OpenLockLevel", GameController.instance.openLockLevel);
                        PlayerPrefs.Save ();

                        GameController.instance.currentLevel += 1;

                        uiInGameController.showPopupWin ();
                    }
                    break;
                }
            case "Impediment":
                Application.LoadLevel ("load");
                break;
            case "FlipXGravity"://chay doc
                setGravity (-1, 0);
                break;
            case "FlipXGravity_Left"://chay doc
                setGravity (1, 0);
                break;
            case "FlipYGravity_Up"://chay ngang
                setGravity (0, -1);
                break;
            case "FlipYGravity_Down"://chay ngang
                setGravity (0, 1);
                break;
        }
    }

    void OnCollisionEnter2D (Collision2D coll) {

    }

    void FlipX () {
        facingRight = !facingRight;
        Vector3 vecScale = transform.localScale;
        vecScale.x *= -1;
        transform.localScale = vecScale;
    }
    bool facingRightUp = true;

    void setGravity (int x, int y) {
        xGravity = x;
        yGravity = y;
        onChangeGaravity ();
    }

    void FlipGravity () {
        xGravity = -xGravity;
        yGravity = -yGravity;
        onChangeGaravity ();
    }

    public void onChangeGaravity () {
        transform.localRotation = new Quaternion (0, 0, 0, 0);
        Physics2D.gravity = new Vector3 (gravityConst * xGravity, gravityConst * yGravity, 0);
        if(xGravity > 0 && yGravity == 0) {
            transform.Rotate (0, 0, -90);
            xAxis = false;
            facingRightUp = true;
        }

        if(xGravity < 0 && yGravity == 0) {
            transform.Rotate (0, 0, 90);
            xAxis = false;
            facingRightUp = false;
        }

        if(yGravity > 0 && xGravity == 0) {
            transform.Rotate (0, 0, 0);
            xAxis = true;
            facingRightUp = true;
        }

        if(yGravity < 0 && xGravity == 0) {
            transform.Rotate (0, 0, 180);
            xAxis = true;
            facingRightUp = false;
        }
    }
}
