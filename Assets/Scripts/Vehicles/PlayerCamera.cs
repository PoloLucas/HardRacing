using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerCamera : MonoBehaviour{
    [SerializeField]private GameObject playerCamera;
    [SerializeField]private GameModeManager gameModeManager;
    private PhotonView photonView;

    void Awake(){
        photonView = GetComponent<PhotonView>();
        if(gameModeManager.IsOnline){
            if(photonView.IsMine){ //Activa la cámara del vehículo jugador para el jugador que lo instanció
                playerCamera.SetActive(true);
            }
        }else{
            playerCamera.SetActive(true);
        }
    }
}