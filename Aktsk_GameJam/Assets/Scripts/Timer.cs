using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {


	private float timeCount;
	private int sec = 0;
	private int min = 0;
	public string timeString;

	private Text targetText; // <---- 追加2
	private SceneChanger sceneChange;
	// Use this for initialization
	void Start () {
		sceneChange = new SceneChanger();
		TimerSet(60);
		targetText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log(timeString);
		targetText.text = timeString;
	}

	public void TimerSet(float time){
		timeCount = time; 
        StartCoroutine(TimerStart()); 
	}

	 IEnumerator TimerStart() 
    { 
        while (timeCount > 0) { 
            int sec = Mathf.FloorToInt(timeCount % 60); 
            int min = Mathf.FloorToInt((timeCount - sec)/ 60); 

			if(sec >= 10)
				timeString = min.ToString() + ":" + sec.ToString();
			else
				timeString = min.ToString() + ":0" + sec.ToString();

            yield return new WaitForSeconds(1.0f); 
            timeCount -= 1.0f; 
        }
		
		sceneChange.ChangeLose();

    } 
}
