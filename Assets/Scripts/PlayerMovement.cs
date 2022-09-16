using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animatorController;

    [SerializeField]
    private GameObject player;
    private PlayerTween activePlayerTween;
    private Vector3 p;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
            if (activePlayerTween == null)
            {
            // go Right
            if (p.x == -9 && p.y == 3) 
                {
                activePlayerTween = new PlayerTween(player.transform, player.transform.position, new Vector3(-4.0f, 3.0f, 0.0f), Time.time, 1.5f);
                }
            // go Down
            if (p.x == -4 && p.y == 3) 
                {
                activePlayerTween = new PlayerTween(player.transform, player.transform.position, new Vector3(-4.0f, -1.0f, 0.0f), Time.time, 1.5f);
                }
            // go Left
            if (p.x == -4 && p.y == -1) 
                {
                activePlayerTween = new PlayerTween(player.transform, player.transform.position, new Vector3(-9.0f, -1.0f, 0.0f), Time.time, 1.5f);
                }
            // go Up
            if (p.x == -9 && p.y == -1)
                {
                activePlayerTween = new PlayerTween(player.transform, player.transform.position, new Vector3(-9.0f, 3.0f, 0.0f), Time.time, 1.5f);
                }


            }
        
        if (activePlayerTween != null)
        {
           // Controls UI animator
            dicideAnimation(); 

            // interpolation
            float time = (Time.time - activePlayerTween.StartTime) / activePlayerTween.Duration;
            float timeF = time * time * time;

            // Distance ( current object's -EndPos)
            float distance = Vector3.Distance(activePlayerTween.Target.position, activePlayerTween.EndPos);

            if (distance > 0.1f)
            {
                activePlayerTween.Target.transform.position = Vector3.Lerp(activePlayerTween.StartPos, activePlayerTween.EndPos, timeF);
            }
            if (distance < 0.1f)
            {
                activePlayerTween.Target.position = activePlayerTween.EndPos;
                activePlayerTween = null;
            }

        }
        //the position of player
        p = player.transform.position; 
    }

   

    public void dicideAnimation()
    {
        // go down
        if (p.y > activePlayerTween.EndPos.y) 
        {
            animatorController.SetInteger("move", 0);
        }
        // go right
        if (p.x < activePlayerTween.EndPos.x)
        {
            animatorController.SetInteger("move", 3);
        }
        //go  Left
        if (p.x > activePlayerTween.EndPos.x)
        {
            animatorController.SetInteger("move", 1);
        
        }
        // go Up
        if (p.y < activePlayerTween.EndPos.y) 
        {
            animatorController.SetInteger("move", 2);
           
        }

        
    }

}

