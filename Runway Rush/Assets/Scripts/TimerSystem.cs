using UnityEngine;
using UnityEngine.UI;


public class TimerSystem : MonoBehaviour

{
    public float timer = 60f;
    public Text timerText;
    public bool isPaused = false; // Controls whether timer is paused

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {

            // Only run the timer if not paused
            if (Time.timeScale > 0f && timer > 0f)
            {
                timer -= Time.deltaTime;
                timerText.text = Mathf.Ceil(timer) + " seconds";
            }
            else if (timer <= 0f)
            {
                timer = 0f;
                timerText.text = "0 seconds";
                Debug.Log("Show’s Over!");
            }
        }

    }
    // Call this method when pause button is clicked
    public void PauseTimer()
    {
        isPaused = true;
    }

    // Call this method when continue button is clicked
    public void ResumeTimer()
    {
        isPaused = false;
    }

}
