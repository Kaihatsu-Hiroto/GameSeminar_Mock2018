using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarExtend : MonoBehaviour {


    LineRenderer m_lineRenderer;
    public Player m_player = new Player();

    [SerializeField, Range(0.00f, 0.10f)]
    private float m_extendSpeed;

    private float m_linePosy = 0;

    private void Start(){
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    public void Extend(){
        m_lineRenderer.useWorldSpace = false;
        m_lineRenderer.SetPosition(0, new Vector3(0, m_linePosy, 0));
        m_linePosy += m_extendSpeed;
    }
    void Update(){
        Extend();
	}
}
