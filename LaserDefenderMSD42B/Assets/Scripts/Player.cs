using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private float MoveX()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float newXPos = transform.position.x + deltaX;

        return newXPos;
    }

    private float MoveY()
    {
        float deltaY = Input.GetAxis("Vertical");
        float newYPos = transform.position.y + deltaY;

        return newYPos;
    }

    private void Move()
    {
        transform.position = new Vector2(MoveX(), MoveY());

        
    }
}
