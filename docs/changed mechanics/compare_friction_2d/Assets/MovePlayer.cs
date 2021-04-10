using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float acceleration = 1f;
    private Rigidbody2D rb2d;

    public Vector2 movement;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveCharacter(transform.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveCharacter(-transform.right);
        }
    }

    void moveCharacter(Vector3 direction)
    {
        rb2d.AddForce(direction / 2);
    }
}