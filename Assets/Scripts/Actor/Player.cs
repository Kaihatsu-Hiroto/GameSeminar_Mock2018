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

    /// <summary> クリックした座標 </summary>
    [HideInInspector]
    public Vector3 m_hitPos;

    /// <summary> クリックした座標 </summary>
    Vector3 m_mousePosition;

    /// <summary> 二次元ベクトル </summvary>
    Vector2 mouseVector;
    
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

    /// <summary> バー生成フラグ </summary>
    private bool m_barflg;

    [SerializeField]
    private Rigidbody2D m_rigidbody2D;

    [SerializeField]
    private SpriteRenderer m_spriteRenderer;

    private void Start() {
        m_spriteRenderer.flipX = m_currentDirection == Direction.RIGHT;
        m_move = new Vector3(m_runSpeed, 0, 0);
        m_jump = new Vector3(0, m_jumpPower, 0);
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
    /// キー処理によるプレイヤーの各行動
    /// </summary>
    public void PlayerAction() {
        if (Input.GetKey(KeyCode.RightArrow)) { RunRight(); }
        if (Input.GetKey(KeyCode.LeftArrow)) { RunLeft(); }
        if (Input.GetKey(KeyCode.UpArrow)){ Jump(); }
    }

    /*
    /// <summary>
    ///　オブジェクトクリックで生成
    /// </summary>
    public void Birth() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        
            if (hit.collider){
                bar = Instantiate(bar, transform.position, Quaternion.identity);
                m_hitPos = ray.origin;
                m_barflg = true;
            }
    }
    */

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

    /// <summary>
    /// 何かを伸ばす
    /// </summary>
    public void Extend(){
        if (Input.GetMouseButtonDown(0))
        {

            m_bar = Instantiate(m_bar, transform.position, Quaternion.identity);

            m_mousePosition = Input.mousePosition;
            m_mousePosition.z = -Camera.main.transform.position.z;
            mouseVector = Camera.main.ScreenToWorldPoint(m_mousePosition);


            LineRenderer m_lineRenderer;
            m_lineRenderer = m_bar.GetComponent<LineRenderer>();

            float zRotation = Mathf.Atan2(mouseVector.y -transform.position.y, mouseVector.x - transform.position.x) * Mathf.Rad2Deg;
            m_bar.transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

            m_lineRenderer.SetPosition(0, transform.position);
            m_lineRenderer.SetPosition(1, m_mousePosition);
        }
    }

    void Update() {
        PlayerAction();
        Birth();
        
    }
}
