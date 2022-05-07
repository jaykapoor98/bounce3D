using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 0.2f;
    public float gravityValue = -9.81f;
    private Collider m_ObjectCollider;
    private Debug debug;
    private bool isGrounded;

    private bool GroundCheck () {
        m_ObjectCollider = GetComponent<Collider>();
        RaycastHit hit;
        // Debug.DrawRay(m_ObjectCollider.bounds.center, (Vector3.down * m_ObjectCollider.bounds.extents.y), Color.green);
        if (Physics.Raycast(m_ObjectCollider.bounds.center, Vector3.down, (m_ObjectCollider.bounds.extents.y) + 0.6f)) {
            isGrounded = true; 

        } else {
            isGrounded = false;
        }
        return isGrounded;
    }

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        controller.enabled = true;
    }

    void Update()
    {
        isGrounded = GroundCheck();
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

        }
        if(playerVelocity.y == 0 && isGrounded == false){
            gravityValue *= 2;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
