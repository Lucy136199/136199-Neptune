using UnityEngine;

public class GraceSpaceshipMovement : MonoBehaviour
{
    public float floatAmount = 0.05f;
    public float floatSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float offsetX = Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        float offsetY = Mathf.Cos(Time.time * floatSpeed * 1.3f) * floatAmount;

        transform.position = startPosition + new Vector3(offsetX, offsetY, 0);
    }
}