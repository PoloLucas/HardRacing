using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCounter : MonoBehaviour{
    [SerializeField]private TextMeshProUGUI counterText;
    private int counter = 3;

    void Awake(){
        InvokeRepeating("StartCounterUI", 1f, 1f);
    }

    void StartCounterUI(){
        counterText.text = counter.ToString();
        switch(counter){
            case 3:{
                gameObject.SetActive(true);
                break;
            }
            case 0:{
                counterText.text = "¡YA!";
                break;
            }
            case -1:{
                gameObject.SetActive(false);
                CancelInvoke();
                break;
            }
        }
        counter--;
    }
}