using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public bool restrictX,restrictY;
    public GameObject Player;
    Vector3 offset;
	// Use this for initialization
	void Start () {
       
        Player = GameObject.Find("Player");
        if (!Player) Debug.Log("No player!!");
        else  offset = transform.position - Player.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Player) {
            if (restrictX) transform.position = new Vector3(transform.position.x, Player.transform.position.y + offset.y, Player.transform.position.z + offset.z);
            else if (restrictY) transform.position = new Vector3(Player.transform.position.x + offset.x, Player.transform.position.y + offset.y, transform.position.z);
            else transform.position = Player.transform.position + offset;
        }  
	}
}
