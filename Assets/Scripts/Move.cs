using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public ObjectController controller;
    public float Speed = 40f;

    bool Jump = false;
    float MoveDir = 0;

    Vector3 bepos = Vector3.zero;
    private void Update()
    {
        MoveDir = Input.GetAxisRaw("Horizontal");
        //float vetticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Jump"))
        {
            Jump = true;
        }
    }
    private void FixedUpdate()
    {
        controller.Move(MoveDir, Speed, Jump);
        GameObject background = GameObject.FindGameObjectWithTag("Background");


        if (background)
            background.GetComponent<Background>().MoveBackground((transform.position.x - bepos.x) * Time.fixedDeltaTime);
        bepos = transform.position;
        

        Jump = false;
    }
}
