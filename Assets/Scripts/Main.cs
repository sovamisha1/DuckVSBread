using UnityEngine;

public class Main : MonoBehaviour
{
    // переменные для движения
    public float maxSpeed = 10f;
    public float jump = 300f;
    public bool isRight = false;

    // переменные для предотвращения прыжка в воздухе
    private bool isGrounded;
    public Transform GroundCheck;
    public float checkRadius = 0.2f;
    public LayerMask Ground;

    // перемнная для хранения в ней RigidBody
    Rigidbody2D rb;

    private void Start()
    {
        // переменная rb берет компонент RigidBody для упрощения кода
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
        // переменная move отвечает за a,d right arrow, left arrow
        // изменение позиции перса
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        // проверка для отображения поворота персонажа
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
        // присваиваем isGrounded True если GroundCheck.position с радиусом checkRadius касается слоя Ground
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
}
    
