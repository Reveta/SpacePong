using System;
using TMPro;
using UnityEngine;

namespace Game.Controllers {
	public class GoalsController : MonoBehaviour {
		public static GoalsController Inst;
		public TMP_Text scoreNum;

		private GameController _gameContr;
		private void Awake() {

			if (Inst == null) {
				Inst = this;
			}

			_gameContr = GameController.Inst;
		}

		public void GoalsUpdatePlusOne() {
			var oldScore = Int16.Parse(scoreNum.text);
			var newScore = ++oldScore;
		
			scoreNum.text = $"{newScore}";
			_gameContr.Goals = newScore;
		}
	}
}