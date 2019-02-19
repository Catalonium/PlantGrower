using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public float timeLimit = 60;
	public Text timer;

	void Update() {

		timeLimit -= Time.deltaTime;
		timer.text = timeLimit.ToString("F0");
		if (timeLimit < 0) {
			timer.text = "Game Over!";
		}

	}

}
