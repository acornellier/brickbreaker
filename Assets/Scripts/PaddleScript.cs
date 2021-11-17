using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float leftScreenEdge;
    [SerializeField]
    float rightSceenEdge;


    void Update()
    {
        transform.Translate(
            Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime * Vector2.right
        );

        if (transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector2(rightSceenEdge, transform.position.y);
        }
        else if (transform.position.x > rightSceenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }
    }
}
