using UnityEngine;
using UnityEngine.InputSystem; // 1. Added the new Input System namespace

public class CameraMouseLook : MonoBehaviour
{
    public Transform player;         
    public Vector3 offset = new Vector3(0f, 3f, -6f); 
    public float sensitivity = 0.1f;   // Adjusted for the new input system's coordinate scale

    private float currentX = 0f;     
    private float currentY = 0f;     

    private const float Y_MIN = -20f; 
    private const float Y_MAX = 50f;  

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 2. Read mouse delta directly from the new Input System API
        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            currentX += mouseDelta.x * sensitivity;
            currentY -= mouseDelta.y * sensitivity; 

            currentY = Mathf.Clamp(currentY, Y_MIN, Y_MAX);
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = player.position + (rotation * offset);
        transform.LookAt(player.position + Vector3.up * 1.5f); 
    }
}
