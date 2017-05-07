﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string level) {
		SceneManager.LoadScene (level);
	}

	public void LoadLevelByIndex(int index) {
		SceneManager.LoadScene (index);
	}
}
