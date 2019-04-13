using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float walkSpeed;
    public float jumpPower;
    public bool facingRight;

	public bool canDoubleJump;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRad;
    public LayerMask isGroundLayer;

    public Animator anim;

	//Power Ups
	public float powerUpTime;
	public float jumpBoost;

	[SerializeField]
	GameObject codePanel;

	public bool barrierUnlocked = false;

	public string sceneName;
	Scene scene;

	// Use this for initialization
	void Start ()
    {

		rb2d = GetComponent<Rigidbody2D>();

        tag = "Player";

        walkSpeed = 4.0f;
        jumpPower = 11.0f;

		codePanel.SetActive(false);

		scene = SceneManager.GetActiveScene();
		sceneName = scene.name;

        if (!groundCheck)
        {
            groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
        }

        if (groundCheckRad <= 0.0f)
        {
            groundCheckRad = 0.1f;
        }

		

		powerUpTime = 1.0f;
		jumpBoost = 4.0f;

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

       
            if (Input.GetButtonDown("Jump"))
            {
				if (isGrounded)
				{
					rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
					canDoubleJump = true;
				}
				else
				{
					if (canDoubleJump)
					{
						canDoubleJump = false;
						rb2d.velocity = new Vector2(rb2d.velocity.x, 0.0f);
						rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
					} 
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

	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Barrier") && !barrierUnlocked)
		{
			codePanel.SetActive(true);
		}

		// Check if player collides with the tagged power up 'Jump Boost' 
		if (collision.gameObject.CompareTag("JumpBoostPowerUp"))
		{

			Debug.Log("JumpPower Applied");
			jumpPower += jumpBoost;

			StartCoroutine(stopJumpMode());
		}

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Die();
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

	void Die()
	{
		SceneManager.LoadScene(sceneName);
	}

	IEnumerator stopJumpMode()
	{
		yield return new WaitForSeconds(powerUpTime);

		// turn off powerup after sepecified time
		jumpPower -= jumpBoost;
		Debug.Log("JumpBoost Disabled");
	}



}
