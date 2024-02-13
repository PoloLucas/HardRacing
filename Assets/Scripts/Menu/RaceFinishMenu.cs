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
        if(gameModeManager.FinishingPlayers == gameModeManager.PlayerList.Count){
            if(gameModeManager.IsOnline){
                if(PhotonNetwork.IsMasterClient){
                    lobbyButton.SetActive(true);
                }
            }else{
                restartButton.SetActive(true);
                quitButton.SetActive(true);
            }
        }
    }
}