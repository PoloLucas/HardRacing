using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStart : MonoBehaviour{
    [SerializeField]private Transform vehicles;
    private int counter = 3;

    void Awake(){
        InvokeRepeating("StartCounter", 1f, 1f);
    }

    void StartCounter(){
        if(counter <= 0){
            foreach(Transform child in vehicles){
                child.GetComponent<Vehicle>().enabled = true;
            }
            CancelInvoke();
        }
        counter--;
    }
}