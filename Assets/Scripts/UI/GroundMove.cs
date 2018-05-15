using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour {

    /// <summary>動く床の状態 </summary
    enum State {Default,Up,Down };

    /// <summary>動くスピード </summary>
    [SerializeField]
    private float m_moveSpeed;

    /// <summary>動く床にかける力 </summary>
    private Vector3 m_moveGround;

    /// <summary>最初の場所 </summary>
    private Vector3 m_startPos;

    /// <summary>現在の状態 </summary>
    private State m_state;

    private void Start(){
        m_startPos = transform.position;
        m_state = State.Default;
    }

    public void Move(){

        m_moveGround = new Vector3(0, m_moveSpeed, 0);

        switch (m_state)
        {
            case State.Default:
                transform.position += m_moveGround;
                break;
            case State.Down:
                transform.position -= m_moveGround;
                break;
            case State.Up:
                transform.position += m_moveGround;
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y >= m_startPos.y + 5f)
            m_state = State.Down;

        if (transform.position.y <= m_startPos.y - 5f)
            m_state = State.Up;

        Move();

    }
}
