using UnityEngine;

public class ToughBrick : Brick
{
    public Sprite brokenSprite;

    int lives = 2;
    new SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        print("ToughBrick");
        if (!collision.transform.CompareTag("Ball"))
            return;

        lives -= 1;
        if (lives > 0)
        {
            renderer.sprite = brokenSprite;
            return;
        }

        Break();
    }
}
