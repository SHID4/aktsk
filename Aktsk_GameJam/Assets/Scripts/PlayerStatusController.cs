using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour {
	[SerializeField]
	public int hp = 2;
	[SerializeField]
	private PlayerDamage playerDamage;
	// Use this for initialization
	private SceneChanger sceneChanger;
	public delegate void DeathHandler();
	public event DeathHandler OnDeath;
	
	//↓無敵時間実装用
	private float nowTime = 0f;
	private float damageTime = 0f;
	private bool isInvincible = false;
	[SerializeField]
	private Renderer renderer_;
	private int count;
	void Start () {

		sceneChanger = new SceneChanger();
		nowTime = Time.time;

		//ダメージを受けた時
		playerDamage.OnDamage +=() =>{
			
			//無敵時間中はhpを減らさない
			if(!isInvincible){
				hp--;
				damageTime = Time.time;
				Debug.Log("HP減少:" + hp);
				isInvincible = true;

			}
			
			
			



			//Hpが0になったら死亡イベント発生
			if(hp <= 0){
				OnDeath();
			}

		};
	}
	
	// Update is called once per frame
	void Update () {
		//ダメージじゃないけどここに書きます。。。
		// if(other.tag == "Finish"){
		// 	Debug.Log("gole!!");
		// 	SceneChanger.ChangeEnd();
		// }
		if(isInvincible && count == 0){
			StartCoroutine("Invincible",0.2f);
		}

		// Debug.Log(isInvincible);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Finish"){
			Debug.Log("gole!!");
			sceneChanger.ChangeEnd();
		
			}	
		}


// private void Invincible(float interval){
// 	if ( Time.time > nowTime ) {
// 			renderer_.enabled = !renderer_.enabled;
// 			nowTime += interval;
// 		}
// 	}


	IEnumerator Invincible(float interval) {
		while(count < 15){
            renderer_.enabled = !renderer_.enabled;
			count++;

			if(count >= 15){
				if(!renderer_.isVisible)
					renderer_.enabled = true;
				count = 0;
				isInvincible = false;
				break;
			}
            yield return new WaitForSeconds(interval);
		}
		if(!renderer_.isVisible)
			renderer_.enabled = true;
		count = 0;
		isInvincible = false;
	}
}



