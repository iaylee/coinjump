using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;

    [SerializeField] private float minX, maxX;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Late Update is called every frame is called after all Update functions are executed
    void LateUpdate()
    {
        if (!player)
            return;
        tempPos = transform.position; //current position of camera
        tempPos.x = player.position.x;
        if (tempPos.x < minX)
        {
            tempPos.x = minX; //set the cam's x pos to player's x pos
        }

        if(tempPos.x > maxX)
        {
            tempPos.x = maxX; //set the cam's x pos to player's x pos
        }
        tempPos.y = player.position.y;
        transform.position = tempPos;

    }
}
