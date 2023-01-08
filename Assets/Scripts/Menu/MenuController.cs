using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	
	public GameObject panel;

	private void Start() {
		panel.SetActive(false);
	}
	public void StartGame() {
		SceneManager.LoadScene("Gameplay");
		
	}

	public void OptionClick() {
		panel.SetActive(!panel.activeSelf);
	}

	public void Exit() {
		
		print("ExitButton");
		Application.Quit();
	}
}
