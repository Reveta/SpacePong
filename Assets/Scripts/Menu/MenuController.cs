using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
	public class MenuController : MonoBehaviour
	{
	
		public GameObject panel;

		private void Start() {
			panel.SetActive(false);
		}
		public void StartGame() {
			SceneManager.LoadScene("Gameplay");
		
		}

		public void StartGameArt() {
			SceneManager.LoadScene("GameplayPensilArt");
		
		}

		
		public void OptionClick() {
			panel.SetActive(!panel.activeSelf);
		}

		public void Exit() {
		
			print("ExitButton");
			Application.Quit();
		}
	}
}
