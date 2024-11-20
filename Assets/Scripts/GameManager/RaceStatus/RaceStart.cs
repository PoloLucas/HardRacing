using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStart : MonoBehaviour{
    [SerializeField]private GameModeManager gameModeManager;
    [SerializeField]private GameObject startCounterUi;
    private int counter = 3;

    void Awake(){
        if(gameModeManager.IsOnline){ //Inicia el contador en momentos diferentes dependiendo del modo de juego
            InvokeRepeating("StartCounter", 3f, 1f);
        }else{
            InvokeRepeating("StartCounter", 1f, 1f);
        }
    }

    //Permite a los vehículos conducir cuando el contador de inicio finaliza
    public void StartCounter(){
        startCounterUi.SetActive(true);
        if(counter <= 0){
            foreach(VehicleData vehicle in gameModeManager.VehicleList){
                vehicle.Status = 1;
            }
            CancelInvoke();
        }
        counter--;
    }
}