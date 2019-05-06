using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera m_Camera;
    public Transform m_Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 position = m_Player.position;
        position.Set( m_Player.position.x, m_Player.position.y, m_Camera.transform.position.z );
        m_Camera.transform.SetPositionAndRotation( position, Quaternion.identity );
    }
}
