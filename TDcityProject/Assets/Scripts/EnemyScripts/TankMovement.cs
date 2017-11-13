using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {


    public bool Armored = false;
    public bool Stop = false;
    [SerializeField]
    private bool zMovement;
    public bool rotFineshed = true;
    public GameObject Player;
    public Vector3 bumPoint;
    public float rotOffset = 90;
    public float Speed = 5;
    public  float rotSpeed = 3;
    LevelManager lM;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        lM= GameObject.Find("CameraHolder").GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!Stop && !Armored)  Move();
        if (Armored) Defend();
	}

    void Move()
    {       
        transform.Translate(GetDirection() * Speed * Time.deltaTime,Space.Self);           
    }

    public void Defend()
    {
        Vector3 difference = new Vector3(Player.transform.position.x - transform.position.x, 0, Player.transform.position.z - transform.position.z);
        Debug.Log(Vector3.Angle(transform.right, difference));
        float deltaPos = Player.transform.position.x - transform.position.x;
        float ang = Vector3.Angle(transform.forward, difference);
        if (ang >= 90 || ang <= 85)
        {
           
        }
      //  Debug.Log(ang);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
        Debug.DrawRay(transform.position, difference * 10, Color.green);
    }
    public Vector3 GetDirection()
    {
        Vector3 pP, tP; 
        pP = Player.transform.position; tP = transform.position;

        if (pP.x > tP.x && !zMovement) return transform.rotation * new Vector3(1, 0, 0);
        else if (pP.x < tP.x && !zMovement) return transform.rotation * new Vector3(-1, 0, 0);
        else if (pP.z > tP.z && zMovement) return transform.rotation * new Vector3(0, 0, -1);
        else if (pP.z < tP.z && zMovement) return transform.rotation * new Vector3(0, 0, 1);
        else return Vector3.zero;                
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            lM.EnemyCount--; 
            if (lM.EnemyCount == 0) lM.EndTheGame(); 
           
            
            //Special effect code
        }

    }
}
