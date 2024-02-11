using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCounter : MonoBehaviour{
    [SerializeField]private TextMeshProUGUI counterText;
    private string counterGo = "¡YA!";
    private int counter;

    public void OnEnable(){
        StartCoroutine(StartRaceCounter());
    }
 
    public IEnumerator StartRaceCounter(){
        counter = 3;
        counterText.text = counter.ToString();
        yield return new WaitForSeconds(1f);
        counter = 2;
        counterText.text = counter.ToString();
        yield return new WaitForSeconds(1f);
        counter = 1;
        counterText.text = counter.ToString();
        yield return new WaitForSeconds(1f);
        counterText.text = counterGo;
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }
}