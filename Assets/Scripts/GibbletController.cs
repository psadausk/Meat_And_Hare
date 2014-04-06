
using UnityEngine;
using System.Collections;

public class GibbletController : MonoBehaviour {
	public float LifeTime = 1;
	
	// Use this for initialization
	void Start() {
		Destroy(gameObject, this.LifeTime); 
	}

	// Update is called once per frame
	void Update (){

	}
}