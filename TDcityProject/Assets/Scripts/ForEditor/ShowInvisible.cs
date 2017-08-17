using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInvisible : MonoBehaviour {

	// Use this for initialization
	void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        GameObject[] invis = GameObject.FindGameObjectsWithTag("TankSpawn");
        foreach (GameObject obj in invis) Gizmos.DrawCube(obj.transform.position, Vector3.one / 4);
    }
}
