using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public int maxhealth = 1;
     int currenthealth;
    public int collctedcoins = 0;
    GameManager gameManager;
    Rigidbody rb;
    public float movespeed = 5.0f;
    public float jumpforce = 7.0f;
    private Camera maincamera;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

   
        rb = GetComponent<Rigidbody>();
        maincamera = Camera.main;
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        movment();
        jump();

    }


    public void movment() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraforward = maincamera.transform.forward;
        Vector3 cameraright = maincamera.transform.right;

        cameraforward.y = 0;
        cameraright.y = 0;

        Vector3 movedirection = cameraforward.normalized * verticalInput + cameraright.normalized * horizontalInput;

        if (movedirection != Vector3.zero)
        {
            // to change rotation
            transform.forward = movedirection;
            // to move the character
            transform.position += movedirection * movespeed * Time.deltaTime;
        }
    }

    public void jump() 
    {
        if (Input.GetButtonDown("Jump")) 
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("damage")) 
        {
            Vector3 damageDirection = other.transform.position - transform.position;
            damageDirection.Normalize();
            rb.AddForce(-damageDirection *2f ,ForceMode.Impulse);
            currenthealth -= 1;
            if (currenthealth <= 0) 
            { 
                gameManager.Restart(); 
            }

            gameManager.UpdateHealthText(currenthealth, maxhealth);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            
            collctedcoins += 1;
            gameManager.UpdateCoinText(collctedcoins);
            Destroy(other.gameObject);
        }
    }
}
