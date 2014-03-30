using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float Speed;
    public Quaternion Angle;
    public float LifeTime = 20;

    private Vector2 m_movement;

	// Use this for initialization
	void Start () {
        this.m_movement = new Vector2();
        Destroy(gameObject, this.LifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Speed * Time.deltaTime, 0, 0);
	}
}
