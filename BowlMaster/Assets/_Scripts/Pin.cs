using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private AudioSource myAudioSource;

	// Use this for initialization
	void Start ()
	{
	    myAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;

        if (obj.GetComponent<Pin>() || obj.GetComponent<Ball>())
        {
            myAudioSource.Play();
        }
    }
}
