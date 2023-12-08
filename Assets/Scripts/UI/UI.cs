using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour{
    [SerializeField]private GameObject finishPanel;
    [SerializeField]private TextMeshProUGUI positionText;
    private Vehicle player;

    void Awake(){
        player = GameObject.FindWithTag("Player").GetComponent<Vehicle>();
        FinishLine.raceFinish += TurnOnFinishPanel;
    }

    public void TurnOnFinishPanel(){
        if(!player.enabled){
            positionText.text = player.position + ".°";
            finishPanel.SetActive(true);
        }
    }
}