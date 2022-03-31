using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5.0f;


    // Update is called once per frame
    void Update()
    {
        float xValue = speed * Time.deltaTime;
        transform.Translate(xValue, 0, 0);
        



    }
}
