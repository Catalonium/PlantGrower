using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public float timeLimit = 10;
	private Text timer;

	private void Start() {
		
		timer = this.GetComponent<Text>();

	}

	void Update() {

		timeLimit -= Time.deltaTime;
		timer.text = timeLimit.ToString("F0");
		if (timeLimit < 0) {
			timer.text = "Game Over!";
		}

	}

}
