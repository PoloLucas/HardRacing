using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class OnlineLobby : MonoBehaviour{
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject waitingPlayersText;
    [SerializeField] private GameObject waitingHostText;

    void Start(){
        PhotonNetwork.AutomaticallySyncScene = true; //Activa la sincronización de escenas con el servidor
        InvokeRepeating("CheckPlayerCount", 0f, 0.1f);
    }

    //Muestra el botón que permite al dueño de la sala iniciar la carrera si hay 2 o más jugadores en la sala
    public void CheckPlayerCount(){
        if(PhotonNetwork.IsMasterClient){
            if(PhotonNetwork.PlayerList.Length >= 2){
                startButton.interactable = true;
                waitingPlayersText.SetActive(false);
            }else{
                startButton.interactable = false;
                waitingPlayersText.SetActive(true);
            }
            waitingHostText.SetActive(false);
        }else{
            startButton.interactable = false;
            waitingPlayersText.SetActive(false);
            waitingHostText.SetActive(true);
        }
    }
}