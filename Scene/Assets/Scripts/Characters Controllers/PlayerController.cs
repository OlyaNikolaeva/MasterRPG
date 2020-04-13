using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MoveController))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;	// Our current focus: Item, Enemy etc.
    MoveController moveController;
    //Transform characterTransform;
    Camera cam;         // Reference to our camera

    void Start()
    {
        cam = Camera.main; 
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

    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); // We create a ray
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)) // If the ray hits
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    // Set our focus to a new focus
    void SetFocus(Interactable newFocus)
    {
        // If our focus has changed
        if (newFocus != focus)
        {
            // Defocus the old one
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;   // Set our new focus
            //motor.FollowTarget(newFocus);   // Follow the new focus
        }

        newFocus.OnFocused(transform);
    }

    // Remove our current focus
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        //motor.StopFollowingTarget();
    }
}
