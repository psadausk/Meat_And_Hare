using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    public float FireRate;
    public GameObject Bullet;
    public Transform BulletSpawn;


    private float m_nextFilre;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {    
		
		if ( Input.GetButton("Fire1") && Time.time > this.m_nextFilre ) {
			this.m_nextFilre = Time.time + this.FireRate;
			Instantiate(this.Bullet, this.BulletSpawn.position, this.BulletSpawn.rotation);
			this.audio.Play();
		}



        //Debug.Log(this.transform.position);
        ////var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //var mousePosition = Input.mousePosition;
        ////Vector3 worldPos = Camera.mainCamera.ScreenToWorldPoint(mousePosition)     ;
        //Debug.Log(mousePosition);
        //var theta = Mathf.Atan2(mousePosition.y, mousePosition.x) * 180f / Mathf.PI    ;
        //Debug.Log(theta);
        ////theta = Mathf.Clamp(theta, -35f, 90f);
        ////transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x)); 
        //transform.rotation = Quaternion.Euler(0, 0, theta);
        
	}

    public void Fire() {        
    }
}
