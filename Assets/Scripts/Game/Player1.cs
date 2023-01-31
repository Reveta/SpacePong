using UnityEngine;

namespace Game {
	public class Player1 : MonoBehaviour {
		// Start is called before the first frame update
		[SerializeField] private float moveForce = 10f;
		[SerializeField] private int PlayerNumber = 1;
		private float movementY;

		private Rigidbody2D myBody;

		private const string GROUND_TAG = "Ground";
		private static readonly string Wall = "Wall";
		private readonly string _wallUp = $"{Wall}Up";
		private readonly string _wallDown = $"{Wall}Down";

		private SpriteRenderer _sr;
		private Sprite _tractorUp;
		private Sprite _tractorDown;
		private void Awake() {

			myBody = GetComponent<Rigidbody2D>();
			_sr = GetComponent<SpriteRenderer>();

			switch (PlayerNumber) {
				case 1:
					_tractorUp = Resources.LoadAll<Sprite>("Tractor1_Up")[0];
					_tractorDown = Resources.LoadAll<Sprite>("Tractor1_Down")[0];
					break;
				case 2:
					_tractorUp = Resources.LoadAll<Sprite>("Tractor2_Up")[0];
					_tractorDown = Resources.LoadAll<Sprite>("Tractor2_Down")[0];
					break;
			}
		}
		void Start() {}

		void Update() {
			PlayerMoveKeyboardUpdate();
		}

		private void FixedUpdate() {
			// PlayerJump();
		}



		void PlayerMoveKeyboardUpdate() {
			movementY = Input.GetAxisRaw("Vertical");

			switch (movementY) {
				case 1:
					_sr.sprite = _tractorUp;
					break;
				case -1:
					_sr.sprite = _tractorDown;
					break;
			}
			transform.position += new Vector3(0f, movementY, 0f) * (moveForce * Time.deltaTime);
		}

	}
}