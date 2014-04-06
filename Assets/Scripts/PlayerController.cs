using UnityEngine;
using System.Collections;
using Assets.Scripts.Common;

//[RequireComponent(typeof(PlayerPhysics))]
//[RequireComponent(typeof(GunController))]
public class PlayerController: MonoBehaviour {


    public float MoveForce = 5000f;
    public float JumpForce = .1f;
    public float MaxSpeed = 20f;
    public bool CanJump = true;
    public bool Jump = false;

    //private float m_currentSpeed;
    //private float m_targerSpeed;
    //private Vector2 m_moveAmount;


    private PlayerPhysics m_playerPhysics;
    private GunController m_gunController;
    public GameObject Gun;    


    public void Start() {
        //this.m_playerPhysics = this.GetComponent<PlayerPhysics>();
        //this.m_gunController = this.GetComponent<GunController>();
    }


    void Update() {
        if ( Input.GetButtonDown("Jump") && CanJump )
            Jump = true;
    }

    void FixedUpdate() {
        var x = Input.GetAxis("Horizontal");
        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        //if ( x * rigidbody2D.velocity.x < MaxSpeed )
            // ... add a force to the player.
        if(Input.GetAxis("Horizontal") !=  0 )
            rigidbody2D.AddForce(Vector2.right * Mathf.Sign(x) * MoveForce * Time.deltaTime);

        // If the player's horizontal velocity is greater than the maxSpeed...
        //if ( Mathf.Abs(rigidbody2D.velocity.x) > MaxSpeed )
        //    // ... set the player's velocity to the maxSpeed in the x axis.
        //    rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * MaxSpeed, rigidbody2D.velocity.y);


        if ( Jump ) {
            // Set the Jump animator trigger parameter.
            //anim.SetTrigger("Jump");

            //// Play a random jump audio clip.
            //int i = Random.Range(0, jumpClips.Length);
            //AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

            //// Add a vertical force to the player.
            rigidbody2D.AddForce(new Vector2(0f, JumpForce));

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            Jump = false;
        }
    }


}
