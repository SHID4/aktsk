using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour {

	// 親のポジションをこのオブジェクトのポジションにして，このオブジェクトのポジションは０にする
	void Update () {
		transform.parent.position = transform.position;
		transform.position = new Vector3 (0,0,0);
	}
}
