using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour{
    private TrackCheckpoints trackCheckpoints;

    private void OnTriggerEnter(Collider other){
        if(other.GetComponent<Vehicle>()){
            trackCheckpoints.PassedCheckpoint(this, other.transform);
        }
    }

    public void SetCheckpoint(TrackCheckpoints trackCheckpoints){
        this.trackCheckpoints = trackCheckpoints;
    }
}