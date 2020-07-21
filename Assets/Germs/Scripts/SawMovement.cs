using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool left;

    // Update is called once per frame
    void Update()
    {
        if (left) 
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
    }
}
