using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    BoxCollider2D bodyCollider;
    Rigidbody2D rb2d;

    public bool facingRight = true;
    public bool grounded = false;
    public float maxSpeed = 10f;
    public float jumpForce = 50f;

    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    void Update() {
        if (grounded && Input.GetAxis("Jump") > 0) {
            rb2d.AddForce(new Vector2(0, jumpForce));
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

    }
}
