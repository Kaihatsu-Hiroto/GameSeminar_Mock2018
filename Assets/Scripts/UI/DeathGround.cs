using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGround : MonoBehaviour {

    public Player m_player;

    void OnCollisionEnter2D(Collision2D other){
        m_player.Bound();
    }
}
