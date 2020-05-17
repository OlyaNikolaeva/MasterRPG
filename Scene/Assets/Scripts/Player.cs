using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedMove;
    private Vector3 moveVector;
    public float x;
    public float y;
    // Use this for initialization
    void Start()
    {
        speedMove = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Dive");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
        }

        CharacterMove();
        CharacterController controller = GetComponent<CharacterController>();
        x = Input.GetAxis("Vertical");
        y = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y, 0), 0.2f);
        if (Input.GetKey(KeyCode.S))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y + 180, 0), 0.2f);
        if (Input.GetKey(KeyCode.A))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y - 90, 0), 0.2f);
        if (Input.GetKey(KeyCode.D))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y + 90, 0), 0.2f);
    }
    private void CharacterMove()
    {
        CharacterController controller = GetComponent<CharacterController>();
        moveVector = Vector3.zero; moveVector.x = Input.GetAxis("Horizontal") * speedMove;
        moveVector.z = Input.GetAxis("Vertical") * speedMove;
        controller.Move(moveVector * Time.deltaTime);
    }
    void FixedUpdate()
    {
        gameObject.GetComponent<Animator>().SetFloat("Speed", x, 0.1f, Time.deltaTime);
        gameObject.GetComponent<Animator>().SetFloat("Direction", y, 0.1f, Time.deltaTime);
    }
    public void Hit(float speedMuve)
    {
        // deliberately left empty
    }
}
