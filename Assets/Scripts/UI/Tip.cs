using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour {

    public enum TipState {Wall,Button,Item }

    /// <summary>
    /// 先端が当たっているオブジェクト
    /// </summary>
    public TipState tipState;

    /// <summary>バーコンポーネント</summary>
    public BarExtend m_barExtend;

    /// <summary>プレイヤーコンポーネント</summary>
    public Player m_player;

    SpriteRenderer m_spriteRenderer;

    [SerializeField]
    private Sprite m_starSprite;

    /// <summary>移動フラグ</summary>
    public bool moving = false;


    private void Start(){
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            moving = true;
            tipState = TipState.Wall;
        }

        if (collision.tag == "Button")
        {
            moving = true;
            tipState = TipState.Button;
        }
        if (collision.tag == "Item")
        {
            tipState = TipState.Item;
            //m_spriteRenderer.sprite = m_starSprite;
        }
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
