using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    PlayerStats pStats;
    GameObject Point;
    Vector3 startPos;
    Vector3 pos;
     public float Speed;
    bool reached = false;
    // Use this for initialization
    void Start()
    {
        Point = transform.Find("Point").gameObject;
        startPos = transform.position;
        pos = Point.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Behaviour();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.collider.tag == "Player" ) pStats.shieldCount--;
    }
    void Behaviour()
    {
        // Vector3 pos = Point.transform.position;
        //transform.Rotate(pos, 5*Time.deltaTime, Space.World);
         
        float secondsForOneLength = 3;
        transform.position = Vector3.Lerp(startPos, pos,Mathf.SmoothStep(0f, 1f,Mathf.PingPong(Time.time / (1/Speed), 1f)));
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.Find("Point").position,Vector3.one/4);
    }
}