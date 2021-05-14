using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// 플레이어의 상태
    /// </summary>
    public enum PlayerState
    {
        Idle = 0,   // 대기 상태
        Walk,       // 이동 상태
        Stick       // 막대기를 늘리고 있는 상태
    }

    public PlayerState m_State;
    public float m_MoveSpeed = 1f;

    private Rigidbody2D m_RigidBody;

    private void Awake()
    {
        m_RigidBody = transform.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // m_State = PlayerState.Idle;
        m_State = PlayerState.Walk;
        Debug.Log("PlayerState.Walk");
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown( 0 ) == true )
        {
            m_State = PlayerState.Stick;
        }

        if ( Input.GetMouseButtonUp( 0 ) == true )
        {
            m_State = PlayerState.Idle;
        }

        //Debug.Log( m_State.ToString() );

        
    }

    private void FixedUpdate()
    {
        switch (m_State)
        {
            case PlayerState.Idle:
                break;
            
            case PlayerState.Walk:
                // MoveForward();
                WalkForward();
                break;
            
            case PlayerState.Stick:
                break;
            
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (m_State != PlayerState.Walk) return;
        
        if (other.tag.Equals("TileEdge") == true)
        {
            Debug.Log("PlayerState.Idle");
            m_State = PlayerState.Idle;
            m_RigidBody.velocity = Vector2.zero;
        }
    }

    private void WalkForward()
    {
        m_RigidBody.velocity = new Vector2(m_MoveSpeed, 0f);
    }

    private void StopAtEdge()
    {
        
    }
}
