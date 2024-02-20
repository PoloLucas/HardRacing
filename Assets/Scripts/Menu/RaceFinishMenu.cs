using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RaceFinishMenu : MonoBehaviour{
    [SerializeField]private GameModeManager gameModeManager;
    [SerializeField]private GameObject restartButton;
    [SerializeField]private GameObject quitButton;
    [SerializeField]private GameObject lobbyButton;

    void Awake(){
        //FinishLine.raceFinish += DisplayButtons;
    }

    public void Update(){
        gameModeManager.SetFinishingPlayers();
        if(gameModeManager.FinishingPlayers == gameModeManager.PlayerList.Count){ //Averigua si todos los vehículos de jugador terminaron la carrera
            if(gameModeManager.IsOnline){ //Cambia los botones que aparecen en solitario y en línea
                if(PhotonNetwork.IsMasterClient){ //Permite al dueño de la sala regresar a esta
                    lobbyButton.SetActive(true);
                }
            }else{
                restartButton.SetActive(true);
                quitButton.SetActive(true);
            }
        }
    }
}