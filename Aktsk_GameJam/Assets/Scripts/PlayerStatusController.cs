using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour {
	[SerializeField]
	private int hp = 2;
	[SerializeField]
	private PlayerDamage playerDamage;
	// Use this for initialization
	void Start () {
		//ダメージを受けた時
		playerDamage.OnDamage +=() =>{
			hp--;
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
