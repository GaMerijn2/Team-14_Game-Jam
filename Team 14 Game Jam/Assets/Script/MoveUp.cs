using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveUp : MonoBehaviour
    
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = this.transform.position;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        float posY = this.transform.position.y;
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (posY >= 3) 
        { 
            speed = -.5f;
        }
        else if (posY <= 0)
        {
            speed = .5f;
        }
    }
}
