using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float rotationSpeed = 90;
    public float rotationOffset = 90;
    
    float Speed;
    
    // Use this for initialization
    void Start()
    {
        
        Speed = PlayerStats.pStats.Speed;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Aim();
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical")!=0 ) Move();
    }
    void Move()
    {        
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
        transform.Translate(dir * Time.deltaTime * Speed,Space.World);
        
    }
    void Aim()
    {  
        transform.Rotate(0, Input.GetAxis("Mouse X")*rotationSpeed *Time.deltaTime, 0,Space.Self);
    }

}   
