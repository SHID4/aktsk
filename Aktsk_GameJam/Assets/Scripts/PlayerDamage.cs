using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

	
	public delegate void DamageHandler();
	public event DamageHandler OnDamage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//今はとりあえずスペースでダメージ減らします
		if (Input.GetKeyUp(KeyCode.Space)){
			OnDamage();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		// todo if(hand && grabbing) 
			// OnDamage();


	}


	public void run(){
		OnDamage();

	}
}
