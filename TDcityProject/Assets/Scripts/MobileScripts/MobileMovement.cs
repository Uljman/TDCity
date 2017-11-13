using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MobileMovement : MonoBehaviour {

    public GameObject Player; 
    public float rotationOffset = 90;
    // bool State = false;
    public GameObject movementButon;
    public GameObject rotationButon;
    int State = 0;
    int RotState = 0;
    void Start()
    {
        Player = GameObject.Find("Player");
        
        movementButon = GameObject.Find("UI/MovementButton");
        rotationButon = GameObject.Find("UI/RotationButton");
    }
    void FixedUpdate()
    {

        if (State == 1 ) Move();
        if (RotState == 1) Rotate();
    }

	public void Move()
    {
        Vector2 touchCoords = Vector2.zero;
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchCoords = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began)
        {
            touchCoords = Input.GetTouch(1).position;
        }
        touchCoords = Input.GetTouch(0).position;
            Vector2 direction = touchCoords- (Vector2)movementButon.transform.position;
            
            direction.Normalize();
            Player.transform.Translate(new Vector3(direction.x, 0, direction.y) * PlayerStats.pStats.Speed * Time.deltaTime, Space.World);
           

        
    }

    public void Rotate()
    {
        
        Vector2 direction = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal_2"), CrossPlatformInputManager.GetAxis("Vertical_2"));

        //direction.Normalize();
        Debug.Log(direction);
      float rotY = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
      Debug.Log(rotY);
           
      Player.transform.rotation = Quaternion.Euler(0, rotY, 0);
        
    }
    public void SetRotationState(int _State)
    {
        RotState = _State;

    }

    public void SetState(int _State)
    {
        State = _State;
        
    }
}
