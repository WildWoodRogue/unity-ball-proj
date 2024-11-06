using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    Rigidbody rb;
    public float jumpForce;
    bool onGround = false;
    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey("d")){
            transform.Rotate(new Vector3(0,rotateSpeed*Time.deltaTime,0));
        }
        if  (Input.GetKey("a")){
            transform.Rotate(new Vector3(0,-rotateSpeed*Time.deltaTime,0));
        }
        if (Input.GetKey("w")){
            rb.MovePosition(transform.position + transform.forward *speed* Time.deltaTime);
        }
        if (Input.GetKey("s")){
            rb.MovePosition(transform.position + transform.forward *-speed* Time.deltaTime);
        }
        if (Input.GetKey("space") && onGround==true){
            rb.AddForce(transform.up * jumpForce*Time.deltaTime, ForceMode.Impulse);

        }

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor"){
            onGround = true;
            Debug.Log(123);
        }
    }
     void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor"){
            onGround = false;
        }    
    }
}
