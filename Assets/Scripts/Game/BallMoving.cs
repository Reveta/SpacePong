using System;
using System.Threading;
using Enum;
using Game.Controllers;
using UnityEngine;
using Random = System.Random;

namespace Game {
	public class BallMoving : MonoBehaviour {
// Start is called before the first frame update
		[SerializeField] float speed;
		private float speed_def;
		private Rigidbody2D _body;
		private GameEngine _gameEngine;

		[SerializeField] private bool randomMoves = false;

		private static readonly string Wall = "Wall";
		private readonly string _wallUp = $"{Wall}Up";
		private readonly string _wallDown = $"{Wall}Down";
		private readonly string _wallLeft = $"{Wall}Left";
		private readonly string _wallRight = $"{Wall}Right";

		private static readonly string Player = "Player";
		private readonly string _playerRight = $"{Player}Right";
		private readonly string _playerLeft = $"{Player}Left";

		private bool _contact;
		private String _contactWall;

		private float _oldX;
		private float _oldY;

		private GoalsController _goalsContr;
		private SpeedController _speedContr;
		private ScoreController _scoreContr;

		void Start() {
			_gameEngine = GameEngine.Inst;
			_speedContr = SpeedController.Inst;
			_scoreContr = ScoreController.Inst;
			_goalsContr = GoalsController.Inst;

			_body = GetComponent<Rigidbody2D>();

			speed_def = speed;

			_oldX = -speed;
			_oldY = -speed;

		}

// Update is called once per frame
		void Update() {
			if (!_gameEngine.BallMoving) {
				_body.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
			} else {
				_body.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

			}

			if (randomMoves) {
				if (new Random().Next(1, 200) == 1) {
					_body.velocity = new Vector2(9, 4);
					return;
				}
			}


			_body.velocity = new Vector2(_oldX * speed, _oldY * speed);
		}

		private (float, float) GetXY() {
			//print("CONTACT!");
			if (string.Equals(_contactWall, _wallUp) || _contactWall.Equals(_wallDown)) {
				return (_oldX, _oldY * -1);
			}

			if (_contactWall.Equals(_wallLeft) || _contactWall.Equals(_wallRight)) {
				return (_oldX * -1, _oldY);
			}
			return (_oldX, _oldY);
		}

		private void UpdateDiffucult() {
			// this.speed += speed / 10;
			this.speed += 0.1f;
			_speedContr.SpeedUpdate(speed.ToString("0.00"));
		}

		private void GoalEvent(EGates eGates) {
			new Thread(() =>
			{
				speed = 0;
				Thread.Sleep(1000);
				speed = speed_def;
			}).Start();
			transform.position = new Vector3(0, 1);

			_scoreContr.ScoreUpdate(speed);
			_goalsContr.GoalsUpdatePlusOne();
		}

		private void OnCollisionEnter2D(Collision2D col) {

			if (col.gameObject.CompareTag(_wallUp)) {
				_contactWall = _wallUp;
				//print(_wallUp);
			}

			if (col.gameObject.CompareTag(_wallDown)) {
				_contactWall = _wallDown;
				//print(_wallDown);
			}

			if (col.gameObject.CompareTag(_wallLeft)) {
				_contactWall = _wallLeft;
				GoalEvent(EGates.Left);
				//print(_wallLeft);
			}

			if (col.gameObject.CompareTag(_wallRight)) {
				_contactWall = _wallRight;
				GoalEvent(EGates.Right);
				//print(_wallRight);
			}

			if (col.gameObject.CompareTag(_playerLeft)) {
				_contactWall = _wallLeft;
				UpdateDiffucult();
				//print(_playerLeft);
			}

			if (col.gameObject.CompareTag(_playerRight)) {
				_contactWall = _wallRight;
				UpdateDiffucult();
				//print(_playerRight);
			}


			var (newX, newY) = GetXY();
			_oldX = newX;
			_oldY = newY;
			//print(newX + " " + newY);

		}
	}
}