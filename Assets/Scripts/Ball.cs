using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public Transform paddleBallPosition;
    public Transform brickExplosion;

    public static event System.Action OnBrickDestroy;
    public static event System.Action OnDeath;

    Rigidbody2D body;

    bool inPlay;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.Instance.gameOver)
            return;

        if (!inPlay)
        {
            transform.position = paddleBallPosition.position;

            if (Input.GetButtonDown("Jump"))
            {
                body.AddForce(Vector2.up * 500);
                inPlay = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Brick"))
        {
            var explosion = Instantiate(
                brickExplosion,
                collision.transform.position,
                collision.transform.rotation
            );
            Destroy(explosion.gameObject, 2.5f);
            GameManager.Instance.OnBrickDestroy();
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("DeathZone"))
        {
            body.velocity = Vector2.zero;
            GameManager.Instance.OnDeath();
            inPlay = false;
        }
    }
}
