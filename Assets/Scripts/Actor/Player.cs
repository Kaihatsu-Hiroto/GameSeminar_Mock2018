using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    /// <summary> プレイヤーの向き</summary>
    public enum Direction {RIGHT=-1,LEFT=1 }

    /// <summary> 移動 </summary>
    private Vector3 m_move;

    /// <summary> クリックした座標 </summary>
    private Vector3 hitPos = Vector3.zero;

    /// <summary> 生成するバー </summary>
    [SerializeField]
    private GameObject bar;

    /// <summary> 現在の向き </summary>
    [SerializeField]
    private Direction m_currentDirection;

    /// <summary> 移動速度 </summary>
    [SerializeField]
    private float m_runSpeed;

    /// <summary> バー生成フラグ </summary>
    private bool m_barflg;

    [SerializeField]
    private Rigidbody2D m_rigidbody2D;

    [SerializeField]
    private SpriteRenderer m_spriteRenderer;

    private void Start(){
        m_spriteRenderer.flipX = m_currentDirection == Direction.RIGHT;
        m_move = new Vector3(m_runSpeed, 0, 0);
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    private void Run(){
        if (Input.GetKey(KeyCode.RightArrow)){
            m_spriteRenderer.flipX = m_currentDirection == Direction.RIGHT;
            transform.position += m_move;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            m_spriteRenderer.flipX = m_currentDirection == Direction.LEFT;
            transform.position -= m_move;
        }
    }

    /// <summary>
    ///　クリックした位置にバー生成
    /// </summary>
    private void Birth(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (Input.GetMouseButtonDown(0)){
            if (hit.collider){
                bar = Instantiate(bar, transform.position,Quaternion.identity);
                hitPos = ray.origin;
                m_barflg = true;
            }
        }
    }
    
    // Update is called once per frame
   private void Update () {
        Run();
        Birth();
    }
}
