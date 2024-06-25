using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.Translate(Vector2.up * speed);
    }
}
