using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartphoneCharacterController : MonoBehaviour {

	//　レイを飛ばす距離
	private float rayRange = 100f;
	//　移動する位置
	private Vector3 targetPosition;
	//　速度
	private Vector3 velocity;
	//　移動スピード
	[SerializeField]
	private float moveSpeed = 1.0f;
	//　マウスクリックで移動する位置を決定するかどうか
	[SerializeField]
	private bool mouseDownMode = true;
	

	//移動制限
	[SerializeField]
	private float restrictRight;
	[SerializeField]	
	private float restrictLeft;
	[SerializeField]
	private float restrictUp;

	[SerializeField]	
	private float restrictDown;

	[SerializeField]
	RangeRestricter rangeRestricter;
	private float startTime;
	private float journeyLength = 0.1f;
	float distCovered;
	float fracJourney;
	[SerializeField]
	private PlayerStatusController playerStatus;
	[SerializeField]
	private Transform respawnTransform;

	void Start () {
		// characterController = GetComponent<CharacterController>();
		// animator = GetComponent<Animator>();
		startTime = Time.time;
		rangeRestricter = GetComponent<RangeRestricter>();
		targetPosition = transform.position;
		velocity = Vector3.zero;
		
		//死亡したときの処理
		playerStatus.OnDeath += ()=> {
			playerStatus.hp = 2;
			transform.position = respawnTransform.position;
			targetPosition = transform.position;
			};
		}
 
	void Update () {
		//　マウスクリックまたはmouseDownModeがOffの時マウスの位置を移動する位置にする
		if(Input.GetButton("Fire1") || !mouseDownMode) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			//Fieldタグ(壁？、崖？にレイを飛ばしてあたった場所へ移動させる))
			if(Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask ("Field"))) {
				targetPosition = hit.point;
				journeyLength = Vector3.Distance(transform.position, targetPosition);
				 distCovered = Time.deltaTime * moveSpeed;
				 fracJourney = distCovered / journeyLength;

			}
		}

		// Debug.Log(rangeRestricter.GetScreenBottomRight());
			// Debug.Log("length =" + journeyLength);
			// Debug.Log("fracJourney =" + fracJourney);

		// if(IsMove())
			Debug.Log(fracJourney);
			transform.position = Vector3.Lerp(transform.position,targetPosition,fracJourney);

		
	}


	//移動できるかどうかを判定
	private bool IsMove(){
		// if(rangeRestricter.GetScreenBottomRight().x <= transform.position.x)
			return false;
	}
}
 

