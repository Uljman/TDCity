using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploaderBehaviour : MonoBehaviour {


    public Transform target;
    public float speed = 2;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Move();
    }

   void Move()
   {
        Vector3 dir = new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z);
        dir.Normalize();
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
           
        if (collision.collider.tag == "Player")
        {
           
            GameObject _Particle = Instantiate(Resources.Load("Nova", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
            _Particle.transform.Rotate(90,0,0);
            Destroy(gameObject);
            Destroy(_Particle, 2f);
        }
    }
}
