using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumpers : MonoBehaviour {
    public TankMovement tM;
	// Use this for initialization
	void Start () {
        tM = transform.parent.GetComponent<TankMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        tM.Stop = true;
       
        Debug.Log("Collision"); 
    }
}
