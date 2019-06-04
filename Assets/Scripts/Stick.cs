using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public float m_GrowSpeed = 10.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if ( Input.GetMouseButton( 0 ) == true )
        {
            // Y 축으로 변경할 값
            float growY = transform.localScale.y + m_GrowSpeed * Time.deltaTime;

            // 실제로 변경된 값으로 막대기 크기 조정
            transform.localScale = new Vector3(transform.localScale.x, growY, transform.localScale.z);
        }
    }
}
