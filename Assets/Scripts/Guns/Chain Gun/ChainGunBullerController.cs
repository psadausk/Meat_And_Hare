using UnityEngine;
using System.Collections;

public class ChainGunBullerController : BulletController {

    public override float LifeTime { get { return 20000f; } }

	public int NumberOfEmmisions = 20;
    public float BloodChance = .7f;
    public GameObject Blood;
    public GameObject Guts;

	// Use this for initialization
	void Start () {
        //this.rigidbody2D.AddForce(Vector2.right * this.Speed);
        Destroy(gameObject, this.LifeTime);
	}
	
	// Update is called once per frame
	void Update () {        
	}

    protected override void OnCollisionEnter2D(Collision2D collision) {
        if ( collision.gameObject.GetComponent<BulletController>() != null ) {
            return;
        }

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
            gibblet.rigidbody2D.AddForce(new Vector2(Random.Range(20, 100), Random.Range(20, 100)));
            gibblet.rigidbody2D.angularVelocity = Random.Range(2, 5);
        }
    }
}
