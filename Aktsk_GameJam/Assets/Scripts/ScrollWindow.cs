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
	private bool isRespawn = false;


	// Use this for initializatio n
	void Start () {
		playerStatus.OnDeath += ()=>{
			isRespawn = true;
			Vector3 targetPosition = new Vector3(transform.position.x, startY, transform.position.z);
			transform.position = Vector3.Lerp(transform.position,targetPosition, 1f);
		};
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 targetposition = new Vector3(transform.position.x, transform.position.y + scrollSpeed * Time.deltaTime, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetposition, 0.5f);
	}
}
