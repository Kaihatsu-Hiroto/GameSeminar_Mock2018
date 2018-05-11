﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSlow : MonoBehaviour {

    Vector2 vec;
    private float speeds = 0;
    private bool isBulletStart;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isBulletStart)
        {
            Vector3 mousePositionVec3 = Input.mousePosition;
            mousePositionVec3.z = -Camera.main.transform.position.z;

            vec = Camera.main.ScreenToWorldPoint(mousePositionVec3);

            float zRotation = Mathf.Atan2(vec.y - transform.position.y, vec.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
            speeds = 0.2f;
            isBulletStart = true;
        }

        transform.Translate(Vector2.right * speeds);

        if (transform.position.x > 10 || transform.position.y > 10)
        {
            isBulletStart = false;
            Destroy(gameObject);
        }
    }
}
