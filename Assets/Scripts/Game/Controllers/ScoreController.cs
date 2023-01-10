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

		public void ScoreUpdate(float score) {
			var goals = _gameContr.Goals;
		
			_gameContr.ScoreSum += score;
			goals = goals+1; //save from 0 split exception and make correct score compile
		
			var newScore = (_gameContr.ScoreSum / (goals+1));
			scoreNum.text = newScore.ToString("0.00");
			_gameContr.Score = newScore;
		}
	}
}