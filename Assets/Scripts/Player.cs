using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 11f;

    //private bool isJumpKeyPressed;
    //private int superJumpsRemaining;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        AnimatePlayer();
       
    }

    private void FixedUpdate()
    {
        PlayerMoveKeyboard();
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            //go right
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else if (movementX < 0)
        {
            //go left
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else
        {
            //idle
            anim.SetBool(WALK_ANIMATION, false);
        }
        
    }


    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) //platform neutral
        {
            isGrounded = false;
            //float jumpForce = 15;
            //if (superJumpsRemaining > 0)
            //{
            //    jumpForce = 25;
            //    superJumpsRemaining--;
            //}
            //myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }


}
