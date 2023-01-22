using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        //deplacer le player
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");


        animator.SetFloat("ver_input", verInput);
        animator.SetFloat("hor_input", horInput);
        rb.velocity = new Vector3(horInput, 0, verInput).normalized * speed;

        LookAtMouse();


    }

    void LookAtMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);


        }


    }
}
