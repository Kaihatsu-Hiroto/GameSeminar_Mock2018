using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragtest : MonoBehaviour {

    public void MyPointerDownUI()
    {
        Debug.Log("押された");
    }

    public void MyDragUI()
    {
        transform.position = Input.mousePosition;
    }
}
