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

    public float timeSlowAmount;//Duration of Time Slow Powerup
    private float timeSlowTimer;
    public bool isTimeSlowed;
    
    public float spreggShotAmount;//Duration of Spregg Shot Powerup
    private float spreggShotTimer;
    public bool isSpregg;

    public float rapidFireAmount;//Duration of Rapid Fire Powerup
    private float rapidFireTimer;
    public bool isRapidFire;

    public MainMenu gameManager;
    public GameObject Talent_Tree;

    public int grenadeCount;//How many egg grenades you have
    public float fireRateMod;
    public float bulletSpeedMod;
   

    public GameObject grenadeType;
    // Start is called before the first frame update
    void Start()
    {
        timeSlowTimer = 0;
        spreggShotTimer = 0;
        rapidFireTimer = 0;
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        lookPoint = transform.forward;
        gameManager = FindObjectOfType<MainMenu>();
        grenadeCount = 3;
      
        fireRateMod = 1;
        bulletSpeedMod = 1;
    }

    // Update is called once per frame
    void Update()
    {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * moveSpeed;

            #region Code for Power-Up Timers
            if (timeSlowTimer > 0)//Checks to see if time slow power up is active
            {
                timeSlowTimer -= Time.deltaTime / Time.timeScale;
                if (timeSlowTimer <= 0)//Return time scale to normal after elapsed power-up time
                {
                    timeSlowTimer = 0;
                    isTimeSlowed = false;
                    Time.timeScale = 1;
                    Time.fixedDeltaTime = Time.timeScale * 0.02f;
                }
            }
            if (spreggShotTimer > 0)
            {
                spreggShotTimer -= Time.deltaTime / Time.timeScale;
                if (spreggShotTimer <= 0)
                {
                    spreggShotTimer = 0;
                    isSpregg = false;
                }

            }
            if (rapidFireTimer > 0)
            {
                rapidFireTimer -= Time.deltaTime / Time.timeScale;
                if (rapidFireTimer <= 0)
                {
                    rapidFireTimer = 0;
                    isRapidFire = false;
                }
            }
            #endregion
     
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
           float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                lookPoint = cameraRay.GetPoint(rayLength);

                transform.LookAt(new Vector3(lookPoint.x, transform.position.y, lookPoint.z));
            }
        
        if (Input.GetMouseButton(0))
        {
            if (gun != null)
                gun.shoot(lookPoint);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grenadeCount > 0)
            {
                eggxplosion();
                grenadeCount--;
            }

        }
        if (Input.GetKeyDown(KeyCode.Tab) && Talent_Tree.activeSelf == false)
        {
            Talent_Tree.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && Talent_Tree.activeSelf == true)
        {
            Talent_Tree.SetActive(false);
        }
            
        
    }
    //Consistant. Not based on frame rate.
    void FixedUpdate()
    {
        //myRigidbody.AddForce(moveVelocity);
        moveVelocity.y = myRigidbody.velocity.y;
        myRigidbody.velocity = moveVelocity;
        

      
    }
    void eggxplosion()
    {
        GameObject grenade = Instantiate(grenadeType, this.transform.position, this.transform.rotation);
        //grenade.gameObject.transform.position = this.gameObject.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        string otherTag = other.tag;//Tag of object that player collided with
        switch (otherTag)//Switch statement checks if player collided with a power-up based on tag
        {
            case "TimeSlow":
                isTimeSlowed = true;
                timeSlowTimer += timeSlowAmount;
                Time.timeScale = 0.5f;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
                Destroy(other.gameObject);
                break;
            case "SpreggShot":
                isSpregg = true;
                spreggShotTimer += spreggShotAmount;
                Destroy(other.gameObject);
                break;
            case "RapidFire":
                isRapidFire = true;
                rapidFireTimer += rapidFireAmount;
                Destroy(other.gameObject);
                break;
        }
    }

}
