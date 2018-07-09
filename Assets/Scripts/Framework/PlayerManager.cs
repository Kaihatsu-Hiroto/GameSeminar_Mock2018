using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public enum PlayerState { Deffalt,Move,Jump }

    PlayerState m_playerState;

    public Punicon m_player;

    Rigidbody2D playerRigidBody;

    

    void Start(){
        playerRigidBody=m_player.GetComponent<Rigidbody2D>();
    }
	// Update is called once per frame
	void Update () {
	}
}
