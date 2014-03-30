using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject Player;

    private GameCamera m_camera;

	// Use this for initialization
	void Start () {
        this.m_camera = GetComponent<GameCamera>();
        this.m_camera.SetTarget(this.Player.transform);
        //this.SpawnPlayer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void SpawnPlayer() {
        //this.m_camera.SetTarget((Instantiate(this.Player, Vector3.zero, Quaternion.identity) as GameObject).transform);
        this.m_camera.SetTarget(this.Player.transform);
        

    }
}
