using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoge2 : MonoBehaviour {

    LineRenderer m_linerendrer;
    public Vector3 m_extendPositon;
    public GameObject target;

    float AngleRotation;
    /// <summary>向いている方向ベクトル </summary>
     Vector3 angleVec;



    void Start(){
        m_linerendrer = GetComponent<LineRenderer>();
    }

    void Update(){

        m_linerendrer.SetPosition(0, transform.position);
        m_linerendrer.SetPosition(1, m_extendPositon);

        if (Input.GetMouseButtonUp(0))
        {
            ///角度指定
            float zRotation = Mathf.Atan2(target.transform.position.y - transform.position.y,
                target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            //値格納
            AngleRotation = zRotation;
        }
        //取得した角度反映
        transform.rotation = Quaternion.Euler(0f, 0f, AngleRotation);

        //移動量
        angleVec = transform.rotation * new Vector3(1f, 0, 0);

        //向いている方向に向かって移動
        transform.position += angleVec * Time.deltaTime;

    
    }
}
