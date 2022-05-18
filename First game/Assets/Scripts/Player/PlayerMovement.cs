using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;//Player speed
    [SerializeField] private float jumpPower;//Player's jump speed

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D player;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private Animator anim;

    private void Awake()
    {
        // Grab references for rigidBody and animator from object
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        if (Input.GetButtonDown("Cancel"))
        {
            if (TimeState())
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
        // get player's movements left or right
        horizontalInput = Input.GetAxis("Horizontal");



        //Flip Player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);



        //Set Animator parameters
        anim.SetBool("run", horizontalInput != 0);// Animation name ,  value (True or False)
        anim.SetBool("grounded", isGrounded());// Animation name ,  value (True or False)


        // Wall jump logic
        if (wallJumpCooldown > 0.2f)
        {

            // player moves with velocity = speed in horizontal direction
            player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, player.velocity.y);

            if (onWall() && !isGrounded())
            {
                player.gravityScale = 0;
                player.velocity = Vector2.zero;
            }
            else
                player.gravityScale = 2.5f;

            // Make Player jump when space key is pressed
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
                if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
                    SoundManager.instance.PlaySound(jumpSound);
            }
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    private bool TimeState()
    {
        return Time.timeScale.Equals(1f);
    }
    private void Pause()
    {
        Time.timeScale = 0f;
    }
    private void UnPause()
    {
        Time.timeScale = 1f;
    }
    // player's jump  method
    private void Jump()
    {
        if (isGrounded())
        {

            player.velocity = new Vector2(player.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                player.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);// rotate the player
            }
            else
                player.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            wallJumpCooldown = 0;

        }
    }

    //tell that the player is on the ground or not
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    //tell that the player is attached to wall or not
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && !onWall();
    }

}
