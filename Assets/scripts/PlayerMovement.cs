using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;



    // Update is called once per frame
    void Update()
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


        transform.Translate(xMovement, yMovement, 0);
        //transform,translate is a function in unity where you can move a transform
        //translate means movement
        //x,y,z



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //== means to set on if statements it should always be ==
        if (collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
        }

    }
}
