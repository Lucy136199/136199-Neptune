using UnityEngine;

public class RockySpaceship : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0.5f, 0f, 0f);
    public float moveSpeed = 2f;

    public bool arrived = false;

    void Update()
    {
        if (arrived) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPosition) < 1.65f)
        {
            arrived = true;
            Debug.Log("Rocky arrived");
        }
    }
}
