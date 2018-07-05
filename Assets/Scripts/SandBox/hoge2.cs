using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoge2 : MonoBehaviour {

    enum HogeState { def, extend }
    HogeState m_hogeState;

    LineRenderer m_linerendrer;
    private Vector3 m_extendPositon;

    public GameObject target;
    
    /// <summary>タッチ開始位置 </summary>
    private Vector3 touchStartPos;
    /// <summary>タッチ終了位置 </summary>
    private Vector3 touchEndPos;

    private float AngleRotation;

    /// <summary>向いている方向ベクトル </summary>
    private Vector3 angleVec;

    public TouchTest m_touchTest;

    [SerializeField]
    private float m_extendSpeed;



    void Start(){
        m_linerendrer = GetComponent<LineRenderer>();
        m_hogeState = HogeState.def;
        
}

    void Update(){
        m_extendPositon = target.transform.position;

        m_linerendrer.SetPosition(0, transform.position);
        m_linerendrer.SetPosition(1, m_extendPositon);
        
        if (m_hogeState == HogeState.def)
            Def();
        if (m_hogeState == HogeState.extend)
            Extend();
    }


    void Def(){
        transform.position = target.transform.position;

        touchStartPos = Camera.main.ScreenToWorldPoint(m_touchTest.m_touchStartPositon);
       

        if (m_touchTest.extendFlg)
            m_hogeState = HogeState.extend;
    }

    void Extend(){
        
         touchEndPos = Camera.main.ScreenToWorldPoint(m_touchTest.m_touchEndPositon);

                ///角度指定
                float zRotation = Mathf.Atan2(touchEndPos.y - touchStartPos.y,
                   touchEndPos.x - touchStartPos.x) * Mathf.Rad2Deg;

                Debug.Log(zRotation);

                //値格納
                AngleRotation = zRotation;

                //取得した角度反映
                transform.rotation = Quaternion.Euler(0f, 0f, AngleRotation);

                
        //移動量

        angleVec = transform.rotation * new Vector3(m_extendSpeed, 0f, 0);
        //向いている方向に向かって移動
        transform.position += angleVec * Time.deltaTime;

    }

}
