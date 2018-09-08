using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pointer : MonoBehaviour {

    SteamVR_TrackedObject trackedObject;
    GameObject previewObject;
    GameObject gamemanager;
    int sceneSwitchingCount = 0;

	GameObject imageGenerator;
	GameObject touchableImagePrefab;
	int cooltimeGetImage = 0;

	// 音声認識開始の動作で意図しない画像を選択してしまう為、
	// TriggerとTouchpadが一定時間内に同時に押されれば、直前生成したTouchableImageのオブジェクトを削除する
	private int onceThreshold = 70;
	private int deleteCount = 0;
	private GameObject preGeneratedTouchableImage;

	// Use this for initialization
	void Start () {
        trackedObject = GetComponentInParent<SteamVR_TrackedObject>();
        previewObject = GameObject.Find("imagePreview");
        gamemanager = GameObject.Find("GameManager");

		touchableImagePrefab = (GameObject)Resources.Load("Prefabs/TouchableImageQuad");
		//touchableImagePrefab = (GameObject)Resources.Load("Prefabs/TouchableImage");
		imageGenerator = GameObject.Find("ImageGenerator");

	}

	// Update is called once per frame
	void Update()
	{
		GetComponentInChildren<Animator>().SetTrigger("Controller3");
		var device = SteamVR_Controller.Input((int)trackedObject.index);

		// トリガーを押したらポインターの線を消し、離したら線を再表示
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			GetComponentInChildren<Animator>().SetTrigger("Controller");
		} else if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			GetComponentInChildren<Animator>().SetTrigger("Controller2");
		}

		// 検索（音声認識）開始
		if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
			if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
			{
				if (preGeneratedTouchableImage != null) Destroy(preGeneratedTouchableImage);
				//imageGenerator.GetComponent<RecognizingEffect>().Recognizing();
				//print("TriggerとTouchPadの両方が押されています。");
				//device.TriggerHapticPulse(1000);
			}
        }

		if(cooltimeGetImage > 0)
		{
			cooltimeGetImage--;
		}

		if(deleteCount > 0)
		{
			deleteCount--;
			if(deleteCount == 0)
			{
				preGeneratedTouchableImage = null;
			}
		}
    }

    // ポインタが画像上にある時の処理
    void OnTriggerStay(Collider col)
    {
        var device = SteamVR_Controller.Input((int)trackedObject.index);

		//print("col.gameObject.tag :  " + col.gameObject.tag);

        if (col.gameObject.tag == "Picture")
        {
			//print("ポインタ上にある画像名は、" + col.GetComponent<SpriteRenderer>().sprite.name);
			if (!device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
			{
				//col.GetComponent<ImageEffect>().OnPointer();
			}
			//if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
			if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && cooltimeGetImage == 0)
			{
                device.TriggerHapticPulse(2000);

				// 触れる用のプレハブを生成する
				GameObject touchableImage = Instantiate(touchableImagePrefab, col.GetComponent<SpriteRenderer>().bounds.center, col.transform.rotation);
				//touchableImage.GetComponent<TouchableImageEffect>().setSprite(col.GetComponent<SpriteRenderer>());
				//touchableImage.GetComponent<TouchableImageEffect>().setTexture(col.GetComponent<SpriteRenderer>().sprite.texture);
				//touchableImage.transform.localScale = col.transform.localScale;
				//touchableImage.GetComponent<TouchableImageEffect>().setOriginalPrefab(col.gameObject);
				col.gameObject.SetActive(false);

				// 重なってる画像が連続して選択されないように
				cooltimeGetImage = 30;

				// 検索しようとした時に、勝手に選択されてしまった場合は、後からここで生成したプレハブを削除する
				deleteCount = onceThreshold;
				preGeneratedTouchableImage = touchableImage;
			}
        }

    }

    // ポインタが画像内に入った瞬間の処理
    void OnTriggerEnter(Collider col)
    {
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        if (col.gameObject.tag == "Picture")
        {
            //device.TriggerHapticPulse(300);
        }
    }


	// 前のバージョンのUpdate()。参考用に残しているだけ。

	void OldUpdate()
	{
		var device = SteamVR_Controller.Input((int)trackedObject.index);

		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			//if (previewObject.GetComponent<ImagePreview>().getPreviewing() == true)
			//{
				//previewObject.GetComponent<ImagePreview>().previewGenerate(this.gameObject, this.transform.parent.gameObject);
				//device.TriggerHapticPulse(1000);
			//}
		}
		/*
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && sceneSwitchingCount == 0)
        {
            sceneSwitchingCount = 100;
            
        }
		*/
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
		{
			//if (previewObject.GetComponent＜ImagePreview＞（）.getPreviewing() == true)
			//{
				//previewObject.GetComponent<ImagePreview>().previewCancel(this.GetComponentInParent<Transform>().gameObject);
			//}
		}
		if (sceneSwitchingCount > 0)
		{
			sceneSwitchingCount--;
			GameObject[] objs = GameObject.FindGameObjectsWithTag("Picture");
			foreach (GameObject obj in objs)
			{
				//obj.GetComponent<ImageRotation>().angle *= 1.07f;
				//obj.GetComponent<ImageRotation>().angle = 1.0f;
				obj.GetComponent<Transform>().transform.localScale *= 0.975f;
				//obj.GetComponent<Transform>().transform.Translate(new Vector3(0, -0.02f, 0));
				obj.GetComponent<Transform>().transform.Rotate(new Vector3(0, 0, 5));
			}
			//if(obj) obj.GetComponent<ImageEffect>().Disppear();
			if (sceneSwitchingCount == 0)
			{
				SceneManager.LoadScene("image_search_desk_2");
			}
		}
	}
}
