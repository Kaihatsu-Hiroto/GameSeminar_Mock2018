using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex : MonoBehaviour {

    private LineRenderer m_linerenderer;

    [SerializeField]
    private Punicon m_punicon;

    private float m_extend;

    private Vector3 mouseUpPosition;

    [HideInInspector]
    public bool m_extending;

    void Start() {
        m_linerenderer = GetComponent<LineRenderer>();
        m_linerenderer.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(m_punicon.transform.position.x, m_punicon.transform.position.y,1);

        if (m_extending == false)
        {
            transform.position = new Vector3(m_punicon.transform.position.x,
                            m_punicon.transform.position.y, 1);
        }

        mouseUpPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            ///角度指定
            float zRotation = Mathf.Atan2(mouseUpPosition.y - transform.position.y, mouseUpPosition.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);


        if (Input.GetMouseButtonUp(0))
        {
            m_extending = true;
            
        }

        if (m_extending) { transform.Translate(Vector3.right * 0.5f); }

        m_linerenderer.SetPosition(1, transform.position);
        m_linerenderer.SetPosition(0, m_punicon.transform.position);

        //transform.Translate(Vector2.right * 0.5f);
    }
}
