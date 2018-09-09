using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityChan;

public class RandomMatchmaker : MonoBehaviour
{
	public GameObject photonObjectHMD;
	public GameObject photonObjectHand;
	public GameObject photonObjectPlayer;
	private GameObject photonObject;

	private GameObject handParent;

	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");

		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
		{
			PhotonNetwork.playerName = "Windows";
			/*
			photonObject = photonObjectHMD.transform.Find("Controller (right)/Model").gameObject;
			// プレハブからインスタンスを生成
			GameObject obj = (GameObject)Instantiate(photonObjectHand, transform.position, Quaternion.identity);
			// 作成したオブジェクトを子として登録
			obj.transform.parent = photonObject.transform;
			//photonObject = photonObjectHand.GetComponent<GetChildHand>().rightHand;
			*/
			GameObject hmd  = (GameObject)Instantiate(photonObjectHMD, transform.position, Quaternion.identity);
			//GameObject hand = (GameObject)Instantiate(photonObjectHand, transform.position, Quaternion.identity);
			handParent = hmd.transform.Find("Controller (right)/Model").gameObject;
			//photonObject = hmd.transform.Find("Controller (right)/Model/Hand (1)").gameObject;
			photonObject = photonObjectHand;

			GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;

			print("Windows");
		}
		else
		{
			PhotonNetwork.playerName = "else";
			photonObject = photonObjectPlayer;
			print(Application.platform);
		}
	}

	private void Update()
	{
		UpdateMemberList();
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}

	void OnJoinedRoom()
	{
		GameObject hand =
			PhotonNetwork.Instantiate(
				photonObject.name,
				new Vector3(0f, 1f, 0f),
				Quaternion.identity, 0
			);

		GameObject mainCamera =
			GameObject.FindWithTag("MainCamera");
		//mainCamera.GetComponent<ThirdPersonCamera>().enabled = true;
		hand.transform.parent = handParent.transform;
		print("room joined");
	}

	// <summary>
	// リモートプレイヤーが入室した際にコールされる
	// </summary>
	public void OnPhotonPlayerConnected(PhotonPlayer player)
	{
		Debug.Log(player.name + " is joined.");
		UpdateMemberList();
	}

	// <summary>
	// リモートプレイヤーが退室した際にコールされる
	// </summary>
	public void OnPhotonPlayerDisconnected(PhotonPlayer player)
	{
		Debug.Log(player.name + " is left.");
		UpdateMemberList();
	}

	public void UpdateMemberList()
	{
		//joinedMembersText.text = "";
		foreach (var p in PhotonNetwork.playerList)
		{
			//joinedMembersText.text += p.name + "\n";
			print(p.name);
		}
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
}