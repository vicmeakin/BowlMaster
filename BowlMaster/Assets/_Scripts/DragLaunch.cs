using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Ball myBall;        //the ball component we're manipulating
    private float startTime;    //the time at the start of the launch click
    private Vector3 startPos;   //the position at the start of the launch click

	// Use this for initialization
	void Start ()
	{
	    myBall = GetComponent<Ball>();
	}

    public void DragStart()
    {
        //capture time and position of drag start
        startTime = Time.time;
        startPos = Input.mousePosition;
    }

    public void DragEnd()
    {
        //capture end time and pos and launch ball
        float endTime = Time.time;
        Vector3 endPos = Input.mousePosition;
        float dragTime = endTime - startTime;

        /*Vector3 dragPos = endPos - startPos;

        dragPos.y /= 50;
        dragPos.z = dragTime*500f;

        Debug.Log(dragPos);
        myBall.Launch(dragPos);*/

        //need to convert y coord to z coord

        Vector3 launchVector = new Vector3((endPos.x - startPos.x),0f,(endPos.y - startPos.y) / dragTime);
        myBall.Launch(launchVector);
    }
}
