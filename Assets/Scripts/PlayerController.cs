using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
	public CharacterController2D controller;
	public float horizontalMove = 0f;
	bool jump = false;
    public Animator animator;
	
	int jumpCount = 0; //keep track of the number of allowed jumps we have left
	int maxJumps = 1; //the total number of max jumps allowed

	// Use this for initialization
	void Start () 
	{
		jumpCount = maxJumps;
	}
	
	// Update is called once per frame
	void Update () 
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			jumpCount -= 1;
			jump = false;
            animator.SetBool("Jump", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
			controller.Move(horizontalMove, false, jump);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
			controller.Move(horizontalMove, false, jump);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void m_Grounded()
    {
        animator.SetBool("Jump", false);
    }
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		jumpCount = maxJumps;
	}






}
