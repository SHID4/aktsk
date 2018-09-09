using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionControll : MonoBehaviour {

	void Update () {
		transform.localPosition = transform.parent.transform.parent.transform.localPosition;
		//print(transform.parent.transform.parent.name + " : " + transform.parent.transform.parent.position.z);
	/*
		if(PhotonNetwork.playerName.Equals("Windows")){
			
		}
		*/
	}
}
