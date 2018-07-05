using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TouchScript.Gestures;

public class TouchTest : MonoBehaviour {

    [HideInInspector]
    public Vector3 m_touchStartPositon;
    [HideInInspector]
    public Vector3 m_touchEndPositon;

    public bool extendFlg;

    public static Vector3 touchStartPosition;

    void OnEnable()
    {   
        GetComponent<FlickGesture>().Flicked += FlickedHandle;

        // FlickGestureのdelegateに登録
        GetComponent<TapGesture>().Tapped += tappedHandle;

        GetComponent<LongPressGesture>().LongPressed += LongPressHandle;
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

        GetComponent<FlickGesture>().Flicked += FlickedHandle;

        GetComponent<LongPressGesture>().LongPressed += LongPressHandle;
    }

    void tappedHandle(object sender, System.EventArgs e)
    {
        //処理したい内容
        var send = sender as TapGesture;     
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
       // m_touchEndPositon = gesture.ScreenFlickVector;
        m_touchEndPositon = gesture.ScreenPosition;

        extendFlg = true;
    }

    void LongPressHandle(object sender, System.EventArgs e){
        //処理したい内容
        var send = sender as LongPressGesture;
        Debug.Log("押してる");

        m_touchStartPositon = send.ScreenPosition;
    }

}