using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 12.5f;
    public Camera mainCamera;
    public float padding = 1f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
            rb.velocity = movement;
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        Vector3 playerScreenPos = mainCamera.WorldToScreenPoint(transform.position);

        if (playerScreenPos.x < padding)
        {
            playerScreenPos.x = padding;
        }
        else if (playerScreenPos.x > Screen.width - padding)
        {
            playerScreenPos.x = Screen.width - padding;
        }

        transform.position = mainCamera.ScreenToWorldPoint(playerScreenPos);
    }
}