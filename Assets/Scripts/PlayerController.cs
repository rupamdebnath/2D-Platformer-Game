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
        //Destroy player object and play death animation

        GameObject.Find("Life" + health).SetActive(false);
        health--;          
        if (health == 0)
        {
            SoundManager.Instance.PlayPlayerSound(gameObject.GetComponent<AudioSource>(), PlayerSounds.PlayerDeath);
            animator.SetTrigger("Death");
            Invoke("WaitingForDeath", 2f);
        }
        else
        {
            animator.SetTrigger("Hurt");
            SoundManager.Instance.PlayPlayerSound(gameObject.GetComponent<AudioSource>(), PlayerSounds.PlayerHurt);            
        }
    }

    private void WaitingForDeath()
    {
        Debug.Log("Player is dead");
        //play death animation and restart level
        //
        gameOverController.PlayerDied();
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
        SoundManager.Instance.PlayOnce(UISounds.KeyPickup);
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
            animator.SetBool("Grounded", IsGrounded());
            
            if (Input.GetKey(KeyCode.LeftControl))
            {
                animator.SetBool("Crouch", true);
            }
            else
            {
                animator.SetBool("Crouch", false);
            }
        }
        else
        {
            animator.SetBool("Grounded", IsGrounded());            
        }
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Jump");
        //vertical player movement
        if ((Input.GetKeyDown(KeyCode.Space) && IsGrounded()) || (vertical > 0 && IsGrounded()))
        {
            rBody.velocity = Vector3.up * jump;
            animator.SetBool("Grounded", false);
        }
        else
            animator.SetBool("Jump", false);
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
    public bool IsGrounded()
    {        
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
}
