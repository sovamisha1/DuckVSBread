using UnityEngine;

public class Main : MonoBehaviour
{
    // ���������� ��� ��������
    public float maxSpeed = 10f;
    public float jump = 300f;
    public bool isRight = false;

    // ���������� ��� �������������� ������ � �������
    private bool isGrounded;
    public Transform GroundCheck;
    public float checkRadius = 0.2f;
    public LayerMask Ground;

    // ��������� ��� �������� � ��� RigidBody
    Rigidbody2D rb;

    private void Start()
    {
        // ���������� rb ����� ��������� RigidBody ��� ��������� ����
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Jump();
        Move();
        GroundChecks();
    }
    
    private void Move()
    {
        // ���������� move �������� �� a,d right arrow, left arrow
        // ��������� ������� �����
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        // �������� ��� ����������� �������� ���������
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
            rb.AddForce(Vector2.up * jump);
        }
    }

    private void GroundChecks()
    {
        // ����������� isGrounded True ���� GroundCheck.position � �������� checkRadius �������� ���� Ground
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
}
    
