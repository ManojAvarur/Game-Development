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
}
