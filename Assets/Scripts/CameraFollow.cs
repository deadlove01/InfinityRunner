using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float distanceDamping = 1f;
    public Transform target;

    
    public Vector3 offset;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
	    if (target == null)
	        return;

	    var newPos = target.position - offset;
	    transform.position = Vector3.Lerp(transform.position, newPos, distanceDamping);
        

	}
}
