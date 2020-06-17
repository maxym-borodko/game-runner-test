using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //
    [SerializeField] float speed = 0.5f;
    [SerializeField] int numberOfLanes = 3;
    [SerializeField] int currentLane = 2;
    [SerializeField] float laneWidth = 3;
    [SerializeField] float jumpSpeed = 7;

    //
    Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        CheckInput();
    }

    private void Move()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentLane--;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            currentLane++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity += Vector3.up * jumpSpeed;
        }


        currentLane = Mathf.Clamp(currentLane, 1, numberOfLanes);

        //
        Vector3 newPosition = transform.position;
        newPosition.x = laneWidth * (currentLane - 2);

        transform.position = Vector3.MoveTowards(transform.position, newPosition, 0.5f);//newPosition;
    }
}
