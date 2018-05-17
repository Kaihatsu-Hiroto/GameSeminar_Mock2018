using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour {

    /// <summary>開始地点 </summary>
    Vector3 m_startPosition;

    /// <summary>トゲの速度 </summary>
    [SerializeField]
    private float m_needleSpeed;

    /// <summary>消失地点 </summary>
    [SerializeField]
    private float m_lostPoint;

	// Use this for initialization
	void Start () {
        m_startPosition = transform.position;
	}

    void NeedleMove() {
        transform.position += new Vector3(0, -m_needleSpeed, 0);
        if (transform.position.y < m_startPosition.y - m_lostPoint)
            Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
        NeedleMove();
	}
}
