using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public int score;

	void Start() {
		ResetScore();
	}

	public void ResetScore() {
		score = 0;
		scoreText.text = "Score : 0";
	}

	public void AddScore(int Score) {
		score += Score;
		scoreText.text = "Score : " + score;
	}
}
