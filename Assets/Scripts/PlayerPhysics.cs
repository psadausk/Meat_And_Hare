using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {

    public LayerMask CollisionMask;

    [HideInInspector]
    public bool Grounded;
    
    [HideInInspector]
    public bool MovementStopped;

    private BoxCollider m_collider;
    private Vector3 m_size;
    private Vector3 m_center;

    private float m_skin = .005f;

    public void Start() {
        this.m_collider = this.GetComponent<BoxCollider>();
        this.m_size = this.m_collider.size;
        this.m_center = this.m_collider.center;

    }

    public void Move(Vector2 moveAmount) {

        RaycastHit hit;

        var deltaY = moveAmount.y;
        var deltaX = moveAmount.x;
        var position = transform.position;

        this.Grounded = false;

        for ( var i = 0; i < 3; i++ ) {
            var dir = Mathf.Sign(deltaY);
            var x = ( position.x + this.m_center.x - this.m_size.x / 2 ) + this.m_size.x / 2 * i;
            var y = position.y + this.m_center.y + this.m_size.y / 2 * dir;

            var ray = new Ray(new Vector2(x, y), new Vector2(0, dir));
            Debug.DrawRay(ray.origin, ray.direction);
            if ( Physics.Raycast(ray, out hit, Mathf.Abs(deltaY) + this.m_skin, this.CollisionMask) ) {
                var distance = Vector3.Distance(ray.origin, hit.point);
                if ( distance > this.m_skin ) {
                    deltaY = distance * dir - this.m_skin * dir;
                } else {
                    deltaY = 0;
                }
                this.Grounded = true;
                break;
            }
        }

        MovementStopped = false;
        for ( var i = 0; i < 3; i++ ) {
            var dir = Mathf.Sign(deltaX);
            var x = position.x + this.m_center.x + this.m_size.x / 2 * dir;
            var y = (position.y + this.m_center.y - this.m_size.y / 2) + this.m_size.y / 2 * i  ;

            var ray = new Ray(new Vector2(x, y), new Vector2(dir, 0));
            Debug.DrawRay(ray.origin, ray.direction);
            if ( Physics.Raycast(ray, out hit, Mathf.Abs(deltaX) + this.m_skin, this.CollisionMask) ) {
                var distance = Vector3.Distance(ray.origin, hit.point);
                if ( distance > this.m_skin ) {
                    deltaX = distance * dir - this.m_skin * dir;
                } else {
                    deltaX = 0;
                }
                this.MovementStopped = true;
                break;
            }
        }

        if ( !this.Grounded && !this.MovementStopped ) {
            var playerDirection = new Vector3(deltaX, deltaY);
            var origin = new Vector3(
                position.x + this.m_center.x + this.m_size.x / 2 * Mathf.Sign(deltaX),
                position.y + this.m_center.y + this.m_size.y / 2 * Mathf.Sign(deltaY));
            var ray2 = new Ray(origin, playerDirection.normalized);

            if ( Physics.Raycast(ray2, Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY), this.CollisionMask) ) {
                this.Grounded = true;
                deltaY = 0;
            }
        }


        var actaulMove = new Vector2(deltaX, deltaY);


        this.transform.Translate(actaulMove);
    }
}

