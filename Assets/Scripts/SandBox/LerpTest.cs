using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour {

    [SerializeField, Range(0.0f, 10.0f)]
    private float m_time = 0.0f;

    [SerializeField]
    private Vector3 m_targetPosition = Vector3.zero;

    [SerializeField]
    private Color m_startColor = Color.white;
    [SerializeField]
    private Color m_targetColor = Color.white;


    private float m_startTime = 0.0f;
    private Vector3 m_startPosition = Vector3.zero;


    private Color CurrentColor
    {
        set
        {
            var render = GetComponent<Renderer>();
            if (render == null){return;}

            if (render.material == null){return;}
            render.material.color = value;
        }
    }


    void Start(){
        m_startTime = Time.time;
        m_startPosition = transform.position;
    }

    void Update(){
        float timeStep = m_time > 0.0f ? (Time.time - m_startTime) / m_time : 1.0f;
        timeStep = Mathf.Clamp01(timeStep);

        transform.position = Vector3.Lerp(m_startPosition, m_targetPosition, timeStep);
        CurrentColor = Color.Lerp(m_startColor, m_targetColor, timeStep);
    }
}
