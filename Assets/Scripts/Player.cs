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

    void Start()
    {
        m_State = PlayerState.Idle;
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

        Debug.Log( m_State.ToString() );
    }
}
