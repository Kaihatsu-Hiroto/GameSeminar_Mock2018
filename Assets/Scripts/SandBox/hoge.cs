using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoge : MonoBehaviour {


    Vector3 hogemove = new Vector3(0, 0.05f, 0);
    public Vector3 hogePos;
    public void move()
    {
        if (transform.position.y < 4) { transform.position -= hogemove; }
        else if (transform.position.y < -4){transform.position += hogemove;}
        hogePos = transform.position;
    }
	// Update is called once per frame
	void Update () {
        move();
	}
}
