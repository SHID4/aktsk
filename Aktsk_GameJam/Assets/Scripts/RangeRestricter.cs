using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeRestricter : MonoBehaviour {

	private Camera _mainCamera;

void Start () {
    // カメラオブジェクトを取得します
    GameObject obj = GameObject.Find ("Main Camera");
    _mainCamera = obj.GetComponent<Camera> ();

    // 座標値を出力
    Debug.Log (GetScreenTopLeft ().x + ", " + GetScreenTopLeft ().y);
    Debug.Log (GetScreenBottomRight ().x + ", " + GetScreenBottomRight ().y);
}


public Vector3 GetScreenTopLeft() {
    // 画面の左上を取得
    Vector3 topLeft = _mainCamera.ScreenToWorldPoint (Vector3.zero);
    // 上下反転させる
    topLeft.Scale(new Vector3(1f, -1f, 1f));
    return topLeft;
}

public Vector3 GetScreenBottomRight() {
    // 画面の右下を取得
    Vector3 bottomRight = _mainCamera.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0.0f));
    // 上下反転させる
    bottomRight.Scale(new Vector3(1f, -1f, 1f));
    return bottomRight;
	}
}
