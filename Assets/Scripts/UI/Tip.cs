using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour {

    /// <summary>バーコンポーネント</summary>
    public BarExtend m_barExtend;

    /// <summary>プレイヤーコンポーネント</summary>
    public Player m_player;

    /// <summary>移動フラグ</summary>
    public bool moving = false;

    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            moving = true;
    }

    private void OnTriggerExit2D(Collider2D collision){
        moving = false;
        transform.position = m_barExtend.hoge;
    }


    // Update is called once per frame
    void Update () {
        transform.position = m_barExtend.hoge;
    }
}
