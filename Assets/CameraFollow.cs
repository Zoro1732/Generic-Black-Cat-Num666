using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;     // Drag your player here
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Camera distance from player
    public float smoothSpeed = 5f; // Higher values make the camera snap faster

    // LateUpdate runs after all standard Update functions, preventing camera jitter
    void LateUpdate()
    {
        if (target == null) return;

        // Calculate the desired position based on target and offset
        Vector3 desiredPosition = target.position + offset;
        
        // Smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        // Apply the position
        transform.position = smoothedPosition;

        // Optional: Force the camera to always look at the player
        transform.LookAt(target);
    }
}
