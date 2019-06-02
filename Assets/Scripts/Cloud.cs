using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float m_Speed = 0.01f;    // 이동 속도
    public bool m_MoveRight = true; // 오른쪽으로 이동하는 것인지

    void Start()
    {
 
    }

    void Update()
    {
        // x 축으로 이동할 위치
        Vector3 newPosition = transform.position;
        newPosition.x = newPosition.x + m_Speed;

        // 구름의 위치 변경
        transform.SetPositionAndRotation( newPosition, Quaternion.identity );
    }
}
