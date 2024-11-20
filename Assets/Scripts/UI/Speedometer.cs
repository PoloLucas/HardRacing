using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour{
    //[SerializeField] private VehicleData vehicle;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private Transform needle;
    [SerializeField] private int speed; public int Speed{set => speed = value;}
    [SerializeField] private float maxSpeed; public float MaxSpeed{set => maxSpeed = value;}
    [SerializeField] private float minNeedlePosition;
    [SerializeField] private float maxNeedlePosition;

    void Update(){
        UpdateText();
        MoveTachNeedle();
    }

    void UpdateText(){
        speedText.text = speed.ToString();
    }

    void MoveTachNeedle(){
        float angle = Mathf.Lerp(minNeedlePosition, maxNeedlePosition, (float)speed / maxSpeed);
        needle.rotation = Quaternion.Euler(0, 0, angle);
    }
}