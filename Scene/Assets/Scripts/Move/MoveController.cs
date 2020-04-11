using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class MoveController : MonoBehaviour
{
    //public float speed = 0.3f;
    public float jumpFoce = 1f;
    public float flyForce = 0.5f;

    public int speed = 5;
    public int speedRot = 3;

    private Rigidbody rb;
    private CapsuleCollider cCollider;

    private Transform playerTransform;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cCollider = GetComponent<CapsuleCollider>();

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;

        playerTransform = this.transform;
    }

    public void CharacterMove()
    {
        if (Input.GetKey(KeyCode.W))
            playerTransform.position += playerTransform.transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            playerTransform.transform.position -= playerTransform.transform.forward * speed * Time.deltaTime;
    }

    public void CharacterRot()
    {
        if (Input.GetKey(KeyCode.A))
            playerTransform.Rotate(Vector3.down * speedRot);
        if (Input.GetKey(KeyCode.D))
            playerTransform.Rotate(Vector3.up * speedRot);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpFoce, ForceMode.Impulse);
    }

    public void Fly()
    {
        //если высота прыжка > 4f или нет под землей ног;
        if (Input.GetKey(KeyCode.RightShift))
            rb.AddForce(Vector3.up * flyForce, ForceMode.Impulse);
    }

    public void FollowTarget()
    {
        //преследование цели
    }
}
