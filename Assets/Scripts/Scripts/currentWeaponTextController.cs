using UnityEngine;
using UnityEngine.UI;

public class WeaponText : MonoBehaviour
{
    public OrbitScript orbitScript; // Reference to your OrbitScript
    private Text weaponText; // Reference to the Text component

    private void Start()
    {
        weaponText = GetComponent<Text>(); // Get the Text component on this GameObject
        UpdateWeaponText(); // Update the text initially
    }

    private void Update()
    {
        UpdateWeaponText(); // Update the text continuously (you might want to optimize this)
    }

    void UpdateWeaponText()
    {
        // Check if the OrbitScript reference is set and the Text component exists
        if (orbitScript != null && weaponText != null)
        {
            // Assuming currentSpriteIndex ranges from 1 to 3
            switch (orbitScript.currentSpriteIndex)
            {
                case 1:
                    weaponText.text = "Shotgun"; // Customize the text as needed
                    break;
                case 2:
                    weaponText.text = "Revolver"; // Customize the text as needed
                    break;
                case 3:
                    weaponText.text = "Bazooka"; // Customize the text as needed
                    break;
                default:
                    weaponText.text = "Unknown Weapon"; // Handle other cases as needed
                    break;
            }
        }
    }
}
