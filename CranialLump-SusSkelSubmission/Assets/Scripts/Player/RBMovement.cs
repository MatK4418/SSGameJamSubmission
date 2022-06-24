using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBMovement : MonoBehaviour
{
    // Movement Variables 
    private float curSpeedX;
    private float curSpeedZ;
    public float maxSpeed;
    public float accelSpeed;
    public float haltSpeed;
    public Vector3 moveVelocity = Vector3.zero;
    public float jumpHeight;
    private bool jumpQueue;
    private Rigidbody rb;

    // Grounded Check Variables
    public Transform checkCapsuleTop;
    public Transform checkCapsuleBottom;
    public Transform closeToGround;
    public LayerMask walkableMask;
    private bool grounded;
    private bool nearGround;

    // Mouselook Variables
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    private float rotationX = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        // Grounded checks
        grounded = Physics.CheckCapsule(checkCapsuleTop.position, checkCapsuleBottom.position, 0.6f, walkableMask);
        nearGround = Physics.CheckCapsule(checkCapsuleTop.position, closeToGround.position, 0.6f, walkableMask);

        // Translate movement to rigidbody, but only on the ground.
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
    }

    void Update()
    {
        //// Walking Movement ////
        // We are grounded, so recalculate move direction based on axes

        Vector3 forward = transform.TransformDirection(Vector3.forward); // Changes local transforms for left and right directions into global,
        Vector3 right = transform.TransformDirection(Vector3.right);     // changing depending on player rotation.
        // (OBSOLETE CODE) float curSpeedX = maxSpeed * Input.GetAxis("Horizontal"); // THE INPUT.GETAXIS MULTIPLIER IS GIVING IT AN "ACCELERATION"-LIKE EFFECT BECAUSE IT RISES UP TO THE MAX VALUE OF 1 ON ITS OWN
        // (OBSOLETE CODE) float curSpeedZ = maxSpeed * Input.GetAxis("Vertical"); // THIS MAKES MOVEMENT SUPER CONTROLLABLE ON CONTROLLER BUT THIS ISNT REAL ACCELERATION AAAAAAAAAAAAAAA
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0 && (curSpeedX > -maxSpeed))
            {
                if (grounded)
                    curSpeedX -= accelSpeed;
                else
                    curSpeedX -= (0.2f * accelSpeed);
            }
            if (Input.GetAxis("Horizontal") > 0 && (curSpeedX < maxSpeed))
            {
                if (grounded)
                    curSpeedX += accelSpeed;
                else
                    curSpeedX += (0.2f * accelSpeed);
            }
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") < 0 && (curSpeedZ > -maxSpeed))
            {
                if (grounded)
                    curSpeedZ -= accelSpeed;
                else
                    curSpeedZ -= (0.2f * accelSpeed);
            }
            if (Input.GetAxis("Vertical") > 0 && (curSpeedZ < maxSpeed))
            {
                if (grounded)
                    curSpeedZ += accelSpeed;
                else
                    curSpeedZ += (0.2f * accelSpeed);
            }
        }

        // (OBSOLETE CODE) if (Input.GetAxis("Horizontal") == 0) // This wouldn't come into play instantly and as a result would feel incredibly awkward. I couldn't use a lesser than as it would likely 
        if (!Input.GetKey(KeyCode.D) & !(Input.GetKey(KeyCode.A)))
        {
            if (grounded)
                haltX();
        }
        if (!Input.GetKey(KeyCode.W) & !(Input.GetKey(KeyCode.S)))
        {
            if (grounded)
                haltZ();
        }
        moveVelocity = (forward * curSpeedZ) + (right * curSpeedX);

        //Debug.Log("curSpeedX = " + curSpeedX + ", curSpeedZ = " + curSpeedZ + ", AxisHorizontal = " + Input.GetAxis("Horizontal") + ", AxisVertical = " + Input.GetAxis("Vertical") + ", moveVelocity = " + moveVelocity);

        //// Jump Movement ////
        // Simple Jump
        if (Input.GetButtonDown("Jump"))
        {
            jumpQueue = true;
        }
        if (jumpQueue && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
            jumpQueue = false;
        }

        //// Mouselook ////
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    public void haltX() // Slows player horizontal momentum when requested.
    {
        if (curSpeedX != 0)
        {
            if (curSpeedX > haltSpeed) // Here, one unit of halting speed is used as the margin for error. Previously this was a static "1".
                curSpeedX -= haltSpeed;
            else if (curSpeedX < -haltSpeed) // Same as line 133.
                curSpeedX += haltSpeed;
            else
                curSpeedX = 0;
        }
    }
    public void haltZ() // Slows player diagonal momentum when requested.
    {
        if (curSpeedZ != 0)
        {
            if (curSpeedZ > haltSpeed)  // Same as line 133.
                curSpeedZ -= haltSpeed;
            else if (curSpeedZ < -haltSpeed)  // Same as line 133.
                curSpeedZ += haltSpeed;
            else
                curSpeedZ = 0;
        }
    }
}
