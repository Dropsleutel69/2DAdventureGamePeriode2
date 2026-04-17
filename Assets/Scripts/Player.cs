using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Number of coins collected by the player
    public int coins;
    //Player health (starts at 100)
    public int health = 100;
    
    //movement speed of the player and power of the jump
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    
    //ground check mechanic
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    
    //UI image used as healthbar
    public Image healthImage;
    
    //Sound effects
    public AudioClip jumpClip;
    public AudioClip hurtClip;
    
    //Component reference
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer SpriteRenderer;
    private AudioSource audioSource;
   
    //Extra jumps (for double jump)
    public int extraJumpsValue = 1;
    private int extraJumps;
    void Start()
    {
        //Get required components
        rb = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        //Set initial extra jumps
        extraJumps = extraJumpsValue;
    }

    void Update()
    {
        //Get horizontal input (A & D keys, or arrow keys)
        float moveInput = Input.GetAxis("Horizontal");
        //Move the player horizontal
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        //Resets jumps when grounded
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        //Jump when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //normal jump
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                PlaySFX(jumpClip);
            }
            //double jump 
            else if (extraJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                extraJumps--;
                PlaySFX(jumpClip);
            }
        }

        SetAnimation(moveInput);

        healthImage.fillAmount = health / 100f;
    }

    private void FixedUpdate()
    {
        //Check if the player is touching the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if(moveInput == 0)
            {
                animator.Play("Player_Idle"); //Idle animation
            }
            else
            {
                animator.Play("Player_Run"); //Run animation
            }
        }
        else
        {
            if(rb.linearVelocityY < 0)
            {
                animator.Play("Player_Jump"); //Going up
            }
            else
            {
                animator.Play("Player_Fall"); //Going down
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player collides with something that deals damage 
        if(collision.gameObject.tag == "Damage")
        {
            PlaySFX(hurtClip);
            //reduce health
            health -= 25;
            //apply small knockback upwards
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            //Start blink red effect
            StartCoroutine(BlinkRed());

            //Check if player is dead
            if(health <= 0)
            {
                Die();
            }
        }
    }

    private IEnumerator BlinkRed()
    {
        //Shortly change the color to red
        SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        SpriteRenderer.color = Color.white;
    }

    private void Die()
    {
        //reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void PlaySFX(AudioClip audioClip, float volume = 1f)
    {
        //play a sound effect
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
    }
}
