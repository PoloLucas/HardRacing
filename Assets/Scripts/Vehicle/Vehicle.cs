using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour{
    [SerializeField]public VehicleData vehicleData;
    [SerializeField]public List<Wheel> wheels;
    private VehicleMovement movement;
    private InputType input;

    void Awake(){
        movement = GetComponent<VehicleMovement>();
        input = GetComponent<InputType>();
        input.id = vehicleData.Id-1;
    }

    void FixedUpdate(){
        if(vehicleData.Status == 1){ //Permite conducir si inició la carrera
            Move(input.yAxis);
            Turn(input.xAxis);
            RotateWheels(input.xAxis, input.yAxis);
        }
        SimulatedSpeed();
        SetTrackPosition();
    }

    //Permite mover el vehículo hacia adelante o detenerlo
    void Move(float yAxisValue){
        if(input.yAxis > 0){
            movement.Accelerate(yAxisValue, vehicleData.MaxSpeed, vehicleData.Acceleration);
        }else{
            movement.Brake(yAxisValue, vehicleData.BrakingForce);
        }
    }

    //Permite girar el vehículo hacia los lados
    void Turn(float xAxisValue){
        movement.Turn(xAxisValue, vehicleData.TurningSpeed);
    }

    //Da el efecto de que rotan las ruedas en el pavimento
    void RotateWheels(float xAxisValue, float yAxisValue){
        foreach(Wheel wheel in wheels){
            wheel.RotateWheel(xAxisValue, yAxisValue, movement.GetSpeed());
        }
    }

    //Crea un valor de velocidad ficticia de acuerdo a la velocidad real interna
    void SimulatedSpeed(){
        float simulatedSpeed = Mathf.Clamp(movement.GetSpeed(), 0, vehicleData.MaxSpeed-0.3f)*3;
        vehicleData.Speed = (int) simulatedSpeed;
    }

    //Actualiza el valor de la posición del jugador en la pista
    void SetTrackPosition(){
        vehicleData.TrackPosition = transform.position;
    }
}