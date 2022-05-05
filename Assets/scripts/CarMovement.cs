using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{
    public float speed = 5.0f;


    // Update is called once per frame
    void Update()
    {
        float xValue = speed * Time.deltaTime;
        transform.Translate(xValue, 0, 0);
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //== means to set on if statements it should always be ==
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        
    }

}
