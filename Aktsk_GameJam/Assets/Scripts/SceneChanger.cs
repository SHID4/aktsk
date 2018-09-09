using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization



	 public void ChangeMainGame(){
		SceneManager.LoadScene("Main");
	}

	 public void ChangeSmartphoneController(){
		SceneManager.LoadScene("smartphone_character");
	}

	 public void ChangeStart(){
		SceneManager.LoadScene("Start");
	}


	 public void ChangeEnd(){
		SceneManager.LoadScene("End");

	}

	public void ChangeLose(){
		SceneManager.LoadScene("LOSE");

	}
}


