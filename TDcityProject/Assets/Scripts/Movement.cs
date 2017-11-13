using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    public float rotationSpeed = 90;
    public float rotationOffset = 90;
    public bool mobile = true;
    public bool restrictX, restrictY;
    float Speed;
    Vector3 offset;
    GameObject Cam;
    // Use this for initialization
    void Start()
    {
        
        Speed = PlayerStats.pStats.Speed;
        Cam = GameObject.Find("CameraHolder");
        offset = Cam.transform.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Rotate();
    }
    void LateUpdate()
    {
        CameraFollow();
    }
    void Move()
    {        
        if(!mobile)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                transform.Translate(dir * Time.deltaTime * Speed, Space.World);
            }
        }
        else
        {
            Vector3 dir = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical"));
            transform.Translate(dir * Time.deltaTime * Speed, Space.World);
        }
             
    }

    public void Rotate()
    {
        Vector2 direction = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal_2"), CrossPlatformInputManager.GetAxis("Vertical_2"));
        //direction.Normalize();
        Debug.Log(direction);
        float rotY = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Debug.Log(rotY);
        if (direction != Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(0, rotY, 0);
        }
    }

    void Aim()
    {  
        transform.Rotate(0, Input.GetAxis("Mouse X")*rotationSpeed *Time.deltaTime, 0,Space.Self);
    }

    void CameraFollow()
    {
              
        if (restrictX) Cam.transform.position = new Vector3(transform.position.x,transform.position.y + offset.y, transform.position.z + offset.z);
        else if (restrictY) Cam.transform.position = new Vector3(transform.position.x + offset.x,transform.position.y + offset.y, transform.position.z);
        else Cam.transform.position = transform.position + offset;

    }
}   
