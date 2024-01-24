using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// TODO: import UnityEngine.InputSystem and UnityEngine.SceneManagement


public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 originalScale;
    bool flat = false;
    [SerializeField] float speed = 5f; //now we can see and edit this value inside unity
    [SerializeField] float jumpHeight = 5f;
    // TODO: add component references
    


    // TODO: add variables for speed, jumpHeight, and respawnHeight

    // TODO: add variable to check if we're on the ground


    // Start is called before the first frame update
    void Start()
    {
        // TODO: Get references to the components attached to the current GameObject
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: check if player is under respawnHeight and call Respawn()

    }

    void OnJump()
    {
        // TODO: check if player is on the ground, and call Jump()
        Jump();
    }

    private void Jump()
    {
        // TODO: Set the y velocity to some positive value while keeping the x and z whatever they were originally
        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
    }

    void OnMove(InputValue moveVal)
    {
        //TODO: store input as a 2D vector and call Move()
        Vector2 direction = moveVal.Get<Vector2>(); 
        Debug.Log(direction);
        Move(direction.x, direction.y);
    }

    private void Move(float x, float z)
    {
        // TODO: Set the x & z velocity of the Rigidbody to correspond with our inputs while keeping the y velocity what it originally is.
        rb.velocity = new Vector3(x * speed, rb.velocity.y, z * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        // This function is commonly useful, but for our current implementation we don't need it

    }

    void OnCollisionStay(Collision collision)
    {
        // TODO: Check if we are in contact with the ground. If we are, note that we are grounded

    }

    void OnCollisionExit(Collision collision)
    {
        // TODO: When we leave the ground, we are no longer grounded

    }

    private void Respawn()
    {
        // TODO: reload current scene
        
    }

    void OnFlatten() {
        flat = !flat;
        if (flat) {
            Flatten();
        } else {
            Unflatten();
        }
    }

    private void Flatten() {
        transform.localScale = new Vector3((float)originalScale.x *2f, (float)originalScale.y * .5f, (float)originalScale.z * 2f);
    }
    private void Unflatten() {
        transform.localScale = new Vector3((float)originalScale.x, (float)originalScale.y, (float)originalScale.z);
    }
}
