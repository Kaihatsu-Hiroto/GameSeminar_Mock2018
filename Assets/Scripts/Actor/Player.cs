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
    [SerializeField]
    private float m_slowSpeeds;

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

    [SerializeField]
    private Rigidbody2D m_rigidbody2D;

    [SerializeField]
    private SpriteRenderer m_spriteRenderer;

    [SerializeField]
    private Tip m_tip;

    float hogey = 0;

    private void Start() {
        m_spriteRenderer.flipX = m_currentDirection == Direction.RIGHT;
        m_move = new Vector3(m_runSpeed, 0, 0);
        m_jump = new Vector3(0, m_jumpPower, 0);
        m_rigidbody2D = GetComponent<Rigidbody2D>();
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
    /// プレイヤーの各行動
    /// </summary>
    public void PlayerAction() {
        if (Input.GetKey(KeyCode.RightArrow)) { RunRight(); }
        if (Input.GetKey(KeyCode.LeftArrow)) { RunLeft(); }
        if (Input.GetKey(KeyCode.UpArrow)){ Jump(); }
        if (m_tip.moving) { Access(); }
    }

    public void Access() {
        transform.position = Vector3.Lerp(transform.position, m_tip.transform.position,m_slowSpeeds);

    }
/*
    public　void Birth()
    {
        if (Input.GetMouseButtonDown(0)){
            m_bar = Instantiate(m_bar, transform.position, Quaternion.identity);

            m_mousePosition = Input.mousePosition;
            m_mousePosition.z = -Camera.main.transform.position.z;
            mouseVector = Camera.main.ScreenToWorldPoint(m_mousePosition);

            float zRotation = Mathf.Atan2(mouseVector.y - m_bar.transform.position.y, mouseVector.x - m_bar.transform.position.x) * Mathf.Rad2Deg;
            m_bar.transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

            m_bar.transform.Translate(Vector2.right * m_slowSpeeds);
        }
        m_bar.transform.Translate(Vector2.right * m_slowSpeeds);
    }
 */
    void Update() {

        PlayerAction();
        
    }
}
