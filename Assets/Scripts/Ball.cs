using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public Transform paddleBallPosition;

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
