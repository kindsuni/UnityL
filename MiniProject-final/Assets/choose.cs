using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose : MonoBehaviour
{

    public static bool right = false;
    public static bool left = false;
    float rotationSp = 3f;

    float accAngle = 0f;
    float angle = 90;

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    private void FixedUpdate()
    {

        if (right && accAngle < angle)
        {
            transform.Rotate(Vector3.up * rotationSp);
            accAngle += rotationSp;

        }
        else
            right = false;

        if (left && accAngle > -angle)
        {
            transform.Rotate(Vector3.up * -rotationSp);
            accAngle -= rotationSp;

        }
        else
            left = false;

    }

    void Update()
    {

    }
    public void inputRight()
    {
        if (!right && !left)
        {
            Select.i++;
            right = true;
            accAngle = 0f;
            left = false;
            iReset();
        }

    }
    public void inputLeft()
    {
        if (!right && !left)
        {
            Select.i--;

            left = true;
            accAngle = 0f;
            right = false;
            iReset();
        }
    }
    void iReset()
    {

        if (Select.i == 4)
        {

            Select.i = 0;
        }

        if (Select.i < 0)
        {

            Select.i = 3;
        }

    }

}
