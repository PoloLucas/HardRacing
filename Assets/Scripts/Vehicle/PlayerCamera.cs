using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerCamera : MonoBehaviour{
    [SerializeField]private GameObject playerCamera;
    [SerializeField]private GameModeManager gameModeManager;
    [SerializeField]private VehicleData vehicle;

    void Awake(){
        if(gameModeManager.IsOnline){
            if(PhotonNetwork.LocalPlayer.ActorNumber == vehicle.Id){
                playerCamera.SetActive(true);
            }
        }else{
            playerCamera.SetActive(true);
        }
    }
}