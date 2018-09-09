using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWindow : MonoBehaviour {


	[SerializeField]
	private float scrollSpeed = 2f;
	[SerializeField]
	private PlayerStatusController playerStatus;
	[SerializeField]
	private float startY = 0f;


	// Use this for initialization
	void Start () {
		playerStatus.OnDeath += ()=>{
			Vector3 targetPosition = new Vector3(transform.position.x, startY, transform.position.z);
			transform.position = Vector3.Lerp(transform.position,targetPosition,0.01f);
		};
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(transform.position.x, transform.position.y + scrollSpeed * Time.deltaTime, transform.position.z);
		
	}
}
