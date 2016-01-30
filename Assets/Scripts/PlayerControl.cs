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

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround;

    // Use this for initialization
    void Start () {
        rigiboydy = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        setGravity (GameController.instance.xGravity, GameController.instance.yGravity);
        onChangeGaravity ();
    }

    // Update is called once per frame
    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
        //if(grounded) {
        if(xAxis) {
            // float move = Input.GetAxis ("Horizontal");
            float move = CFInput.GetAxis ("Horizontal");
            if(grounded)
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
            if(grounded)
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
            if(grounded)
                FlipGravity ();
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        switch(other.tag) {
            case "Coint": {
                    SoundController.instance.SoundPickUp ();
                    float z = other.transform.localRotation.z;
                    if(Mathf.Abs (z) == Mathf.Abs (transform.localRotation.z)) {
                        Destroy (other.gameObject);

                        if(GameController.instance.currentLevel >= GameController.instance.openLockLevel) {
                            GameController.instance.openLockLevel += 1;
                        }

                        uiInGameController.showPopupWin ();
                    }

                    GameController.instance.write_data_to_json ();
                    break;
                }
            case "Impediment":
                Application.LoadLevel ("load");
                break;
            case "FlipXGravity":
                SoundController.instance.SoundRotate ();
                other.enabled = false;
                rigiboydy.isKinematic = true;
                rigiboydy.isKinematic = false;
                if(xGravity == 0 && yGravity != 0) {
                    setGravity (-1, 0);
                } else if(xGravity != 0 && yGravity == 0) {
                    setGravity (0, 1);
                }
                StartCoroutine (demo (other));
                break;
            default:
                break;
        }
    }

    IEnumerator demo (Collider2D other) {
        yield return new WaitForSeconds (0.5f);
        other.enabled = true;
    }

    void OnCollisionEnter2D (Collision2D coll) {
        switch(coll.gameObject.tag) {
            case "Impediment":
                Application.LoadLevel ("load");
                break;
            default:
                break;
        }
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
        SoundController.instance.SoundFlip ();
        xGravity = -xGravity;
        yGravity = -yGravity;
        onChangeGaravity ();
        //setGravity (-xGravity, -yGravity);
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
