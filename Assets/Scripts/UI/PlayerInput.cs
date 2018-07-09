using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	
    public enum PlayerInputState { Stay,Run,Jump}

    public TouchTest m_touchTest;
    private Vector2 hogespeed;
    public float moveSpeed = 0.5f;

    private Vector3 startPosition;
    private Rigidbody2D m_rigidbody2D;

    void Start(){
        
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void PlayerMove(){
        startPosition = m_touchTest.m_pressStartPosition;

        
        hogespeed = new Vector2(moveSpeed, 0);
        m_rigidbody2D.velocity += hogespeed;
        
    }

	// Update is called once per frame
	void Update () {
        PlayerMove();
    }
}
