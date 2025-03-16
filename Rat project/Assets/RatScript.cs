using Assets;
using System;
using UnityEngine;

public class RatScript : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public int jump_speed = 20;
    public float walk_speed = 20F;
    public bool isGrounded = true;
    public static bool facingRight = true;
    public Vector2 movement;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (RatDashAttack.isDashing)
            return;
        movement.x = Input.GetAxisRaw("Horizontal");
        if (movement.x > 0 && !facingRight) Flip();
        if (movement.x < 0 && facingRight) Flip();

        myRigidbody.linearVelocity = new Vector2(movement.x * walk_speed, myRigidbody.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            myRigidbody.linearVelocity = Vector2.up * jump_speed;
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collider")) isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collider")) isGrounded = false;
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the sprite by inverting the X scale
        transform.localScale = scale;
    }
}
