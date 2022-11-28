using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovementManager : MonoBehaviour
{
    public float rot_speed;
    public float speed;
    public bool global = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.R))
            transform.Rotate(Vector3.up * rot_speed * Time.deltaTime);

        if (global)
        {
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

            if (Input.GetKey(KeyCode.Q))
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        if (global == false)
        {
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.Q))
                transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }


}