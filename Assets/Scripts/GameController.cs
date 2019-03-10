using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// variables
	public int currentScore = 0;
	public int highScore = 0;

	// ref objects
	public GameObject _game;
	public GameObject _menuButtons;
	public Text _menuCurrScore;
	public Text _menuHighScore;
	public Text _version;
	public Text _credits;

	// Use this for initialization
	void Start () {
		// Version init at startup
		_version.text = Application.companyName + "-" + Application.productName + "_v" + Application.version;
		// Credits init at startup
		_credits.text = "by A. Bulut Catikoglu and Nyein Chan Aung";
		// Manage saved score
		if (!PlayerPrefs.HasKey("HighScore")) {
			PlayerPrefs.SetInt("HighScore", 0);
		}
		else {
			highScore = PlayerPrefs.GetInt("HighScore");
		}
		// Manage saved startup state
		if (!PlayerPrefs.HasKey("isStartup") || PlayerPrefs.GetInt("isStartup").Equals(0)) {
			PlayerPrefs.SetInt("isStartup", 1);
			endGame(false);
		}
	}

	public void endGame(bool isGameOver = false) {
		if (isGameOver) {
			currentScore = GameObject.FindWithTag("Game_Score").GetComponent<Score>().score;
			if (highScore < currentScore) {
				highScore = currentScore;
				PlayerPrefs.SetInt("HighScore", highScore);
			}
		}
		_game.SetActive(false);
		showMenu();
	}

	public void showMenu() {
		_menuButtons.SetActive(true);
		_menuCurrScore.gameObject.SetActive(true);
		_menuCurrScore.text = "Current Score: " + currentScore;
		_menuHighScore.gameObject.SetActive(true);
		_menuHighScore.text = "High Score: " + highScore;
	}

	public void startGame() {
		SceneManager.LoadScene(0);
	}

	public void clearHighScore() {
		highScore = 0;
		PlayerPrefs.SetInt("HighScore", highScore);
		showMenu();
	}
	
	public void quitGame() {
		PlayerPrefs.SetInt("isStartup", 0);
		Application.Quit();
	}

}
