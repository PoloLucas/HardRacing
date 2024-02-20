using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour{
    private Rigidbody body;
    private float bodySpeed;

    void Awake(){
        body = GetComponent<Rigidbody>();
    }

    //Obtiene la velocidad real del Rigidbody
    public float GetSpeed(){
        bodySpeed = transform.InverseTransformDirection(body.velocity).z;
        return bodySpeed;
    }

    //Aumenta la fuerza aplicada hacia el frente hasta alcanzar una velocidad máxima
    public void Accelerate(float yAxis, float maxSpeed, float acceleration){
        if(bodySpeed - 0.2f < maxSpeed){
            body.AddRelativeForce(Vector3.forward*yAxis*acceleration, ForceMode.Force);
        }
    }

    //Aplica fuerza hacia atrás hasta detener el movimiento
    public void Brake(float yAxis, float brakingForce){
        if(bodySpeed > 0){
            body.AddRelativeForce(Vector3.forward*yAxis*brakingForce, ForceMode.Force);
        }
    }

    //Rota el cuerpo del vehículo hacia la izquierda o derecha
    public void Turn(float turn, float turningSpeed){
        Vector3 turningRotation = new Vector3(0, turn*turningSpeed, 0);
        Quaternion rotation = Quaternion.Euler(turningRotation*Time.deltaTime);
        body.MoveRotation(body.rotation*rotation);
    }
}