using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    public Transform towerPivot;
    public Transform Player;
    public Transform fPoint;
    public int bulletForce = 200;
    public float rotationOffset = 90;
    public float fireRate = 5f;
    public float Speed = 5;
    public float rotSpeed = 3;
    float timeToFire = 0;
   
    [SerializeField]
    private bool zMovement;

    public bool Armored = false;
    public bool Stop = false; 
    
    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player").transform;
        towerPivot = transform.Find("TowerPivot");
        fPoint = transform.Find("TowerPivot/FirePoint");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
      
        if(Player)Aim();
        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
        
       // if (!Stop && !Armored) Move();
        if (Armored) Defend();
    }

    void Aim()
    {       
        Vector3 difference = Player.transform.position - towerPivot.transform.position;
        difference.Normalize();     // normalizing the vector. Meaning that all the sum of the vector will be equal to 1

        float rotY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        towerPivot.transform.rotation = Quaternion.Euler(0, rotY + rotationOffset, 0);
        Debug.DrawRay(towerPivot.position, Player.transform.position ,Color.cyan);
        Debug.Log(towerPivot.position);
       
               
    }

    public void Defend()
    {
        Vector3 difference = new Vector3(Player.transform.position.x - transform.position.x, 0, Player.transform.position.z - transform.position.z).normalized;
     
        float ang = Vector3.Angle(transform.forward, difference);
        
        if (ang >= 95 || ang <= 85)
        {

            float deltaPos = 1;
            
            if (Vector3.Dot(transform.right, difference.normalized) > 0)
            {
               
                if (ang >= 95)
                {
                    transform.Rotate(new Vector3(0, deltaPos / Mathf.Abs(deltaPos) * rotSpeed * Time.deltaTime, 0), Space.World);
                    
                }
                else
                {
                    transform.Rotate(new Vector3(0, -deltaPos / Mathf.Abs(deltaPos) * rotSpeed * Time.deltaTime, 0), Space.World);
                    
                }
            }
            else
            {
                if (ang <= 85)
                {
                    transform.Rotate(new Vector3(0, deltaPos / Mathf.Abs(deltaPos) * rotSpeed * Time.deltaTime, 0), Space.World);
                    
                }
                else
                {
                    transform.Rotate(new Vector3(0, -deltaPos / Mathf.Abs(deltaPos) * rotSpeed * Time.deltaTime, 0), Space.World);
                    
                }
            }
        }
      
       /* Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
        Debug.DrawRay(transform.position, difference * 10, Color.green);
        Debug.DrawRay(transform.position, transform.right, Color.red);
        Debug.DrawRay(transform.position, -transform.right, Color.red);
        Debug.DrawRay(transform.position, difference, Color.blue);*/
    }



    void Shoot()
    {
        GameObject _Bullet = Instantiate(Resources.Load("EnemyProjectile", typeof(GameObject)), fPoint.position, Quaternion.identity) as GameObject;
        _Bullet.GetComponent<Rigidbody>().AddForce(towerPivot.transform.forward * bulletForce);
        Destroy(_Bullet, 3f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player") Destroy(gameObject);
    }
}
