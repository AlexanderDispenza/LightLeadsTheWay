using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D rb2d;

    public float walkSpeed;
    public float jumpPower;
    public bool facingRight;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRad;
    public LayerMask isGroundLayer;

    public Animator anim;

	[SerializeField]
	GameObject codePanel;

	public bool barrierUnlocked = false;
	// Use this for initialization
	void Start ()
    {
        tag = "Player";

        walkSpeed = 4.0f;
        jumpPower = 11.0f;

		codePanel.SetActive(false);

        if (!groundCheck)
        {
            groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
        }

        if (groundCheckRad <= 0.0f)
        {
            groundCheckRad = 0.1f;
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveValue = Input.GetAxisRaw("Horizontal");

		if (barrierUnlocked)
		{
			codePanel.SetActive(false);
		}

        if (groundCheck)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRad, isGroundLayer);
        }

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }
        rb2d.velocity = new Vector2(moveValue * walkSpeed, rb2d.velocity.y);

        // Handle animations
        if (anim)
        {
            anim.SetFloat("MoveValue", Mathf.Abs(moveValue));
            anim.SetBool("isGrounded", isGrounded);
        }

        if (facingRight && moveValue < 0 || !facingRight && moveValue > 0)
        {
            flipSprite();
        }

    }

	// check to see if player interacts with barrier 
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Barrier") && !barrierUnlocked)
		{
			codePanel.SetActive(true);
		} 
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Barrier"))
		{
			codePanel.SetActive(false);
		}
	}

	void flipSprite()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }
}
