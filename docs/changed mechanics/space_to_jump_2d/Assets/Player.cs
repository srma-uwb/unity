using UnityEngine;

public class Player : MonoBehaviour
{
    public bool grounded = true;
    private Rigidbody2D rb2d;
    public float jumpPower;
    private BoxCollider2D boxCollider2D;
    private bool canDouble = false; //Added for double jump
    [SerializeField] private LayerMask platformsLayerMask;

    void Start()
    {
        rb2d = rb2d = GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb2d.velocity = Vector2.up * jumpPower;
            canDouble = true;
        }

        //Double jump by me
        if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded() && canDouble)
        {
            rb2d.velocity = Vector2.up * jumpPower;
            canDouble = false;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }
}
