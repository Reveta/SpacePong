using UnityEngine;

namespace Game.Controllers {
	public class GameController : MonoBehaviour {
		public static GameController Inst;

		public string UserName { get; set; } = "Reveta";
		public int Goals { get; set; } = 0;
		public float ScoreSum { get; set; } = 0;
		public float Score { get; set; } = 0;
		public int GoalLimit { get; set; } = 10;

		[BeforeRenderOrder(0)]private void Awake() {
			if (Inst == null) {
				Inst = this;
				DontDestroyOnLoad(gameObject);
			}
		}
	}
}