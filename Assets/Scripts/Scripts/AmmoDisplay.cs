using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    private Text ammoText;
    public GunController gunController; // Reference to your GunController script

    private void Start()
    {
        ammoText = GetComponent<Text>();
        // Make sure the GunController and Text component are assigned
        if (ammoText == null)
        {
            Debug.LogError("Ammo Text is not assigned to AmmoDisplay script.");
            return;
        }

        if (gunController == null)
        {
            Debug.LogError("GunController is not assigned to AmmoDisplay script.");
            return;
        }
    }

    private void Update()
    {
        // Check if the GunController and Text component are assigned
        if (ammoText == null || gunController == null)
        {
            return;
        }

        // Update the text to display the remaining ammo

        //Get current weapon of the player
        int weaponIndex = gunController.currentWeaponIndex;
        ammoText.text = "Ammo: " + gunController.weaponAmmo[weaponIndex-1];
    }
}
