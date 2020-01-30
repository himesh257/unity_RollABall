using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
	private float time = 120.0f;
	public Text timeText;

    void Update()
    {
    	if(time > 0){
	    	time -= Time.deltaTime;
	        timeText.text = "" + ((int)time).ToString();
	    } else if(time == 0){
	    	Application.LoadLevel(0);
	    }
    }

    
}
