using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour{
    private Rigidbody body;
    public float speed;
    public float maxSpeed = 35;
    public float acceleration = 2;
    public float brakingForce = 3;
    public float turningSpeed = 20;

    void Awake(){
        speed = 0;
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        GetSpeed();
    }

    public void GetSpeed(){
        speed = transform.InverseTransformDirection(body.velocity).z;
        //Debug.Log(speed);
    }

    public void Accelerate(float yAxis){
        if(speed < maxSpeed){
            body.AddRelativeForce(Vector3.forward*yAxis*acceleration, ForceMode.Force);
        }
    }

    public void Brake(float yAxis){
        if(speed > 0){
            body.AddRelativeForce(Vector3.forward*yAxis*brakingForce, ForceMode.Force);
        }
    }

    public void Turn(float turn){
        Vector3 turningRotation = new Vector3(0, turn*turningSpeed, 0);
        Quaternion rotation = Quaternion.Euler(turningRotation*Time.deltaTime);
        body.MoveRotation(body.rotation*rotation);
    }
}