using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ThrowForce = 50;

    private AudioSource mySound;
    private bool ballIsRolling;
    private Rigidbody myBody;

	// Use this for initialization
	void Start () {
        mySound = GetComponent<AudioSource>();
	    myBody = GetComponent<Rigidbody>();
	    ballIsRolling = false;
	}
	
	// Update is called once per frame
	void Update () {
        /*
	    if (ballIsRolling)
	    {
	        MoveBall();
	    } else if (Input.GetMouseButtonDown(0)) //ball is not rolling, so see if they have clicked to roll it
        {
            RollBall();
        }
        */

	    if (!ballIsRolling)
	    {
	        RollBall();
	    }
    }

    private void MoveBall()
    {
        //throw new NotImplementedException();
    }


    public void RollBall()
    {
        myBody.AddForce(transform.forward*ThrowForce,ForceMode.Impulse);
        mySound.Play();  //removed, sound will start when ball hits the floor, see on collision enter method below //put back in again as I don't like the affect! might need to change it so different sound effects depending on how it's triggered eg just dropped vs thrown by this method
        ballIsRolling = true;
    }
    /*
    //TODO - might need to change it so different sound effects depending on how it's triggered eg just dropped vs thrown by this method, as currently this triggers if dropped but gives the rolling affect
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("1");
            if (collision.collider.gameObject.tag == "Lane")
            {
                Debug.Log("2");
                mySound.Play();
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.gameObject.tag == "Lane")
            {
                mySound.Stop();
            }
        }
    */
}
