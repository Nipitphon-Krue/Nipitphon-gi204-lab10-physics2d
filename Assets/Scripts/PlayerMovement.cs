using UnityEngine;

public class Scripts : MonoBehaviour
{
    Rigidbody2D rb2d; //private variable

    Vector2 moveInput; //for walk with addforce

    //walk left-right
    float move; //store Input from player
    [SerializeField] float speed;

    //Jump
    [SerializeField] float jumpForce;
    [SerializeField] bool isJumping;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();       
    }

    void Update()
    {
        //walk with addforce
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * speed);

        //walk left-right
        //move = Input.GetAxis("Horizontal");
        //rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);

        //Jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
            Debug.Log("Jump!"); //for debugging
        } 
    }


    private void OnCollisionEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

}
