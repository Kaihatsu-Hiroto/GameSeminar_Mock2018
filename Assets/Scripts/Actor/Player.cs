using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    /// <summary>
    /// プレイヤーの向き
    /// </summary>
    public enum Direction {RIGHT=-1,LEFT=1 }

    private Vector3 move;
    private Vector3 hitPos=Vector3.zero;

    [SerializeField]
    private GameObject bar;

    [SerializeField]
    private Direction m_currentDirection;

    [SerializeField]
    private Rigidbody2D m_rigidbody2D;

    [SerializeField]
    private SpriteRenderer m_spriteRenderer;

    [SerializeField]
    private float m_runSpeed;

    private bool m_barflg;

    private void Start(){

        m_spriteRenderer.flipX = m_currentDirection == Direction.RIGHT;
        move = new Vector3(m_runSpeed, 0, 0);
    }

    private void Run(){
        if (Input.GetKey(KeyCode.RightArrow)){
            m_spriteRenderer.flipX = m_currentDirection == Direction.RIGHT;
            transform.position += move;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            m_spriteRenderer.flipX = m_currentDirection == Direction.LEFT;
            transform.position -= move;
        }
    }

    private void Slow(){
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
    void Update () {
        Run();
    }
}
