using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConfig : MonoBehaviourPunCallbacks{
    public static PhotonConfig instance;
    public delegate void ConnectedToServer();
    public delegate void JoinedToLobby();
    public static ConnectedToServer connectedToServer;
    public static JoinedToLobby joinedToLobby;

    void Awake(){
        DontDestroyOnLoad(this);
        if(instance == null){
            instance = this;
            NetworkConfig.connectingOnline += ConnectToServer;
            NetworkConfig.disconnectingOnline += DisconnectToServer;
            NetworkConfig.joiningLobby += JoinLobby;
            NetworkConfig.loadingLevel += LoadLevel;
        }else{
            Destroy(gameObject);
        }
    }

    public void ConnectToServer(){
        if(!PhotonNetwork.IsConnected){
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster(){
        connectedToServer();
        Debug.Log("Conectado al Servidor");
    }

    public void DisconnectToServer(){
        PhotonNetwork.Disconnect();
        Debug.Log("Desconectado del Servidor");
    }

    public void JoinLobby(){
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){
        PhotonNetwork.JoinOrCreateRoom("Sala", new RoomOptions {MaxPlayers = 2}, TypedLobby.Default);
    }

    public override void OnJoinedRoom(){
        joinedToLobby();
        Debug.Log("Conectado al Lobby");
    }

    public void LoadLevel(string levelName){
        PhotonNetwork.LoadLevel(levelName);
        Debug.Log("Nivel cargado");
    }
}