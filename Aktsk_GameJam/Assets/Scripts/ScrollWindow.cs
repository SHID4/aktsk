using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWindow : MonoBehaviour {


	[SerializeField]
	private float scrollSpeed = 2f;
	[SerializeField]
	private PlayerStatusController playerStatus;
	//どのY座標に再配置するか
	[SerializeField]
	private float startY = 0f;
	[SerializeField]
	private float endY = 0f;


	// Use this for initializatio n
	void Start () {
		playerStatus.OnDeath += ()=>{
			Vector3 targetPosition = new Vector3(transform.position.x, startY, transform.position.z);
			transform.position = Vector3.Lerp(transform.position,targetPosition, 1f);
		};
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= endY){
		Vector3 targetposition = new Vector3(transform.position.x, transform.position.y + scrollSpeed * Time.deltaTime, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetposition, 0.5f);
		}
	}
}
