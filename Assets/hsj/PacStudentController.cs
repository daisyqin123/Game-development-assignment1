﻿using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    Tween tween;
    const float duration = .7f;
    public Animator animator;
    public LayerMask ignorePellet;
    public ParticleSystem wallPartical, deathPartical;
    Vector2 wallHitPoint, startPos;
    public float leftTeloPoint, rightTeloPoint;
    char lastInput = 'A', currentInput = 'A';
    bool trailStarted = false;
    public void initilize()
    {
        animator = GetComponent<Animator>();
        startPos = transform.position;
    }
    public void setStartPos()
    {
        transform.position = new Vector2(1, 1);
    }
    public void pause()
    {
        animator.speed = 0; //basically pause here

    }


    void Update()
    {
        determineKey();
        if (tween != null) //if close enough to the end postion determine the next one else continue to the end position
        {
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), tween.EndPos) < 0.05f)
                getNextPos();
            else
                changePos();
        }
    }

    void determineKey()//get and save the last key that the player has pressed
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = 'A';
            if (currentInput.Equals(null)) //if just starting and input only just choosen
                currentInput = 'A';
            if (tween == null)
                getNextPos();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = 'W';
            if (currentInput.Equals(null))
                currentInput = 'W';
            if (tween == null)
                getNextPos();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = 'S';
            if (currentInput.Equals(null))
                currentInput = 'S';
            if (tween == null)
                getNextPos();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = 'D';
            if (currentInput.Equals(null))
                currentInput = 'D';
            if (tween == null)
                getNextPos();
        }

    }

    void getNextPos()//only do if first a valid key has been pressed
    {
        if (tween != null)
            transform.position = tween.EndPos; //ensures player at final position before moving to a new one
        teleport();
        int startI = Mathf.RoundToInt(transform.position.x), startJ = Mathf.RoundToInt(transform.position.y); //get player current position as an int
        Vector2 nextPos = setNextPos(startI, startJ, lastInput);
        if (lastInput != currentInput) //only nessesary do if the direction is actually changing
        {
            if (!nextPosWall(nextPos)) //allow changing direction if the nextPos is not a wall
            {
                animator.SetTrigger("" + lastInput);
                currentInput = lastInput;
            }
            else //continue to move in same direction otherwise
            {
                nextPos = setNextPos(startI, startJ, currentInput);
            }
        }
        if (!nextPosWall(nextPos)) //if no wall found at nextPos allow movement to that position(done if the direction couldn't change and checks if current direction wall)
        {
            tween = new Tween(transform.position, nextPos, Time.time, duration);
            if (!trailStarted)
            {
                trailStarted = true;

            }
            //do the trail start thing
            if (animator.speed == 0) //continue if it was previouly stopped
            {
                animator.speed = 1;

            }
        }
        else if (animator.speed == 1) //only do if in last frame was moving //if nextPos is a wall then stop the player, change audio and play wall particals
        {
            Debug.Log("撞墙特效");

            //wallPartical.transform.position = wallHitPoint;
            //wallPartical.GetComponent<ParticleSystem>().Play();
            pause();
        }
    }

    bool nextPosWall(Vector2 nextPos) //checks if the next position the player is moving too is a wall
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, nextPos - new Vector2(transform.position.x, transform.position.y), 1, ignorePellet);
        if (hit)
            wallHitPoint = hit.point; //get the point that the collision occured with the wall
        return hit;
    }

    Vector2 setNextPos(int startI, int startJ, char input) //determine the next position the player will be moved too based on the input key given
    {
        switch (input)
        {
            case 'A': return new Vector2(startI - 1, startJ);
            case 'S': return new Vector2(startI, startJ - 1);
            case 'W': return new Vector2(startI, startJ + 1);
            default: return new Vector2(startI + 1, startJ);
        }
    }

    void teleport() //when at portal pos move pacStudent to other side of map
    {
        if (transform.position.x <= leftTeloPoint)
        {
            Vector2 pos = transform.position;
            pos.x = rightTeloPoint;
            transform.position = pos;
        }
        else if (transform.position.x >= rightTeloPoint)
        {
            Vector2 pos = transform.position;
            pos.x = leftTeloPoint;
            transform.position = pos;
        }
    }

    void changePos() //move the player to the specified location
    {

        float timeFraction = (Time.time - tween.StartTime) / tween.Duration;
        transform.position = Vector2.Lerp(tween.StartPos, tween.EndPos, timeFraction);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("5"))
        {
            Destroy(collision.gameObject);

        }
        if (collision.CompareTag("6"))
        {
            Destroy(collision.gameObject);
        }
    }
}