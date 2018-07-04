using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickTest : MonoBehaviour {

    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    enum Direction { right,left,up,down,touch}
    Direction m_direction;

    bool Flying;

    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = Input.mousePosition;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = Input.mousePosition;
            GetDirection();
        }
    }
    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //右向きにフリック
                m_direction = Direction.right;
            }
            else if (-30 > directionX)
            {
                //左向きにフリック
                m_direction = Direction.left;
            }
        } else if (Mathf.Abs(directionX) < Mathf.Abs(directionY)){
            if (30 < directionY) {
                //上向きにフリック
                m_direction = Direction.up;
                
            } else if (-30 > directionY) {
                //下向きのフリック
                m_direction = Direction.down;
            }
        } else {
            //タッチを検出
            m_direction = Direction.touch;
        } 

        switch (m_direction) {
            case Direction.up:
                //上フリックされた時の処理
                Debug.Log("上");
                break;

            case Direction.down:
                //下フリックされた時の処理
                Debug.Log("下");
                break;

            case Direction.right:
                //右フリックされた時の処理
                Debug.Log("右");
                break;

            case Direction.left:
                //左フリックされた時の処理
                Debug.Log("左");
                break;

            case Direction.touch:
                //タッチされた時の処理
                Debug.Log("タッチ");
                break;
        }

        ///角度指定
        float zRotation = Mathf.Atan2(touchEndPos.y - touchStartPos.y, touchEndPos.x - touchStartPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
        Flying = true;
    }

    void Fly()
    {
        Rigidbody2D m_rigidbody2D;
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        if (Flying)
        {
            transform.Translate(Vector2.right * 0.05f);
        }
    }
    

    void Update()
    {
        Flick();
        Fly();
    }
}
