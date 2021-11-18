using UnityEngine;

public class Brick : MonoBehaviour
{
    public Transform brickExplosion;
    public Transform star;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        print("Brick");
        if (!collision.transform.CompareTag("Ball"))
            return;

        Break();
    }

    protected void Break()
    {
        print("Break");
        var explosion = Instantiate(brickExplosion, transform.position, transform.rotation);
        Destroy(explosion.gameObject, 2.5f);

        if (Random.value > 0.25)
        {
            Instantiate(star, transform.position, transform.rotation);
        }

        GameManager.Instance.OnBrickDestroy();
        Destroy(gameObject);
    }
}
