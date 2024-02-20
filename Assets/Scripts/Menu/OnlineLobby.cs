using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OnlineLobby : MonoBehaviour{
    [SerializeField]private GameObject startButton;

    void Start(){
        PhotonNetwork.AutomaticallySyncScene = true; //Activa la sincronización de escenas con el servidor
        InvokeRepeating("CheckPlayerCount", 0f, 0.5f);
    }

    //Muestra el botón que permite al dueño de la sala iniciar la carrera si hay 2 o más jugadores en la sala
    public void CheckPlayerCount(){
        if(PhotonNetwork.PlayerList.Length >= 2 && PhotonNetwork.IsMasterClient){
            startButton.SetActive(true);
        }else{
            startButton.SetActive(false);
        }
    }
}