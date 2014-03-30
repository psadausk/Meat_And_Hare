using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

    public float Acceleration = 10;

    private Transform m_target;
    //public 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if ( this.m_target) {
            var x = IncrementTowards(transform.position.x, this.m_target.position.x, this.Acceleration);
            var y = IncrementTowards(transform.position.y, this.m_target.position.y, this.Acceleration);
            this.transform.position = new Vector3(x, y, transform.position.z);
        }
	}

    public void SetTarget(Transform t) {
        this.m_target = t;
    }

    private float IncrementTowards(float current, float target, float acceleration) {
        if ( current == target )
            return current;
        float dir = Mathf.Sign(target - current);
        current += acceleration * Time.deltaTime * dir;
        return ( dir == Mathf.Sign(target - current) ? current : target );
    }
}
