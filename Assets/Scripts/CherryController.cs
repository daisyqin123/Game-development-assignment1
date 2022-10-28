﻿using UnityEngine;

public class CherryController : MonoBehaviour
{
    Tween tween;
    const float duration = 25f;
    Vector2 startPos, endPos;

    public GameObject cherryPrefab;
    private GameObject cherryInstance;
    void Start()
    {
        InvokeRepeating("startMovement", 30, 30); //do method every 30 seconds
        Camera camera = Camera.main;
    }

    void Update()
    {
        if (cherryInstance != null) //if currently moving across the screen continue that movement and stop it when it reaches endPos
        {
            //changePos();
            if (Vector2.Distance(new Vector2(cherryInstance.transform.position.x, cherryInstance.transform.position.y), tween.EndPos) < 0.05f)
            {
                Destroy(cherryInstance.gameObject);
            }
        }
    }

    void startMovement() //create the cherry to move across the screen
    {
        startPos = Camera.main.ViewportToWorldPoint(new Vector2(-15.1f, -13.5f)); //set the start and end points to be just outside the camera
        endPos = Camera.main.ViewportToWorldPoint(new Vector2(15.1f, .13f));
        cherryInstance = Instantiate(cherryPrefab, startPos, Quaternion.identity);//make the cherry
        tween = new Tween(startPos, endPos, Time.time, duration);
    }
   
}