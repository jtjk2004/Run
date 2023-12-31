using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private float minX,maxX;
    [SerializeField]
    private float minY,maxY;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y+2f;
        transform.position = tempPos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position;
        if (tempPos.x+1f<player.position.x)
        {
            tempPos.x = player.position.x-1f;
        }
        if (tempPos.x-3.5f>player.position.x)
        {
            tempPos.x = player.position.x+3.5f;
        }
        if (tempPos.y+2.6f<player.position.y)
        {
            tempPos.y = player.position.y-2.6f;
        }
        if (tempPos.y-3f>player.position.y)
        {
            tempPos.y = player.position.y+3f;
        }
        
        if(tempPos.x<minX)
        tempPos.x=minX;
        if(tempPos.x>maxX)
        tempPos.x=maxX;
        if(tempPos.y<minY)
        tempPos.y=minY;
        if(tempPos.y>maxY)
        tempPos.y=maxY;
        transform.position = tempPos;
    }
     
}
