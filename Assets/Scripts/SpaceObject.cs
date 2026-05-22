using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    public enum ObjectType
    {
        Xenonite,
        Rocky,
        Astrophage,
        Asteroid,
    }

    public ObjectType objectType;

    [Header("Movement")]
    public float moveSpeed = 4f;
    public float destroyX = -11f;

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (objectType == ObjectType.Xenonite)
        {
            GameManager.instance.AddXenonite();
        }
        else if (objectType == ObjectType.Rocky)
        {
            GameManager.instance.AddHullPercent(0.10f);
        }
        else if (objectType == ObjectType.Astrophage)
        {
            GameManager.instance.AddFuelPercent(0.10f);
        }
        else if (objectType == ObjectType.Asteroid)
        {
            GameManager.instance.DamageHullPercent(0.20f);
        }
        Destroy(gameObject);
    }
}