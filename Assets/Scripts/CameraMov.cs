using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float x;
    public float y;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Temporary vector
        Vector3 temp = player.transform.position;
        temp.x = temp.x - x;
        temp.y = y;
        temp.z = temp.z - z;
        // Assign value to Camera position
        transform.position = temp;
    }
}

