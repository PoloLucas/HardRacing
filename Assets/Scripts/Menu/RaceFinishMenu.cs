using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                lobbyButton.SetActive(true);
            }else{
                restartButton.SetActive(true);
                quitButton.SetActive(true);
            }
        }
    }
}