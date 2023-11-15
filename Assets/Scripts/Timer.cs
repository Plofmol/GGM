using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startTime = 240f; // Set the initial time in seconds
    private float currentTime;
    private bool timerActive = false;

    public Text timerText; // Reference to a UI text element to display the timer

    void Start()
    {
        currentTime = startTime;
        UpdateTimerText();
    }

    void Update()
    {
        //Debug.Log(timerActive);
        if (timerActive)
        {
            Debug.Log(currentTime);
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            if (currentTime <= 0f)
            {
                // Timer has reached zero, you can add any actions you want to perform here
                timerActive = false;
            }
        }
    }
    public void StartTimer()
    {
        timerActive = true;
    }


    void UpdateTimerText()
    {
        // Format the time as minutes:seconds
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");

        // Update the UI text
        timerText.text = minutes + ":" + seconds;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player has entered the trigger area, start the timer
            timerActive = true;
        }
    }
}
