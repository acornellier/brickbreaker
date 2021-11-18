using UnityEngine;

public class DeathEdge : MonoBehaviour
{
    void Awake()
    {
        AddCollider();
    }

    void AddCollider()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Camera.main not found, failed to create edge colliders");
            return;
        }

        var cam = Camera.main;
        if (!cam.orthographic)
        {
            Debug.LogError("Camera.main is not Orthographic, failed to create edge colliders");
            return;
        }

        Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector2 bottomRight = cam.ScreenToWorldPoint(
            new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)
        );

        // add or use existing EdgeCollider2D
        var edge =
            GetComponent<EdgeCollider2D>() == null
                ? gameObject.AddComponent<EdgeCollider2D>()
                : GetComponent<EdgeCollider2D>();

        var edgePoints = new[] { bottomLeft, bottomRight };
        edge.points = edgePoints;
        edge.isTrigger = true;
    }
}
