using TMPro;
using UnityEngine;

namespace Game.Controllers {
	public class ScoreController : MonoBehaviour {
		public static ScoreController Inst;
		public TMP_Text scoreNum;

		private  GameController _gameContr;
		private void Awake() {

			if (Inst == null) {
				Inst = this;
			}
		
			_gameContr = GameController.Inst;
		}

		public void ScoreUpdate(float speed) {
			var goals = _gameContr.Goals;
		
			_gameContr.SpeedSum += speed;
		
			var newScore = (_gameContr.SpeedSum / goals);
			scoreNum.text = newScore.ToString("0.00");
			_gameContr.Score = newScore;
		}
	}
}