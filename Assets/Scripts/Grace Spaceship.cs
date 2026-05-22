using UnityEngine;

public class GraceSpaceship : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float smoothTime = 0.15f;

    private Vector2 currentVelocity;
    private Vector2 movement;

    [Header("Boundary")]
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 targetMovement = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        movement = Vector2.SmoothDamp(
            movement,
            targetMovement,
            ref currentVelocity,
            smoothTime
        );
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        rb.MovePosition(newPosition);
    }
}