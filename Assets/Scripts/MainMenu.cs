﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class MainMenu : MonoBehaviour {

    // Call from inspector button
    public void ResumeGame () {
        SceneManager.LoadScene ("Main");
    }
    public void ResumeGameExpert() {
        SceneManager.LoadScene ("Expert Mode");
    }
    public void ResumeGamePractice() {
        SceneManager.LoadScene ("Practice Mode");
    }
    public void Menu() {
        SceneManager.LoadScene ("MainMenu");
    }
    public void Tutorial() {
        SceneManager.LoadScene ("Tutorial");
    }
    public void Play() {
        SceneManager.LoadScene ("Play");
    }
    public void Awake () {
		Application.targetFrameRate = 60;
        Social.localUser.Authenticate (ProcessAuthentication);
    }
    public void Start () {

    }
    public void CheckLeaderboard() {
        Social.ShowLeaderboardUI();
    }
    void ProcessAuthentication (bool success) {
		if (success) {
			Debug.Log ("Authenticated");
		} else {
			Debug.Log ("Failed to authenticate");
		}     
	}
}