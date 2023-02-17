using System.Collections;
using UnityEngine;

namespace Game.Controllers {
	public class GameEngine : MonoBehaviour {
		public static GameEngine Inst;

		private MenuController _menuController;

		public bool isPause = true;
		public bool ballMoving = true;

		private int _cooldownCount = 0;
		private bool _firstStart = false;
		private void Awake() {
			if (Inst == null) {
				Inst = this;
			}
		}
		void Start() {
			_menuController = MenuController.Inst;
			CleanDataBase();

			SetPause(true);
			StartCoroutine(StartCooldown());

		}
		
		private void CleanDataBase() {
			var gC = GameController.Inst;
			gC.Goals = 0;
			gC.Score = 0;
			gC.SpeedSum = 0;
		}

		void Update() {
			ESC_Check();
		}

		IEnumerator StartCooldown() {
			for (;;) {
				_menuController.CooldownStep();
				if (_cooldownCount == 4) {
					_firstStart = true;
					SetPause(false);
				}
				_cooldownCount++;
				yield return new WaitForSeconds(1);
			}
		}
		public void SetPause(bool isPause) {
			this.isPause = isPause;

			switch (isPause) {

				case true:
					ballMoving = false;
					break;

				case false:
					ballMoving = true;
					break;
			}
		}


		private void ESC_Check() {

			if (Input.GetKeyDown(KeyCode.Escape) && _firstStart) {
				SetPause(!isPause);
				_menuController.ChangeHideEscPanel();
			}
		}
	}
}