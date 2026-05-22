using UnityEngine;

public class SpaceObject3 : MonoBehaviour
{
    public enum ObjectType
    {
        Xenonite,
        Rocky,
        Astrophage,
        AdrianMeteor
    }

    public ObjectType objectType;

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

        if (GameManager3.instance == null)
        {
            return;
        }

        if (objectType == ObjectType.Xenonite)
        {
            GameManager3.instance.AddXenonite();
        }
        else if (objectType == ObjectType.Rocky)
        {
            GameManager3.instance.AddHullPercent(0.10f);
        }
        else if (objectType == ObjectType.Astrophage)
        {
            GameManager3.instance.AddFuelPercent(0.10f);
        }
        else if (objectType == ObjectType.AdrianMeteor)
        {
            GameManager3.instance.DamageHullPercent(0.20f);
        }

        Destroy(gameObject);
    }
}