using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
        }
    }
}
