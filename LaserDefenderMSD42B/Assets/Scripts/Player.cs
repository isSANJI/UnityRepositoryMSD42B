using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float movementSpeed = 10f;

    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetUpBoundaries();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private float MoveX()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        float newXPos = transform.position.x + deltaX;

        return newXPos;
    }

    private float MoveY()
    {
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        float newYPos = transform.position.y + deltaY;

        return newYPos;
    }

    private void Move()
    {
        //clamping the values between xMin and xMax; yMin and yMax
        float xPos = Mathf.Clamp(MoveX(), xMin, xMax);
        float yPos = Mathf.Clamp(MoveY(), yMin, yMax);

        transform.position = new Vector2(xPos, yPos);

        
    }
}
