using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkConfig : MonoBehaviour{
    public delegate void ConnectingOnline();
    public delegate void DisconnectingOnline();
    public delegate void JoiningLobby();
    public delegate void LoadingLevel(string levelName);
    public static ConnectingOnline connectingOnline;
    public static DisconnectingOnline disconnectingOnline;
    public static JoiningLobby joiningLobby;
    public static LoadingLevel loadingLevel;

    public void ConnectToServer(){
        connectingOnline();
    }

    public void DisconnectToServer(){
        disconnectingOnline();
    }

    public void JoinLobby(){
        joiningLobby();
    }

    public void LoadLevel(string levelName){
        loadingLevel(levelName);
    }
}