using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PaddleScript : MonoBehaviour
{
    public float speed;
    public new SpriteRenderer renderer;

    float halfScreenWidth;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        var cam = Camera.main;
        halfScreenWidth =
            cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane)).x;
    }

    void Update()
    {
        transform.Translate(
            Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime * Vector2.right
        );
    }

    void LateUpdate()
    {
        var edge = halfScreenWidth - renderer.bounds.size.x / 2;
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -edge, edge),
            transform.position.y
        );
    }
}
