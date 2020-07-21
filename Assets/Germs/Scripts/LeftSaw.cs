using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSaw : MonoBehaviour
{
    private float rotZ;
    public float RotationSpeed;

    // Update is called once per frame
    void Update()
    {
        rotZ += -Time.deltaTime * RotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "player")
        {
            Destroy(gameObject);
            other.GetComponent<SurvivalPlayer>().takeDamage(10);
        }
    }
}
