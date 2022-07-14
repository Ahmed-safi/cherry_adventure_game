using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePiayer : MonoBehaviour
{
   private Rigidbody2D rb;
   private Animator anim;
   private SpriteRenderer sprit;
   private BoxCollider2D coll;
   [SerializeField] private LayerMask jumpableGround;

   private float dX = 0f;
   [SerializeField] private float speedR = 7f;
   [SerializeField] private float forceJ = 14f;

    private enum MovementState { idle, running, jumping, falling }
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprit = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void Update(){

        dX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dX * speedR, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()){
            jumpSoundEffect.Play();
             rb.velocity = new Vector2(rb.velocity.x, forceJ);
        }
        UpdateAnimtioneState();
 
    }
private void UpdateAnimtioneState(){

        MovementState state;

        if (dX > 0f)
        {
            state = MovementState.running;
            sprit.flipX = false;
        }
        else if (dX < 0f)
        {
            state = MovementState.running;
            sprit.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
     private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
