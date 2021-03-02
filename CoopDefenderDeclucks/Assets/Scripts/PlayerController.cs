using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Gun gun;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Vector3 lookPoint;

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        lookPoint = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0f,Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
     
       
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay,out rayLength))
        {
           lookPoint = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(lookPoint.x,transform.position.y,lookPoint.z));
        }
       
    }
    //Consistant. Not based on frame rate.
    void FixedUpdate()
    {
        //myRigidbody.AddForce(moveVelocity);
        moveVelocity.y = myRigidbody.velocity.y;
        myRigidbody.velocity = moveVelocity;
        if (Input.GetMouseButton(0))
        {
            gun.shoot(lookPoint);
        }
    }
}
