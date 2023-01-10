using TMPro;
using UnityEngine;

namespace Game.Controllers {
	public class SpeedController : MonoBehaviour {
		public static SpeedController Inst;
		public TMP_Text scoreNum;
		private void Awake() {
			if (Inst == null) {
				Inst = this;
			}
		}

		public void SpeedUpdate(string score) {
			scoreNum.text = $"{score}";
		}
	}
}