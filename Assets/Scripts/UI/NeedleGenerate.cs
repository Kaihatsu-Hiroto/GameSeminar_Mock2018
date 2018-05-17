using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleGenerate : MonoBehaviour {


    /// <summary>生成するトゲ </summary>
    [SerializeField]
    private GameObject m_needle;

    /// <summary>生成座標 </summary>
    private　Vector3 m_gPos;
    /// <summary>生成座標2 </summary>
    private Vector3 m_gPos2;
    /// <summary>生成座標3 </summary>
    private Vector3 m_gPos3;

    /// <summary>
    /// 各生成座標指定
    /// </summary>
    private void Start(){
        StartCoroutine("Fire");
        m_gPos = transform.position;
        m_gPos2 = new Vector3(m_gPos.x + 4.5f, m_gPos.y, m_gPos.z);
        m_gPos3 = new Vector3(m_gPos.x - 4.5f, m_gPos.y, m_gPos.z);
    }

    private IEnumerator Fire(){

        while (true){
            yield return new WaitForSeconds(1f);
            Instantiate(m_needle, m_gPos, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
            Instantiate(m_needle, m_gPos2, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
            Instantiate(m_needle, m_gPos3, Quaternion.identity);
        }
    }
}
