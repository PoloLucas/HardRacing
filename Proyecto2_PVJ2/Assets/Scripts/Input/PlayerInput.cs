using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputType{
    void Update(){
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
    }
}