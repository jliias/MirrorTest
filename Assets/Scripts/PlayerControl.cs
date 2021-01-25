using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // speed and turnSpeed are visible in inspector
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float turnSpeed = 50f;

    // variables for getting player input
    private float horizInput;
    private float vertInput;

    // variable for animator component
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Set animator component
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input using GetAxis
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        // Vertical input moves player forward and backward
        // Horizontal input rotates player over the y-axis
        transform.Translate(Vector3.forward * vertInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizInput * Time.deltaTime * turnSpeed);

        // Is player is moving -> tell animator to switch to walk animation
        float currSpeed = Mathf.Abs(vertInput) > 0.0f ? 1.0f : 0.0f;
        anim.SetFloat("speed", currSpeed);
    }
}
