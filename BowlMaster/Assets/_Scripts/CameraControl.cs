using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float cameraZStop = 1700f;
    private Vector3 offset;
    private Ball ball;

    // Use this for initialization
    void Start ()
	{
	    //ball = GameObject.Find("Ball");
	    ball = GameObject.FindObjectOfType<Ball>();
	    if (!ball)
	    {
	        Debug.LogError("No ball");
	    }

	    offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
        //camera should follow ball until almost at the pins, then stop
	    if (transform.position.z <= cameraZStop)
	    {
	        transform.position = ball.transform.position + offset;
	    }
	}
}
