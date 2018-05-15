using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGround : MonoBehaviour {

    /// <summary>
    ///ほかに方法があったかもしれない
    /// </summary>
    public Player m_player;

    void OnCollisionEnter2D(Collision2D other){
         m_player.HighJump();

    }
}
