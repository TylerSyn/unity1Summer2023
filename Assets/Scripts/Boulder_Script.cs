using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_Script : MonoBehaviour
{
    public Vector3 StartPos;
    Rigidbody rb;
    [Tooltip("Adjusts the thrust of the object")]
    [Range(0.0f,100.0f)]
    public float thrust = 10;
    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        //grab strat position
        StartPos = transform.position;
        // use GetComponent to assign RigidBody
        rb = GetComponent<Rigidbody>();
  
        rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            transform.position = StartPos;
            rb.velocity = Vector3.zero;// Vector3(0,0,0)
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerCapsule")
        {
            Reset_Boulder();
        }
    }

    void Reset_Boulder()
    {
        transform.position = StartPos;
        rb.velocity = Vector3.zero;// Vector3(0,0,0)
        score.AddScore();
    }
}
