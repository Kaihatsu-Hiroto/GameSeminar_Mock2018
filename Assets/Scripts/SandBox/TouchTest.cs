using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TouchScript.Gestures;

public class TouchTest : MonoBehaviour {

    private Vector3 m_touchStartPositon;
    private Vector3 m_touchEndPositon;

    public static Vector3 touchStartPosition;

    void OnEnable()
    {   
        GetComponent<FlickGesture>().Flicked += FlickedHandle;

        // FlickGestureのdelegateに登録
        GetComponent<TapGesture>().Tapped += tappedHandle;
    }
    
    void OnDisable()
    {
        UnsubscribeEvent();
    }
    
    void OnDestroy()
    {
        UnsubscribeEvent();
    }

    void UnsubscribeEvent()
    {
        // 登録を解除
        //GetComponent<FlickGesture>().Flicked -= FlickedHandle;
        GetComponent<TapGesture>().Tapped += tappedHandle;
    }

    void tappedHandle(object sender, System.EventArgs e)
    {
        //処理したい内容
        var send = sender as TapGesture;
        m_touchStartPositon = send.ScreenPosition;
    }

    void FlickedHandle(object sender, System.EventArgs e)
    {
        var gesture = sender as FlickGesture;
        // ジェスチャが適切かチェック
        if (gesture.State != FlickGesture.GestureState.Recognized)
            return;
        // 処理したい内容
        // gesture.ScreenFlickVectorにフリック方向が入るので
        // if (gesture.ScreenFlickVector.y < 0)としたら下方向へのフリックを検知できる

        //タッチ終了座標
        m_touchEndPositon = gesture.ScreenFlickVector;

        Debug.Log("タッチ終了"+m_touchEndPositon);

        ///角度指定
        float zRotation = Mathf.Atan2(m_touchEndPositon.y - m_touchStartPositon.y, m_touchEndPositon.x - m_touchStartPositon.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
       // Debug.Log("角度"+zRotation);
    }
    
}