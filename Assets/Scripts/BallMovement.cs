using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float maxAcceleration;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        rb = GetComponent<Rigidbody>();
        gameController = FindObjectOfType<GameController>();
    }

    private void FixedUpdate()
    {
        Vector3 tilt = Input.acceleration;

        tilt = Quaternion.Euler(120, 0, 0) * tilt;

        if (rb.velocity.magnitude < maxSpeed)
            rb.AddForce(new Vector3(tilt.x, 0, tilt.z) * maxAcceleration * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ExitTile")
        {
            gameController.EndGame();
        }
    }
}
