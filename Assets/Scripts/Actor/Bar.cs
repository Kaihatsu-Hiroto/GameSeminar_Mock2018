using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{

    /// <summary>
    /// 到着までの時間
    /// </summary>
    [SerializeField, Range(0.0f, 10.0f)]
    private float m_time = 0.0f;

    /// <summary> 初期時間 </summary>
    private float m_startTime = 0.0f;

    /// <summary>開始地点 </summary>
    [SerializeField]
    private Vector3 m_startPosition = Vector3.zero;

    /// <summary>開始地点 </summary>
    [SerializeField]
    /// <summary> 終了地点/// </summary>
    private Vector3 m_targetPosition = Vector3.zero;

    /// <summary>
    /// </summary>
    public Player m_player;

    public void barMove(){
        float timeStep = m_time > 0.0f ? (Time.time - m_startTime) / m_time : 1.0f;

        timeStep = Mathf.Clamp01(timeStep);

        transform.position = Vector3.Lerp(m_startPosition, m_targetPosition, timeStep);
    }

    private void Start(){
        m_startTime = Time.time;
        m_startPosition = transform.position;

        if (m_player == null){
            m_player = GetComponent<Player>();
        }
    }
}
