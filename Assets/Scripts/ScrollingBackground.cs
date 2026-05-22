using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float backgroundWidth = 28.36f;

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x <= -backgroundWidth)
        {
            transform.position += new Vector3(backgroundWidth * 2f, 0, 0);
        }
    }
}