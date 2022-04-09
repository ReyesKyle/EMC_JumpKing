using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    public float moveSpeed = 1f;
    private float moveInput;
    public bool isGrounded;
    private Rigidbody2D Rb;
    private SpriteRenderer Sr;
    public LayerMask groundMask;
    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpHeight = 0f;

    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
        Sr = gameObject.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if(isGrounded && jumpHeight == 0.0f)
        {
           Rb.velocity = new Vector2(moveInput * moveSpeed, Rb.velocity.y);
        }

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y -1f), new Vector2(0.9f,0.4f),0f,groundMask);

        if (jumpHeight > 0)
        {
            Rb.sharedMaterial = bounceMat;
        }
        else Rb.sharedMaterial = normalMat;

        if (Input.GetKey("space") && canJump && isGrounded) 
        {
            jumpHeight += 0.1f;
        }

        if (Input.GetKeyDown("space") && isGrounded && canJump)
        {
            Rb.velocity = new Vector2(0.0f, Rb.velocity.y);
        }

        if (jumpHeight >= 20f && isGrounded )
        {
            float tempx = moveInput * moveSpeed;
            float tempy = jumpHeight;
            Rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", .2f);
        }

        if (Input.GetKeyUp("space"))
        {
            Rb.velocity = new Vector2(moveSpeed * moveSpeed, jumpHeight);
            jumpHeight = 0;
        }

    }

    void ResetJump()
    {
        canJump = false;
        jumpHeight = 0;
    }

    private void onDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, transform.position.y - 1f), new Vector2(0.9f, 0.2f));
    }



}
