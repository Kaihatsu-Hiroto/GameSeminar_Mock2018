using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private GameObject player = null;
    private Vector3 offset = Vector3.zero;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        if (player.transform.position.x >= transform.position.x + 9f){
            transform.position += new Vector3(18f, 0, 0);
        }
        if (player.transform.position.x <= transform.position.x - 9f)
            transform.position -= new Vector3(18f, 0, 0);

        if (player.transform.position.y >= transform.position.y + 5f)
            transform.position += new Vector3(0, 10f, 0);

        if (player.transform.position.y <= transform.position.y - 5f)
            transform.position -= new Vector3(0, 10f, 0);

            
    }
}
