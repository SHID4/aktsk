using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionControll : MonoBehaviour {

	private GameObject handForWindows;

	private void Start()
	{
		if(PhotonNetwork.playerName.Equals("Windows")){
			gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
			handForWindows = GameObject.Find("HandForWindows");
			handForWindows.transform.parent = transform.parent;
		}
	}
	
	void Update ()
	{
	/*
		transform.position = new Vector3(0, 0, 0);
		transform.rotation = Quaternion.identity;

		if (handForWindows != null)
		{
			handForWindows.transform.position = transform.localPosition;
			handForWindows.transform.rotation = transform.localRotation;

			var lot = handForWindows.transform.rotation;
			handForWindows.transform.rotation = new Quaternion(lot.x, lot.y, lot.z, lot.w * -1);

			// 反転
			//handForWindows.transform.position *= -1.0f;
			//float x = 1.0f - handForWindows.transform.rotation.x;
			/*
			float x = handForWindows.transform.rotation.x;
			float y = 1.0f - handForWindows.transform.rotation.y;
			float z = 1.0f - handForWindows.transform.rotation.z;
			*/
			//handForWindows.transform.rotation = new Quaternion(x, y, z, 0);
			//handForWindows.transform.RotateAroundLocal(Vector3.zero, );
		//}
		// コントローラーの位置をこのモデルの位置に代入する
		transform.position = transform.localPosition;
		transform.rotation = transform.localRotation;
		//print(transform.parent.transform.parent.name + " : " + transform.parent.transform.parent.position.z);

	}
}
