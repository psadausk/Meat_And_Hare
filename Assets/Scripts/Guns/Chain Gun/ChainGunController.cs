using UnityEngine;
using System.Collections;

public class ChainGunController : GunController {

    private float m_nextFilre;

    // Use this for initialization
    void Start() {
    }


    public override void Fire(Vector2 dir) {
        var bullet = Instantiate(this.Bullet, this.BulletSpawn.position, this.BulletSpawn.rotation) as GameObject;
        bullet.rigidbody2D.AddForce(dir.normalized * this.BulletIntialVelocity);
        this.audio.Play();
    }
}
