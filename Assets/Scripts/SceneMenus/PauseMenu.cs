using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PauseMenu : MonoBehaviour{
    [SerializeField] private GameModeManager game;
    [SerializeField] private GameManager manager;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private List<GameObject> otherHUDElements = new List<GameObject>();
    [SerializeField] private Button restartButton;

    void Awake(){
        InputManager.pauseInput += PauseGame;

    }

    void OnDisable(){
        InputManager.pauseInput -= PauseGame;
    }

    public void PauseGame(){
        foreach(GameObject element in otherHUDElements){
            element.SetActive(false);
        }
        pauseMenu.SetActive(true);
        SetButtons();
    }

    public void ResumeGame(){
        foreach(GameObject element in otherHUDElements){
            element.SetActive(true);
        }
        pauseMenu.SetActive(false);
    }

    public void SetButtons(){
        if(game.IsOnline){
            restartButton.interactable = false;
        }else{
            restartButton.interactable = true;
        }
    }

    public void QuitOnlineGame(string sceneName){
        StartCoroutine(DisconnectAndQuit(sceneName));
    }

    public IEnumerator DisconnectAndQuit(string sceneName){
        if(game.IsOnline && !PhotonNetwork.IsMasterClient){
            manager.Network.DisconnectToServer();
            yield return new WaitForSeconds(0.5f);
            game.IsOnline = false;
        }
        manager.LoadScene(sceneName);
    }
}