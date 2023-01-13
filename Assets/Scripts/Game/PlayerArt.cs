using UnityEngine;

namespace Game {
	public class PlayerArt : MonoBehaviour {
		// Start is called before the first frame update
		[SerializeField] private float moveForce = 10f;
		private float movementY;

		private Rigidbody2D myBody;

		private const string GROUND_TAG = "Ground";

		private SpriteRenderer _sr;
		private Sprite _tractorUp;
		private Sprite _tractorDown;
		private void Awake() {

			myBody = GetComponent<Rigidbody2D>();
			_sr = GetComponent<SpriteRenderer>();

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

			transform.position += new Vector3(0f, movementY, 0f) * (moveForce * Time.deltaTime);
		}

	}
}