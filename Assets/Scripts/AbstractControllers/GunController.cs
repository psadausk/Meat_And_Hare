using UnityEngine;
using System.Collections;

public abstract class GunController : MonoBehaviour {

    public float FireRate;
    public GameObject Bullet;
    public float BulletIntialVelocity;
    public Transform BulletSpawn;

    private float m_nextFire;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

        //Rotate the gun
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if ( Input.GetButton("Fire1") && Time.time > this.m_nextFire ) {
			this.m_nextFire = Time.time + this.FireRate;
            this.Fire(dir);

		}               
	}

    public abstract void Fire(Vector2 dir);
}
