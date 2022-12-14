using Game.Controllers;
using TMPro;
using UnityEngine;

namespace Menu.Options {
	public class UserNameScript : MonoBehaviour {
		public TMP_Text _username;

		private TMP_InputField _inputField;
		private GameController _gameController;
		void Start() {
			_gameController = GameController.Inst;

			_inputField = gameObject.GetComponent<TMP_InputField>();
			if (_inputField != null) {
				_inputField.text = System.Environment.MachineName;
				_inputField.onValueChanged.AddListener(delegate { SubmitName(); });
				SubmitName();
			}
		
		}

		private void SubmitName() {
			var newName = _inputField.text;
			_username.text = newName;
			_gameController.UserName = newName;
		}
	}
}