using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               
using UnityEngine.SceneManagement;  



public class GameController : MonoBehaviour
{
    
    public static GameController instance;

  

   
    public Text timeCounter, countdownText;

    
    public bool gamePlaying { get;  set; }

    
    public int countdownTime;
    
   

    
    private float startTime, elapsedTime;

    
    TimeSpan timePlaying;

    
    private void Awake()
    {
        
        instance = this;
    }

   
    private void Start()
    {
        

       
        timeCounter.text = "Time: 00:00.00";

        
        gamePlaying = false;

        
        StartCoroutine(CountdownToStart());
    }

  
    private void BeginGame()
    {
        // Game is now playing and player can move around
        gamePlaying = true;
        
        // Sets the time the game began playing
        startTime = Time.time;
    }

   
    private void Update()
    {
      
        if (gamePlaying)
        {
            
            elapsedTime = Time.time - startTime;

            
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

           
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");

            
            timeCounter.text = timePlayingStr;
        }
    }

 
    IEnumerator CountdownToStart()
    {
        
        while (countdownTime > 0)
        {
           
            countdownText.text = countdownTime.ToString();

            
            yield return new WaitForSeconds(1f);

            
            countdownTime--;
        }

        
        BeginGame();

        //  "GO!"
        countdownText.text = "GO!";

        // exactly 1 second
        yield return new WaitForSeconds(1f);

        //  hid the "GO!" text
        countdownText.gameObject.SetActive(false);
    }



    


}
