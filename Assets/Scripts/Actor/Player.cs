using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    /// <summary> プレイヤーの向き</summary>
    public enum Direction { RIGHT = -1, LEFT = 1 }

    /// <summary> ジャンプ </summary>
    private Vector3 m_move;

    /// <summary> 移動 </summary>
    private Vector3 m_jump;

    /// <summary>伸ばす速さ </summary>
    [SerializeField, Range(0.1f, 1f)]
    private float m_possessSpeeds;

    /// <summary> 生成するバー </summary>
    [SerializeField]
    private GameObject m_bar;

    /// <summary> 現在の向き </summary>
    [SerializeField]
    private Direction m_currentDirection;

    /// <summary>ジャンプ量 </summary>
    [SerializeField]
    private float m_jumpPower;

    /// <summary> 移動速度 </summary>
    [SerializeField]
    private float m_runSpeed;

    /// <summary> 遅延速度 </summary>
    [SerializeField]
    private float m_delaySpeed;

    [SerializeField]
    private Rigidbody2D m_rigidbody2D;

    [SerializeField]
    private BoxCollider2D m_boxCollider2D;

    [SerializeField]
    private SpriteRenderer m_spriteRenderer;

    [SerializeField]
    private Tip m_tip;

    private void Start() {
        m_spriteRenderer.flipX = m_currentDirection == Direction.RIGHT;
        m_move = new Vector3(m_runSpeed, 0, 0);
        m_jump = new Vector3(0, m_jumpPower, 0);
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_boxCollider2D = GetComponent<BoxCollider2D>();
    }

    /// <summary>
    ///左移動
    /// </summary>
    public void RunRight(){
        m_spriteRenderer.flipX = m_currentDirection == Direction.RIGHT;
        transform.position += m_move;
    }

    /// <summary>
    /// 右移動
    /// </summary>
    public void RunLeft(){
        m_spriteRenderer.flipX = m_currentDirection == Direction.LEFT;
        transform.position -= m_move;
    }
    /// <summary>
    /// 上にジャンプにする
    /// </summary>
    public void Jump() { transform.position += m_jump; }

    /// <summary>
    /// 高くジャンプする
    /// </summary>
    public void HighJump() {
        m_rigidbody2D.AddForce(new Vector2(0, 13f), ForceMode2D.Impulse);
    }
    /// <summary>
    /// のけ反る
    /// </summary>
    public void Bound(){
        transform.position += new Vector3(-0.5f, 0.5f, 0);
    }

    /// <summary>
    /// プレイヤーの各行動
    /// </summary>
    public void PlayerAction() {
        if (Input.GetKey(KeyCode.RightArrow)) { RunRight(); }
        if (Input.GetKey(KeyCode.LeftArrow)) { RunLeft(); }
        if (Input.GetKey(KeyCode.UpArrow)){ Jump(); }
        if (m_tip.moving) { Access(); }
    }

    /// <summary>アームの当たった位置へ移動 </summary>
    public void Access(){
        if (m_tip.tipState == Tip.TipState.Wall){
            transform.position = Vector3.Lerp(transform.position, m_tip.transform.position, m_possessSpeeds);
            m_rigidbody2D.velocity = new Vector3(0, -2f, 0);        //←後で直すとこ
        }

        if (m_tip.tipState == Tip.TipState.Button)
        {
            m_rigidbody2D.velocity = new Vector3(0, -m_delaySpeed, 0);        //←後で直すとこ
        }
        if (m_tip.tipState == Tip.TipState.Item){
            transform.position = Vector3.Lerp(transform.position, m_tip.transform.position, m_possessSpeeds);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.tag == "Item") {
            m_spriteRenderer.color = new Color(255, 0, 0);
            m_move.x = 0.1f;
        }

        if (collision.tag == "Death"){
            m_rigidbody2D.AddForce(new Vector2(0, 2f), ForceMode2D.Impulse);
        }

        if (collision.tag == "Needle"){
            m_rigidbody2D.AddForce(new Vector2(0, -5f), ForceMode2D.Impulse);
        }
    }

    void Update() {
        PlayerAction();
    }
}
