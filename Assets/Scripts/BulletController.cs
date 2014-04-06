using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float Speed = 20000f;
    public Quaternion Angle;
    public float LifeTime = 20;

    private Vector2 m_movement;

    public int NumberOfEmmisions = 20;
    public float BloodChance = .7f;
    public GameObject Blood;
    public GameObject Guts;

	// Use this for initialization
	void Start () {
        this.m_movement = new Vector2();
        this.rigidbody2D.AddForce(Vector2.right * this.Speed);
        Destroy(gameObject, this.LifeTime);
	}
	
	// Update is called once per frame
	void Update () {        
	}

    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);

        var impactVector = collision.relativeVelocity;
        for ( var i = 0; i < this.NumberOfEmmisions; i++ ) {
            var rand = Random.value;

            GameObject gibblet;
            if ( rand < this.BloodChance ) {
                gibblet = Instantiate(Blood, this.transform.position, Quaternion.identity) as GameObject;                
            } else {
                gibblet = Instantiate(Guts, this.transform.position, Quaternion.identity) as GameObject;
            }
            gibblet.rigidbody2D.AddForce(new Vector2(Random.Range(200, 1000), Random.Range(200, 1000)));
            gibblet.rigidbody2D.angularVelocity = Random.Range(2, 5);
        }

    }
}
