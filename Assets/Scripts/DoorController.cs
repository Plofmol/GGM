using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform warpTarget; // The target door to warp to

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) // Check if the W key is pressed
        {
            Warp();
        }
    }

    public void Warp()
    {
        if (warpTarget != null) // Ensure there is a target door set
        {
            // Move the player to the warp target's position
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.position = warpTarget.position;
        }
    }
}
