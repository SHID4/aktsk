using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour {
	[SerializeField]
	private int hp = 2;
	[SerializeField]
	private PlayerDamage playerDamage;
	// Use this for initialization
	private SceneChanger sceneChanger;
	void Start () {
		sceneChanger = new SceneChanger();

		//ダメージを受けた時
		playerDamage.OnDamage +=() =>{
			hp--;
			Debug.Log("HP減少:" + hp);
		};
	}
	
	// Update is called once per frame
	void Update () {
		//ダメージじゃないけどここに書きます。。。
		// if(other.tag == "Finish"){
		// 	Debug.Log("gole!!");
		// 	SceneChanger.ChangeEnd();
		// }


	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Finish"){
			Debug.Log("gole!!");
			sceneChanger.ChangeEnd();
		
			}	
		}
}
