using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSlider : MonoBehaviour
{

    public float moveSpeed = 1f;
    private int direction = 1;

    private void Update()
    {
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        direction *= -1;
    }



    //private string type = "INC";
    //private Vector3 movement = new Vector3();

    //private void Start()
    //{
    //    movement.x = 1.05f;
    //}

    //void Update(){
    //    float currentValue = transform.position.x;// - 1.08         1.04
    //    movement.y = 0f;
    //    movement.z = 0f;

    //    if (currentValue >= 1.04)
    //   {
    //        type = "DEC";
    //        Debug.Log("DEC : " + currentValue);

    //   } else if(currentValue <= -1.09)
    //   {
    //        type = "INC";
    //        Debug.Log("INC: " + currentValue);

    //    }

    //    if (type == "DEC")
    //    {
    //        movement.x = transform.position.x - 0.01f;
    //    } else
    //    {
    //        movement.x = transform.position.x + 0.01f;
    //    }

    //   transform.Translate(movement * Time.deltaTime);

    //    //Debug.Log(movement);
    //}
}
