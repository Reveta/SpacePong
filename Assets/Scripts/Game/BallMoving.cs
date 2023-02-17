using System;
using System.Threading;
using Game.Controllers;
using Model;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMoving : MonoBehaviour {
	[SerializeField] private float speed = 12f;
	[SerializeField] private float wallBounceAngle = 45f;
	[SerializeField] private float paddleBounceAngle = 45f;
	[SerializeField] private float speedUpdate = 0.25f;

	private Rigidbody2D _body;
	private GameEngine _gameEngine;
	private IDataBase _dataBase;
	private GameController _controller;
	private GoalsController _goalsContr;
	private ScoreController _scoreContr;
	private SpeedController _speedContr;

	private float _ballMaxSpeed = 0.0f;
	private float _speedDef = 0.0f;
	private Vector2 _oldVelocity;

	private void Start() {
		_gameEngine = GameEngine.Inst;
		_dataBase = FileDB.Inst;
		_controller = GameController.Inst;
		_goalsContr = GoalsController.Inst;
		_scoreContr = ScoreController.Inst;
		_speedContr = SpeedController.Inst;

		_body = GetComponent<Rigidbody2D>();
		_body.inertia = 100f;

		InitializeBall();
	}

	private void InitializeBall() {
		_body.velocity = GetRandomDirection() * speed;
		_oldVelocity = _body.velocity;

		var ballMaterial = new PhysicsMaterial2D { bounciness = 0.1f, friction = 0.2f };
		_body.sharedMaterial = ballMaterial;

		_speedDef = speed;
	}
	
	private void Update() {
		_body.constraints = _gameEngine.ballMoving
			? RigidbodyConstraints2D.None
			: RigidbodyConstraints2D.FreezePosition;
	}
	
	private void FixedUpdate() {
		// Limit the ball's speed
		var bv = _body.velocity;

		if (bv.normalized == Vector2.zero)
			_body.velocity = _oldVelocity * speed;
		else {
			_body.velocity = speed * bv.normalized;
			_oldVelocity = bv.normalized;
		}

		_speedContr.SpeedUpdate(speed.ToString("0.00"));
	}
	
	private void OnCollisionEnter2D(Collision2D col) {
		var colTransform = col.transform;
		if (col.gameObject.CompareTag("PlayerLeft") || col.gameObject.CompareTag("PlayerRight")) {
			var paddleCenterY = colTransform.position.y;
			var ballY = transform.position.y;
			var bounceAngle = (ballY - paddleCenterY) * paddleBounceAngle / col.collider.bounds.size.y + Random.Range(-20, 20);

			speed += speedUpdate;
			HandleCollision(bounceAngle);

		} else if (col.gameObject.CompareTag("WallUp"))
			HandleCollision(wallBounceAngle);

		else if (col.gameObject.CompareTag("WallDown"))
			HandleCollision(-wallBounceAngle);

		else if (col.gameObject.CompareTag("WallLeft") || col.gameObject.CompareTag("WallRight"))
			GoalEvent();
	}

	private Vector2 GetRandomDirection() {
		var x = Random.Range(0, 2) == 0? 1 : -1;
		var y = Random.Range(0, 2) == 0? 1 : -1;

		return new Vector2(x, y).normalized;
	}
	
	private void HandleCollision(float bounceAngle) {
		var direction = Quaternion.Euler(0, 0, bounceAngle) * (_body.velocity.x < 0? Vector2.left : Vector2.right);
		_body.velocity = direction.normalized * _body.velocity.magnitude;
		_body.angularVelocity = Mathf.Clamp(_body.angularVelocity, -360f, 360f);
	}

	private void GoalEvent() {
		SaveUserResult();
		ResetBallPosition();
		_goalsContr.GoalsUpdatePlusOne();
		_scoreContr.ScoreUpdate(speed);
		DelayedResetBallSpeed();
	}

	private void SaveUserResult() {
		if (speed > _ballMaxSpeed) {
			_dataBase.AddResult(new UserResult() {
				Name = _controller.UserName,
				Goals = _controller.Goals,
				MaxSpeed = (float)Math.Round(speed, 2)
			});
			_ballMaxSpeed = speed;
		}
	}

	private void ResetBallPosition() {
		transform.position = new Vector3(0, 1);
	}

	private void DelayedResetBallSpeed() {
		new Thread(() =>
		{
			_gameEngine.ballMoving = false;
			Thread.Sleep(1000);
			speed = _speedDef;
			_gameEngine.ballMoving = true;
		}).Start();
	}
}