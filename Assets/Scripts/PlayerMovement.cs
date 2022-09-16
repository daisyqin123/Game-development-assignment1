using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animatorController;

    [SerializeField]
    private GameObject player;
    private PlayerTween activeTween;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AddPlayerTween();
        if (activeTween != null)
        {
            checkDirection(); // Controls animator

            // Cubic easing-in interpolation
            float time = (Time.time - activeTween.StartTime) / activeTween.Duration;
            float timeFraction = time * time * time;

            // Distance between current object's position and the EndPos not "StartPos"
            float dist = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);

            if (dist > 0.1f)
            {
                activeTween.Target.transform.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
            }
            if (dist < 0.1f)
            {         
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
            }

        }

        pos = player.transform.position; // Get position of player
    }

    public void AddPlayerTween()
    {
        if (activeTween == null)
        {
            if (pos.x == -9 && pos.y == 3) // Move Right
            {
                activeTween = new PlayerTween(player.transform, player.transform.position, new Vector3(-4.0f, 3.0f, 0.0f), Time.time, 1.5f);
            }
            if (pos.x == -4 && pos.y == 3) // Move Down
            {
                activeTween = new PlayerTween(player.transform, player.transform.position, new Vector3(-4.0f, -1.0f, 0.0f), Time.time, 1.5f);
            }

            if (pos.x == -4 && pos.y == -1) // Move Left
            {
                activeTween = new PlayerTween(player.transform, player.transform.position, new Vector3(-9.0f, -1.0f, 0.0f), Time.time, 1.5f);
            }

            if (pos.x == -9 && pos.y == -1) // Move Up
            {
                activeTween = new PlayerTween(player.transform, player.transform.position, new Vector3(-9.0f, 3.0f, 0.0f), Time.time, 1.5f);
            }

            
        }
    }

    public void checkDirection()
    {
        if (pos.y > activeTween.EndPos.y) // go down
        {
            animatorController.SetInteger("move", 0);
        }
        if (pos.x < activeTween.EndPos.x) // go right
        {
            animatorController.SetInteger("move", 3);
        }

        if (pos.x > activeTween.EndPos.x) //go  Left
        {
            animatorController.SetInteger("move", 1);
           // activeTween.Target.transform.localScale = new Vector3(-2.2f, 2.2f, 0);
        }

        if (pos.y < activeTween.EndPos.y) // go Up
        {
            animatorController.SetInteger("move", 2);
           // activeTween.Target.transform.localScale = new Vector3(2.2f, 2.2f, 0);
        }

        
    }

}

