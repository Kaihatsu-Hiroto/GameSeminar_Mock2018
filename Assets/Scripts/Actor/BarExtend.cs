using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarExtend : MonoBehaviour {

    enum BarState {Default,Extnd,Shrink }
    BarState state;

    LineRenderer m_lineRenderer;

    [SerializeField, Range(0.1f, 1f)]
    private float m_extendSpeed;

    public Player m_player;

    [HideInInspector]
    public Vector3 hoge;

    Vector3 m_mousePosition;

    public Vector2 mouseVector;

    private void Start(){
        m_lineRenderer = GetComponent<LineRenderer>();
        state = 0;
    }

    public void Extend(){

        m_mousePosition = Input.mousePosition;
        m_mousePosition.z = -Camera.main.transform.position.z;
        mouseVector = Camera.main.ScreenToWorldPoint(m_mousePosition);

        m_lineRenderer.useWorldSpace = true;

        m_lineRenderer.SetPosition(0, m_player.transform.position);
        m_lineRenderer.SetPosition(1, hoge);

        if (Input.GetMouseButton(0))
        {
            state = BarState.Extnd;
        }
        if (Input.GetMouseButtonUp(0))
        {
            state = BarState.Shrink;
        }

        switch (state)
        {
            case BarState.Default:
                hoge = m_player.transform.position;
                break;
            case BarState.Extnd:
                // if (hoge.y < mouseVector.y)
                hoge = Vector3.Lerp(hoge, mouseVector, 0.3f);
                break;
            case BarState.Shrink:
                hoge -= Vector3.Lerp(hoge, mouseVector, 0.3f);
                state = BarState.Default;
                break;
            default:
                break;
        }
    }

    void Update(){
        Extend();
	}
}
