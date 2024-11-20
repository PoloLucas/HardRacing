using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class UsernameList : MonoBehaviour{
    [SerializeField]private List<TextMeshProUGUI> nameText = new List<TextMeshProUGUI>();

    void Awake(){
        InvokeRepeating("SetNickNameList", 0f, 0.1f);
    }

    //Actualiza los nombres de la lista de jugadores de la sala
    public void SetNickNameList(){
        for(int i = 0; i < nameText.Count; i++){
            if(PhotonNetwork.PlayerList.Length > i){
                nameText[i].text = PhotonNetwork.PlayerList[i].NickName;
            }else{
                nameText[i].text = null;
            }
        }
    }

    //Asigna el nomrbe del juador en línea
    public void SetNickName(TextMeshProUGUI name){
        if(name.text.Length-1 <= 12 && name.text.Length-1 > 0){
            PhotonNetwork.NickName = name.text;
        }
    }
}