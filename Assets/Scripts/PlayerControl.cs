using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //
    [SerializeField] int numberOfLanes = 3;
    [SerializeField] int currentLane = 2;
    [SerializeField] float laneWidth = 3;
    [SerializeField] float jumpSpeed = 7;

    bool inAir = false;

    //
    Rigidbody rigidBody;
    GameManager gameManager;
    Animator animator;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();

        animator = GetComponentInChildren<Animator>();       
    }

    void Update()
    {
        MoveForward();
        CheckInput();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * gameManager.speed * Time.deltaTime;
    }

    private void CheckInput()
    {
        CheckSideMovement();
        CheckJump();
    }

    private void CheckSideMovement()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentLane--;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            currentLane++;
        }

        currentLane = Mathf.Clamp(currentLane, 1, numberOfLanes);

        //
        Vector3 newPosition = transform.position;
        newPosition.x = laneWidth * (currentLane - 2);

        transform.position = Vector3.MoveTowards(transform.position, newPosition, 0.5f);
    }

    private void CheckJump()
    {
        if (!inAir)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inAir = true;
                rigidBody.velocity = Vector3.up * jumpSpeed;
            }
        }
    }      

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Coin"))
        {
            gameManager.AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.tag.Equals("Obstacle"))
        {
            gameManager.FinishGame();
        }
        else if (other.tag.Equals("RoadBlock"))
        {
            rigidBody.velocity = Vector3.zero;
            StartCoroutine(SetInAir(false));
        }
    }

    IEnumerator SetInAir(bool value)
    {
        yield return new WaitForSeconds(0.15f);

        inAir = value;
    }
}
