using UnityEngine;
using System.Collections;
using Assets.Scripts.Common;

[RequireComponent(typeof(PlayerPhysics))]
[RequireComponent(typeof(GunController))]
public class PlayerController: MonoBehaviour {

    public float Speed = 8;
    public float Acceleration = 30;
    public float Gravity = 20;
    public float JumpHeight = 12;


    private float m_currentSpeed;
    private float m_targerSpeed;
    private Vector2 m_moveAmount;


    private PlayerPhysics m_playerPhysics;
    private GunController m_gunController;
    public GameObject Gun;    


    public void Start() {
        this.m_playerPhysics = this.GetComponent<PlayerPhysics>();
        this.m_gunController = this.GetComponent<GunController>();
    }


    void Update() {
        this.m_targerSpeed = Input.GetAxis("Horizontal") * this.Speed;
        this.m_currentSpeed = Utility.IncrementTowards(this.m_currentSpeed, this.m_targerSpeed, this.Acceleration);

        //Is on the ground
        if ( this.m_playerPhysics.Grounded ) {
            this.m_moveAmount.y = 0;

            // Jump
            if ( Input.GetButtonDown("Jump") ) {
                m_moveAmount.y = JumpHeight;
            }
        }

        //Is hitting a wall
        if ( this.m_playerPhysics.MovementStopped ) {
            this.m_targerSpeed = 0;
            this.m_currentSpeed = 0;
        }

        //Update movement
        this.m_moveAmount.x = this.m_currentSpeed;
        this.m_moveAmount.y -= this.Gravity * Time.deltaTime; ;
        this.m_playerPhysics.Move(this.m_moveAmount * Time.deltaTime);

        ////Fire gun
        

        //Have the gun look at the mouse
        
    }

    void FixedUpdate() {
        
    }


}
