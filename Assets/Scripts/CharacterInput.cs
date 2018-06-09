using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterInput : MonoBehaviour
{

    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

    public bool canJump = false;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.Move(Vector3.zero);
    }
    void Update()
    {
        
        //if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (canJump && Input.GetButtonDown("Jump"))
                moveDirection.y = jumpSpeed;

        }
        if (canJump)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        if ((Mathf.Abs(moveDirection.x) > 0 || Mathf.Abs(moveDirection.y) > 0) && selection != null)
        {
            selection.Deselect();
            selection = null;
        }
        Vector3 prevPos = transform.localPosition;
        controller.Move(moveDirection * Time.deltaTime);

        if (!canJump && prevPos.y != transform.localPosition.y)
        {
            transform.localPosition = prevPos;
        }

       
        if (selection != null && Input.GetButtonDown("Fire1"))
        {
            selection.Interact();
        }
    }
    

    public float pushPower = 2.0F;
    IInteractable selection = null;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Debug.Log("collision!");
        //pushing
        {
            Rigidbody body = hit.collider.attachedRigidbody;
            if (body == null || body.isKinematic)
            {
            }
            else if (hit.moveDirection.y < -0.3F)
            { }
            else
            {
                Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
                body.velocity = pushDir * pushPower;
            }
        }
        //interactable
        {
            IInteractable interactable = hit.gameObject.GetComponent<IInteractable>();
            if (interactable != null)
            {
                Debug.Log("interactable!");
                if (selection != null)
                {
                    selection.Deselect();
                }
                selection = interactable;
                selection.Select();
            }
        }
    }
}
