using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform.
    public Sprite sprite1;  // Reference to the first sprite image (assign in the Inspector).
    public Sprite sprite2;  // Reference to the second sprite image (assign in the Inspector).
    public Sprite sprite3;  // Reference to the third sprite image (assign in the Inspector).

    private SpriteRenderer spriteRenderer;  // Reference to the sprite renderer component.
    public int currentSpriteIndex = 1;  // Variable to track the currently displayed sprite.

    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject.
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    void Update()
    {
        // Get the mouse position in world coordinates.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;  // Ensure the Z-axis is at 0 (2D space).

        // Calculate the direction from the player to the mouse.
        Vector3 directionToMouse = mousePosition - player.position;

        // Calculate the angle between the player's right direction and the direction to the mouse.
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

        // Set the sprite's rotation to face the mouse direction.
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Manually adjust the sprite's position (you can use any desired method).
        // For example, to make the sprite orbit at a fixed radius:
        float orbitRadius = 1.0f;  // Adjust this value to set the orbit radius.
        transform.position = player.position + Quaternion.Euler(0, 0, angle) * Vector3.right * orbitRadius;

        // Check for number key presses to change the sprite.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSpriteIndex = 1;
            UpdateSprite();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSpriteIndex = 2;
            UpdateSprite();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSpriteIndex = 3;
            UpdateSprite();
        }
    }

    void UpdateSprite()
    {
        // Update the sprite based on the current sprite index.
        switch (currentSpriteIndex)
        {
            case 1:
                spriteRenderer.sprite = sprite1;
                break;
            case 2:
                spriteRenderer.sprite = sprite2;
                break;
            case 3:
                spriteRenderer.sprite = sprite3;
                break;
        }
    }
}
