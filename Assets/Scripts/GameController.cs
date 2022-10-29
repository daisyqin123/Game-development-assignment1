using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               
using UnityEngine.SceneManagement;  



public class GameController : MonoBehaviour
{
    
    public static GameController instance;

  

    // Public Text components we set in the Unity Inspector
    public Text timeCounter, countdownText;

    // True if the game is playing, false if it is not
    // Returns false during countdown at beginning and after the last Demon is destroyed
    // Other classes can read this variable, but it can only be set within this class
    public bool gamePlaying { get; private set; }

    // Number of seconds to count down before starting the game
    public int countdownTime;

   

    // Time in seconds of when the game began and how long the game has been playing
    private float startTime, elapsedTime;

    // Amount of time the game has been playing. Can be formatted nicely
    TimeSpan timePlaying;

    /// <summary>
    /// Called before the start function when the scene is loaded
    /// </summary>
    private void Awake()
    {
        // Assigns this object to the public static instance (singleton)
        // See the MusicController.cs for a better implementation of a singleton
        instance = this;
    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        

        // Initialize the time counter UI
        timeCounter.text = "Time: 00:00.00";

        // Game is set to false until countdown completes
        gamePlaying = false;

        // Begins the countdown at the start of the game
        StartCoroutine(CountdownToStart());
    }

    /// <summary>
    /// Sets some variables at the start of the game
    /// </summary>
    private void BeginGame()
    {
        // Game is now playing and player can move around
        gamePlaying = true;
        //TimerController.instance.BeginTimer();
        // Sets the time the game began playing
        startTime = Time.time;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        // If the game is in a playing state ...
        if (gamePlaying)
        {
            // ... Calculate the time elapsed since the start of the game
            elapsedTime = Time.time - startTime;

            // Generate a TimeSpan from the number of seconds the game has been going on for
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            // Nicely formatted string of the time the game has been playing
            // Example format - Time: 01:23.45
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");

            // Sets the time counter UI to our nicely formatted string
            timeCounter.text = timePlayingStr;
        }
    }

 
    IEnumerator CountdownToStart()
    {
        // While the countdown time is greater than zero...
        while (countdownTime > 0)
        {
            // Set the countdown UI component to the current countdown time integer
            countdownText.text = countdownTime.ToString();

            // Return in exactly 1 second
            yield return new WaitForSeconds(1f);

            // Decrement the countdown time integer by 1
            countdownTime--;
        }

        // Once the countdown timer reaches 0, call the BeginGame() fucntion
        BeginGame();

        // Sets the countdown UI to "GO!"
        countdownText.text = "GO!";

        // Return in exactly 1 second
        yield return new WaitForSeconds(1f);

        // Disable the countdown UI to hid the "GO!" text
        countdownText.gameObject.SetActive(false);
    }

 
}
