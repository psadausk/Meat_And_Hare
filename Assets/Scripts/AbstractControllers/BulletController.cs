using UnityEngine;
using System.Collections;

public abstract class BulletController : MonoBehaviour {

    public abstract float LifeTime { get; }

	// Use this for initialization
	void Start () {
        Destroy(gameObject, this.LifeTime);
	}
	
	// Update is called once per frame
	void Update () {        
	}

    protected abstract void OnCollisionEnter2D(Collision2D collision);
}
