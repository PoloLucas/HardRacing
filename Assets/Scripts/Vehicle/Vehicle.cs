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
        if(vehicleData.Status == 1){
            Move(input.yAxis);
            Turn(input.xAxis);
            RotateWheels(input.xAxis, input.yAxis);
        }
        SimulatedSpeed();
        SetTrackPosition();
    }

    void Move(float yAxisValue){
        if(input.yAxis > 0){
            movement.Accelerate(yAxisValue, vehicleData.MaxSpeed, vehicleData.Acceleration);
        }else{
            movement.Brake(yAxisValue, vehicleData.BrakingForce);
        }
    }

    void Turn(float xAxisValue){
        movement.Turn(xAxisValue, vehicleData.TurningSpeed);
    }

    void RotateWheels(float xAxisValue, float yAxisValue){
        foreach(Wheel wheel in wheels){
            wheel.RotateWheel(xAxisValue, yAxisValue, movement.GetSpeed());
        }
    }

    void SimulatedSpeed(){
        float simulatedSpeed = Mathf.Clamp(movement.GetSpeed(), 0, vehicleData.MaxSpeed-0.3f)*3;
        vehicleData.Speed = (int) simulatedSpeed;
    }

    void SetTrackPosition(){
        vehicleData.TrackPosition = transform.position;
    }
}