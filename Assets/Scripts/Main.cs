using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    public float maxSpeed = 10f;
    public float jump = 300f;
    
    public bool isRight = false;
    private bool isGrounded;

    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask Ground;

    


    void Start()
    {
        
    }

    void Update()
    {
        Jump();
        Move();
        GroundChecks();
    }

    private void Move()
    {
        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if(move > 0 && !isRight)
            Flip();
        else if (move < 0 && isRight)
            Flip();
    }
    private void Flip()
    {
        isRight = !isRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump);
        }
    }

    private void GroundChecks()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
}
    
