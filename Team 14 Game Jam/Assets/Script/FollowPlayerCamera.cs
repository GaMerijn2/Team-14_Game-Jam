using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    //offset from the viewport center to fix damping
    public float m_DampTime = 10f;
    public Transform player;
    public float m_XOffset = 0;
    public float m_YOffset = 0;

	private float margin = 0.1f;


	void Start () 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update() 
    {
        if(player) 
        {
			float targetX = player.position.x + m_XOffset;
			float targetY = player.position.y + m_YOffset;

			if (Mathf.Abs(transform.position.x - targetX) > margin)
				targetX = Mathf.Lerp(transform.position.x, targetX, 1/m_DampTime * Time.deltaTime);

			if (Mathf.Abs(transform.position.y - targetY) > margin)
				targetY = Mathf.Lerp(transform.position.y, targetY, m_DampTime * Time.deltaTime);
            
			transform.position = new Vector3(targetX, targetY, 0);
        }
    }
}