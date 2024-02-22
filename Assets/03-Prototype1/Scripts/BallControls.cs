using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallControls : MonoBehaviour
{
    public float speed = 0;
    public float jumpForce = 5.0f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool ballIsOnGround = true;
    private int bottomY = -30;
    private Vector3 originalPOS;
    public bool goal = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        originalPOS = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        winTextObject.SetActive(false);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            goal = true;
        }
    }

    private void Update()
    {
       if(Input.GetButtonDown("Jump") && ballIsOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            ballIsOnGround = false;
        }

        if (transform.position.y < bottomY)
        {
            gameObject.transform.position = originalPOS;
        }

        if (goal == true)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            ballIsOnGround = true;
        }
    }

    void SetCountText()
    {
        // countText.text = "Count: " + count.ToString();

        
    }
}
