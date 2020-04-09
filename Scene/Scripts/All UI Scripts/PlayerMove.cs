using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Vector3 movement;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");              // [1] -- we use GetAxisRaw to either of three state 
        float moveVertical = Input.GetAxisRaw("Vertical");                  //(-1, 0, 1) not in range of -1 to 1.

        //call function
        MovementFunction(moveHorizontal, moveVertical);
    }

    void MovementFunction(float moveHorizontal, float moveVertical)
    {

        movement.Set(moveHorizontal, 0.0f, moveVertical);                               //Assiging movement with x,z. Fixed y to restrict up/down
        movement = movement.normalized * speed * Time.deltaTime;   //[2] normalized was necessary because if you go in diagonal h+v will give 1.04		

        rb.MovePosition(transform.position + movement);                    //

    }
}
