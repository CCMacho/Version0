using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edit : MonoBehaviour {

	private string[] rhythmKey = new string[1000];
	private string[] rhythmnNotesKey = new string[1000];

	float nextRhutmtTiming = 0;
	int nextRhutmKeyCout = 0;
	float tolerance = 0.1f;
	[SerializeField]
	GameObject[] rhythmNotes = null;
	[SerializeField]

	bool OutputMode = true;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		if (OutputMode)
		{
			OutputRhythm();
		}
		else
		{
			InputRhythm();
		}

		if (Input.GetKeyDown(KeyCode.F))
		{
			for(int i = 0; i < rhythmKey.Length; ++i)
			{
				Debug.Log((PlayerPrefs.GetFloat(rhythmKey[i], 0f).ToString() + " " + PlayerPrefs.GetInt(rhythmnNotesKey[i], 0).ToString() ));
			}
		}
	}

	//音の表現
	void OutputRhythm()
	{
		
		nextRhutmtTiming =  PlayerPrefs.GetFloat(rhythmKey[nextRhutmKeyCout], 0f);
		if(Time.time > nextRhutmtTiming && nextRhutmtTiming != 0f)
		{
			Debug.Log(PlayerPrefs.GetFloat(rhythmKey[nextRhutmKeyCout], 0f) + " " + PlayerPrefs.GetInt(rhythmnNotesKey[nextRhutmKeyCout]));

			Instantiate(rhythmNotes[PlayerPrefs.GetInt(rhythmnNotesKey[nextRhutmKeyCout]) - 1]);
			
			++nextRhutmKeyCout;

		}
		


	}

	//音の入力
	void InputRhythm()
	{

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Debug.Log(nextRhutmKeyCout);
			Debug.Log(Time.time);

			PlayerPrefs.SetFloat(rhythmKey[nextRhutmKeyCout], (float)Time.time);
			PlayerPrefs.SetInt(rhythmnNotesKey[nextRhutmKeyCout], 1);
			PlayerPrefs.Save();

			Debug.Log (PlayerPrefs.GetFloat(rhythmKey[nextRhutmKeyCout], 0f) + " " + PlayerPrefs.GetInt(rhythmnNotesKey[nextRhutmKeyCout] , 0));

			++nextRhutmKeyCout;
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Debug.Log(nextRhutmKeyCout);
			Debug.Log(Time.time);

			PlayerPrefs.SetFloat(rhythmKey[nextRhutmKeyCout], Time.time);
			PlayerPrefs.SetInt(rhythmnNotesKey[nextRhutmKeyCout], 2);
			PlayerPrefs.Save();

			Debug.Log(PlayerPrefs.GetFloat(rhythmKey[nextRhutmKeyCout], 0f) + " " + PlayerPrefs.GetInt(rhythmnNotesKey[nextRhutmKeyCout], 0));

			++nextRhutmKeyCout;
		}
	}

}
