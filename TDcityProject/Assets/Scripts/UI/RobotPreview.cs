using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPreview : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	void Spawn()
    {
        Debug.Log(PlayerStats.pStats.playerModel);
        GameObject clone = Instantiate(Resources.Load(PlayerStats.pStats.playerModel, typeof(GameObject)), transform.position, Quaternion.identity, transform) as GameObject;
        clone.name = "Model";
        
    }



}
