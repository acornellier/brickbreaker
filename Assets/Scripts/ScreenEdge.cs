using UnityEngine;

public class ScreenEdge : MonoBehaviour
{
    public float topOffset;

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
        Vector2 topLeft = cam.ScreenToWorldPoint(
            new Vector3(topOffset, cam.pixelHeight, cam.nearClipPlane)
        );
        Vector2 topRight = cam.ScreenToWorldPoint(
            new Vector3(cam.pixelWidth - topOffset, cam.pixelHeight, cam.nearClipPlane)
        );
        Vector2 bottomRight = cam.ScreenToWorldPoint(
            new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)
        );

        // add or use existing EdgeCollider2D
        var edge =
            GetComponent<EdgeCollider2D>() == null
                ? gameObject.AddComponent<EdgeCollider2D>()
                : GetComponent<EdgeCollider2D>();

        var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight };
        edge.points = edgePoints;
    }
}
