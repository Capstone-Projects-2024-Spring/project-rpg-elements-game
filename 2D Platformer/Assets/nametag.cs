using UnityEngine;

public class NameTagController : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public Transform thisTransform;
    public Vector3 offset = new Vector3(0f, 0f, 0f); // Offset to position the name tag above the player

    void Update()
    {
        // Ensure the player transform is valid
        if (playerTransform != null)
        {
            // Update the position of the name tag relative to the player's position
            transform.position = playerTransform.position + offset;
            thisTransform.localScale = new Vector3(playerTransform.localScale.x, thisTransform.localScale.y, thisTransform.localScale.z);
        }
    }
}