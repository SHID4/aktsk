using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityChan;

public class RandomMatchmaker : MonoBehaviour {
	public GameObject photonObject;
	//[SerializeField]
	//Text joinedMembersText;

	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
		// 適当にニックネームを設定
		//PhotonNetwork.playerName = "guest" + UnityEngine.Random.Range(1000, 9999);

		if (Application.platform == RuntimePlatform.WindowsPlayer) {
			PhotonNetwork.playerName = "Windows";
			print ("Windows");
		}
		else  {
			PhotonNetwork.playerName = "else";
			print (Application.platform);
		}
		print ("now room member number" + PhotonNetwork.playerList.Length);
	}

	void Update()
	{
		// windowsPCからの接続と(WindowsMR接続済みと仮定する)，それ以外からの接続が2つ以上でルームに入る（ゲーム開始）
		if (this.inWindows() && PhotonNetwork.playerList.Length >= 2) {
			PhotonNetwork.JoinRandomRoom ();
		}

	}

	void OnJoinedLobby()
	{
		//PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}

	void OnJoinedRoom()
	{
		PhotonNetwork.Instantiate(
			photonObject.name,
			new Vector3(0f, 1f, 0f),
			Quaternion.identity, 0
		);

		GameObject mainCamera = 
			GameObject.FindWithTag("MainCamera");
		mainCamera.GetComponent<ThirdPersonCamera>().enabled = true;
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

	private bool inWindows()
	{
		// ロビーにWindowsからの接続があるかどうかを判定する
		foreach (var p in PhotonNetwork.playerList)
		{
			if (p.name.Equals ("")) {
				return true;
			}
		}
		return false;
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
}