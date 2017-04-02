using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 launchVelocity;

    private AudioSource mySound;
    private Rigidbody myBody;
    private Transform ballStart;
    private bool ballIsRolling;
    //private GameObject myLane;
    private Bounds laneBounds;
    private Vector3 ballSize;

    // Use this for initialization
    void Start () {

        mySound = GetComponent<AudioSource>();
	    myBody = GetComponent<Rigidbody>();
	    myBody.useGravity = false;
	    ballStart = myBody.transform;
        laneBounds = GameObject.Find("Lane").GetComponent<MeshRenderer>().bounds;
        ballSize = GetComponent<MeshRenderer>().bounds.extents;
        //        myLane=GameObject.FindGameObjectWithTag("Lane");
    }

    public void Launch(Vector3 velocity)
    {
        //check if ball is already in motion - don't want to let them correct the course by clicking again after they've thrown it!
        if (!ballIsRolling)
        {
            myBody.velocity = velocity;
            myBody.useGravity = true;
            ballIsRolling = true;
        }
        //mySound.Play();  //removed, sound will start when ball hits the floor, see on collision enter method below //put back in again as I don't like the affect! might need to change it so different sound effects depending on how it's triggered eg just dropped vs thrown by this method
    }

    public void MoveStart(float xMove)
    {
        if (!ballIsRolling)
        {
            Vector3 newPos = myBody.transform.position;
            //myLane.transform.
            float halfBallWidth = (ballSize.x / 2) + 1; //ballsize.x = full width of ball. get half of it, then add 5 because we don't want it to actually stop right on the edge
            newPos.x = Mathf.Clamp(newPos.x+= xMove, laneBounds.min.x + halfBallWidth, laneBounds.max.x - halfBallWidth);
            myBody.transform.position = newPos;
            
            /*
            var ballPos = myBody.transform.position;
            var newBallPosX = Mathf.Clamp(ballPos.x + xMove, laneBounds.min.x + ballSize.x, laneBounds.max.x - ballSize.x);
            myBody.transform.position = new Vector3(newBallPosX, ballPos.y, ballPos.z);*/
        }
    }

    //TODO - might need to change it so different sound effects depending on how it's triggered eg just dropped vs thrown by this method, as currently this triggers if dropped but gives the rolling affect
        private void OnCollisionEnter(Collision collision)
        {
            //Debug.Log("1");
            if (collision.collider.gameObject.tag == "Lane")
            {
                //Debug.Log("2");
                mySound.Play();
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.gameObject.tag == "Lane")
            {
                mySound.Stop();
                //restart ball location if off lane
                //myBody.transform.position = ballStart.position;
                //myBody.useGravity = false;
            }
        }
    
}
