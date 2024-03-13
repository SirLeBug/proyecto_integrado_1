using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2.2f;
    public float jumpSpeed = 3f;

    public bool isGrounded;
    public LayerMask suelo;

    Rigidbody2D rb2D;
    SpriteRenderer spR;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spR = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spR.flipX = false;
        }

        else if (Input.GetKey("left") || Input.GetKey("a"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spR.flipX = true;
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if ((Input.GetKey("w") || Input.GetKey("space")) && isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }


        Debug.DrawLine(transform.position, new Vector3(0, -0.2f,0)+transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.22f, suelo);
        if (hit.collider != null)
        {
            //Debug.Log(hit.collider);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platformMoving") && isGrounded)
        {
            Debug.Log("esta la plataforma");
            transform.SetParent(collision.gameObject.transform);
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Respawn");
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.CompareTag("finishFlag"))
        {
            Debug.Log("Respawn");
            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        Debug.Log("esta en el aire");
        transform.SetParent(null);
    }
}