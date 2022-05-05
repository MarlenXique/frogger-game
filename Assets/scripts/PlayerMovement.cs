using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public GameManager gameManager;
    private AudioSource audioSource;

    public AudioClip hopClip;


    private float moveDuration = 0.5f;
    private float timeElapsed;
    private Vector3 targetPosition;
    //private bool readyToMove = true;
    private bool isMoving = false;
    public float moveMultipler = 0.5f;

    public enum MovementType
    {
        Continous,
        Discrete,

    }

    public MovementType movementType;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        targetPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if(movementType == MovementType.Continous)
        {
            ContinousMovement();
        }
        else
        {
            if (!isMoving)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    SetTargetPosition("Up");
                    audioSource.PlayOneShot(hopClip);
                    
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    SetTargetPosition("Left");
                    audioSource.PlayOneShot(hopClip);
                    
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    SetTargetPosition("Down");
                    audioSource.PlayOneShot(hopClip);
                    
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    SetTargetPosition("Right");
                    audioSource.PlayOneShot(hopClip);
                    
                }
            }

                if (targetPosition != transform.position)
                {
                    isMoving = true;

                    DiscreteMovement(transform.position, transform.position);


                }
                //DiscreteMovement();

            


        }

    }

    private void SetTargetPosition(string direction)
    {
        if(direction == "Up")
        {
            targetPosition = transform.position + (Vector3.up * moveMultipler);

        }
        if (direction == "Down")
        {
            targetPosition = transform.position + (Vector3.down * moveMultipler);

        }
        if (direction == "Left")
        {
            targetPosition = transform.position + (Vector3.left * moveMultipler);

        }
        if (direction == "Right")
        {
            targetPosition = transform.position + (Vector3.right * moveMultipler);

        }


    }






    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        //== means to set on if statements it should always be ==
        if (collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("frogger-game");

        }

    }

    private void ContinousMovement()
    {
        //variable making xMove and yMove x and y axis on any negative and positive #
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        //get axis raw skips decimal, max speed and when you stop immediatly 0
        //getaxis raw- any number between 0-1


        float xMovement = xMove * speed * Time.deltaTime;
        float yMovement = yMove * speed * Time.deltaTime;
        //time.delta balances frames, so good and bad computers play the same
        //levels the playing field
        //Time.deltaTime makes fram rate independent 


        transform.Translate(xMovement, yMovement, 0);
        //transform,translate is a function in unity where you can move a transform
        //translate means movement
        //x,y,z

    }

    private void DiscreteMovement(Vector3 start, Vector3 end)
    {
        if (timeElapsed < moveDuration)
        {
            timeElapsed += Time.deltaTime;

            transform.position = Vector3.Lerp(start, end, timeElapsed/moveDuration);
        }
        else
        {
            transform.position = targetPosition;
            isMoving = false;



        }
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Triggered");

        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("AREA CLEARED");
            SceneManager.LoadScene("frogger-game");
        }

    }



}
