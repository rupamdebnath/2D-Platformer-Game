using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public GameOverController gameOverController;
    public Animator animator;
    public ScoreController scorecontroller;
    public float speed;
    public float jump;
    private int health = 3;

    //public bool isGrounded = false;

    [SerializeField] private LayerMask platformMask;
    private Rigidbody2D rBody;
    private BoxCollider2D boxCollider2D;

    private GameObject life;
    public void KillPlayer()
    {
        //Debug.Log("Player attacked by enemy");

        //Destroy player object and play death animation
        //reset the level
        GameObject.Find("Life" + health).SetActive(false);
        health--;
        if (health == 0)
        {
            Debug.Log("Player is dead");
            //play death animation and restart level
            //SceneManager.LoadScene("NewScene");

            gameOverController.PlayerDied();
        }
    }

    private void Awake()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        gameObject.GetComponent<SpriteRenderer>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scorecontroller.IncreaseScore(10);
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //horizontal movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);
        if (IsGrounded())
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                animator.SetBool("Crouch", true);
            }
            else
            {
                animator.SetBool("Crouch", false);
            }
        }
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Jump");
        //vertical player movement
        if ((Input.GetKeyDown(KeyCode.Space) && IsGrounded()) || (vertical > 0 && IsGrounded()))
        {
            rBody.velocity = Vector3.up * jump;
        }
        else if(!IsGrounded())
        {
            animator.SetBool("Grounded", false);
        }

    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        //horizontal player movement
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * (Mathf.Abs(scale.x));
            
        }
        else if (horizontal > 0)
        {            
            scale.x = Mathf.Abs(scale.x);            
        }

        transform.localScale = scale;

        if (vertical>0)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Grounded", false);
        }
        else 
        {
            animator.SetBool("Jump", false);           

        }

    }

    private bool IsGrounded()
    {
        //make the Grounded parameter to true if Is Grounded
        if (transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded)
        animator.SetBool("Grounded", true);

        //return the isGrounded variable from this function
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
}
