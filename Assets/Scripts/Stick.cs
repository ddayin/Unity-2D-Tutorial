using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public enum State
    {
        NotVisible = 0, // 화면 상에 보이지 않는 상태
        Idle,           // 대기 상태
        Grow,           // 커지는 상태
        Fall,           // 떨어지는 상태
        Landed          // 떨어져서 착지된 상태
    }

    public int m_ID = 0;
    public State m_State = State.Idle;
    public float m_GrowSpeed = 10.0f;
    public float m_FallSpeed = 10.0f;

    private BoxCollider2D m_BoxCollider;

    private void Awake()
    {
        m_BoxCollider = transform.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            m_State = State.Grow;
        }

        // 마우스 버튼 클릭했다가 떼면 막대기가 떨어지는 상태가 된다.
        if (Input.GetMouseButtonUp(0) == true)
        {
            m_State = State.Fall;
        }
    }

    private void FixedUpdate()
    {
        FiniteStateMachine();
    }

    // 막대기에 다른 오브젝트가 충돌했을 때의 처리
    private void OnCollisionEnter2D( Collision2D collision )
    {
        if (m_State != State.Fall) return;
        
        if ( collision.transform.tag.Equals( "Tile" ) == true )
        {
            if ( collision.transform.GetComponent<Tile>().m_ID != m_ID )
            {
                m_State = State.Landed;
            }
        }
    }
    
    // 유한 상태 머신
    private void FiniteStateMachine()
    {
        switch (m_State)
        {
            case State.NotVisible:
                break;
            case State.Idle:
                break;
            case State.Grow:
                Grow();
                break;
            case State.Fall:
                FallRight();
                break;
            case State.Landed:
                break;
            default:
                break;
        }
    }

    // 막대기가 위쪽으로 자라난다.
    private void Grow()
    {
        // Y 축으로 변경할 값
        float growY = transform.localScale.y + m_GrowSpeed * Time.deltaTime;

        // 실제로 변경된 값으로 막대기 크기 조정
        transform.localScale = new Vector3( transform.localScale.x, growY, transform.localScale.z );
        m_BoxCollider.size = new Vector2(m_BoxCollider.size.x, growY * 0.1f);
    }

    // 오른쪽으로 막대기가 넘어진다.
    private void FallRight()
    {
        if ( m_State != State.Fall ) return;

        transform.Rotate( Vector3.back, m_FallSpeed * Time.deltaTime );
    }
}

