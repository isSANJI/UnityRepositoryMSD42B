using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16f;

    Vector2 paddlePosition;

    // Start is called before the first frame update
    void Start()
    {
       paddlePosition = new Vector2(transform.position.x, transform.position.y); 
    }

    // Update is called once per frame
    void Update()
    {
       //this gives me the position of the mouse in the x-axis
       float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;

       //paddlePosition = new Vector2(mousePos, transform.position.y);
       
       //set the x pposition of the paddle according to the mouse 
       paddlePosition.x = mousePos;
       
        //sets the current paddlePosition
       transform.position = paddlePosition;

    }
}
