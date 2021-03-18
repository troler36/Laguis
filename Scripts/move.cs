using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class move : MonoBehaviour
{
    // floats
    public float speed;
    public float jumpPower;
    public float moveInput;
    private bool Groundion;
   

    public Rigidbody2D rb;

    // Important Stuff
    public bool facingRight = true;
    public GameObject player;
    public Transform playerCheck;
    public float pointRadius = 0.5f;
    public LayerMask groundLayer;





    // Dungeon Wise
    void Start()
    {

        // Gets Components
        
        rb = GetComponent<Rigidbody2D>();

    }
    




    // Kitchen Wise
    void FixedUpdate()
    {



        moveInput = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        if (facingRight == false && moveInput > 0)
        {            
            Flip();
        }else if(facingRight == true && moveInput < 0)
        {
            Flip();
           
        }
        Jump();
        
    }
    // Functions
    void Jump()
    {
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Debug.Log("pressed");
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        

    }


    public bool isGrounded()
    {
        Collider2D checking = Physics2D.OverlapCircle(playerCheck.position, pointRadius, groundLayer);

        if (checking.gameObject != null)
        {
            
            return true;
        }
        if(checking.gameObject == null)
        {
            
        }

        return false;
        
    }
    void OnDrawGizmosSelected()
    {

        if (playerCheck == null)
        {
            return;
        }
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(playerCheck.position, pointRadius);
    }



}
