using UnityEngine;
using System.Collections;

public class TAP : MonoBehaviour {
    GameObject mainCamera;
    GameObject Button;
    Camera main;
    void Start () {
        mainCamera = GameObject.Find("Main Camera");
        Button = GameObject.Find("Button");
    }
    void Update () {
        //カメラを取得
        main = mainCamera.GetComponent<Camera>();
        Vector3 mousePos = main.ScreenToWorldPoint (Input.mousePosition);
        Collider2D col = Physics2D.OverlapPoint (mousePos);
        //タップ確認
        if (Input.GetMouseButtonDown (0)) {
            if (col == Button.GetComponent<Collider2D> ()) {
             //タップされた時の処理
			 Debug.Log("tap");
            }
        }
    }
}