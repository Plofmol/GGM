using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public OrbitScript orbitScript; // Reference to your OrbitScript

    public float launchForce = 10f; // Adjust the force as needed.
    private Rigidbody2D rb;

    public float reloadTime = 2.0f; // Time it takes to reload in seconds

    private bool isReloading = false;

    public int currentWeaponIndex = 0;

    public int[] weaponAmmo = new int[3];
    public int[] magSize = new int[3];
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponAmmo[0] = 10; // Initial shotgun ammo count
        weaponAmmo[1] = 6;  // Initial revolver ammo count
        weaponAmmo[2] = 1;  // Initial bazooka ammo count

        magSize[0] = 10; // Initial shotgun ammo count
        magSize[1] = 6;  // Initial revolver ammo count
        magSize[2] = 1;  // Initial bazooka ammo coun
    }

    // Update is called once per frame
    void Update()
    {
        currentWeaponIndex = orbitScript.currentSpriteIndex;

        if(GetAmmoRemaining(currentWeaponIndex) > 0 && !isReloading)
        {
            //Detect LMB click
            if(Input.GetMouseButtonDown(0))
            {
                WeaponAmmoMinus(currentWeaponIndex);
                switch (currentWeaponIndex)
                {
                    case 1:
                        ShotgunFire();
                        break;
                    case 2:
                        RevolverFire();
                        break;
                    case 3:
                        BazookaFire();
                        break;
                    default:
                        //Exception here
                        break; 
                }
                
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("CoRoutine started");

            StartCoroutine(Reload());
        }
    }

    void WeaponAmmoMinus(int WeaponIndex)
    {
        weaponAmmo[WeaponIndex-1] -= 1;
    }

    void ShotgunFire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 launchDirection = (transform.position - mousePosition).normalized;
        float angleInRadians = Mathf.Atan2(launchDirection.y, launchDirection.x);

        // Apply a force to the Rigidbody in the launchDirection.
        Vector2 launchAngle = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        rb.AddForce(launchAngle * launchForce, ForceMode2D.Impulse);

        // Print a message to the console.
        Debug.Log("Player launched in the opposite direction of the mouse.");
    }

    void RevolverFire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 launchDirection = (transform.position - mousePosition).normalized;
        float angleInRadians = Mathf.Atan2(launchDirection.y, launchDirection.x);

        // Apply a force to the Rigidbody in the launchDirection.
        Vector2 launchAngle = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        rb.AddForce(launchAngle * launchForce, ForceMode2D.Impulse);

        // Print a message to the console.
        Debug.Log("Player launched in the opposite direction of the mouse.");
    }

    void BazookaFire()
    {

    }

    int GetAmmoRemaining(int currentWeaponIndex)
    {
        return weaponAmmo[currentWeaponIndex-1];
    }

    IEnumerator Reload()
    {
        currentWeaponIndex = orbitScript.currentSpriteIndex;
        if (orbitScript != null)
        {
            // Assuming currentSpriteIndex ranges from 1 to 3
            
            switch (orbitScript.currentSpriteIndex)
            {
                case 1:
                    //Shotgun
                    reloadTime = 3f;
                    break;
                case 2:
                    //Revolver
                    reloadTime = 2f;
                    break;
                case 3:
                    //Bazooka
                    reloadTime = 5f;
                    break;
                default:
                    //Exception here
                    break;
            }
        }
        isReloading = true;

        // Optionally, you can add any animations or effects related to reloading here.

        yield return new WaitForSeconds(reloadTime);
        Debug.Log("wait done");
        weaponAmmo[currentWeaponIndex - 1] = magSize[currentWeaponIndex - 1];


        // Reset the firesRemaining and allow firing again.
        isReloading = false;
    }
}
