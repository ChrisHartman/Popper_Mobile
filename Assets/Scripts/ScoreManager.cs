﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
	int score;
	public int lives;
	int highscore;
	public Text scoreText;
	public Text livesText;
	public Text gameOverText;
	public KeyCode RestartKey;
	public string leaderboard;
	public string highscorestring;
	//public string scene;
	// Use this for initialization

	void Awake() {
		Application.targetFrameRate = 60;
	}

	void Start () {
		GameOverScoreManager.highscorestring = highscorestring;
		GameOverScoreManager.scene = SceneManager.GetActiveScene ().name;
		Debug.Log("Highscorestring"+highscorestring);
		highscore = PlayerPrefs.GetInt (highscorestring, highscore);
		Debug.Log("Highscore: " + highscore);
		gameOverText.enabled = false;
		var ballManager = FindObjectOfType<BallManager>();
        ballManager.PoppedCorrectColor += IncrementScore;
		ballManager.PoppedIncorrectColor += LoseLife;
		score = 0;
	}

	public int LifeCount() {
		return lives;
	}
	
	
	
	/// <summary>
    /// The score has increased.
    /// </summary>
    void IncrementScore(){
        score += 100;
        scoreText.text = "Score: " + score.ToString();
    }

	void LoseLife() {
		if (lives < 100) {
			lives--;
			if (lives < 0) {
				GameOver();
			} else {
			livesText.text = "Lives: " + lives.ToString();
			}
		}
	}

	void HighScoreCheck() {
		if (highscore < score) {
			highscore = score;
			PlayerPrefs.SetInt (highscorestring, highscore);
			Debug.Log("reporting " + highscore + " to " +highscorestring);
		}
		Debug.Log ("Reporting to " + leaderboard);
		Social.ReportScore (score, leaderboard, success => {
		Debug.Log(success ? "Reported score successfully" : "Failed to report score");
		});
	}

	void GameOver() {
		//Time.timeScale = 0;
		HighScoreCheck();
		GameOverScoreManager.score = score;
		Invoke("GameOverSceneLoad", 1f);
		// gameOverText.text += score.ToString() + "\nHigh Score: " + highscore;
		// livesText.enabled = false;
		// scoreText.enabled = false;
		// gameOverText.enabled = true;
	}
	void GameOverSceneLoad() {
		SceneManager.LoadScene ("GameOver");
	}
}
