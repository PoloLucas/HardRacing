using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour{
    private TrackCheckpoints trackCheckpoints;

    //Envía la información del vehículo que atravesó el checkpoint para analizar si es válido
    private void OnTriggerEnter(Collider other){
        if(other.GetComponent<Vehicle>()){
            trackCheckpoints.PassedCheckpoint(this, other.GetComponent<Vehicle>().vehicleData);
        }
    }

    //Le asigna a cada checkpoint el lugar donde debe enviar datos
    public void SetCheckpoint(TrackCheckpoints trackCheckpoints){
        this.trackCheckpoints = trackCheckpoints;
    }
}