using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private int score;

    void Start() {
        score = 0;
        scoreText.text = "Score : 0";
    }

    // Update is called once per frame
    void Update() {

    }

    public void SetScore(int Score) {
        score += Score;
        scoreText.text = "Score : " + score;
    }
}
