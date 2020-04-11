using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class PlayerController : MonoBehaviour
{
    MoveController moveController;
    //Transform characterTransform;
    void Start()
    {
        moveController = GetComponent<MoveController>();
        //characterTransform = this.transform;
    }

    private void FixedUpdate()
    {
        moveController.CharacterMove();
        moveController.CharacterRot();
        moveController.Jump();
        moveController.Fly();
    }
}
