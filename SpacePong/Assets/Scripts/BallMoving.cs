using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BallMoving : MonoBehaviour {
// Start is called before the first frame update
	[SerializeField] float speed;
	private Rigidbody2D _body;

	private static readonly string _wall = "Wall";
	private readonly string _wallUp = $"{_wall}Up";
	private readonly string _wallDown = $"{_wall}Down";
	private readonly string _wallLeft = $"{_wall}Left";
	private readonly string _wallRight = $"{_wall}Right";

	private bool _contact;
	private String _contactWall;

	private float _oldX;
	private float _oldY;
	// Start is called before the first frame update
	void Start() {
		_body = GetComponent<Rigidbody2D>();
		speed = 5;

		_oldX = -speed;
		_oldY = -speed;

	}

// Update is called once per frame
	void Update() {

		if (new Random().Next(1, 200) == 1) {
			_body.velocity = new Vector2(9, 4);
			return;
		}
		_body.velocity = new Vector2(_oldX, _oldY);
	}

	private (float, float) GetXY() {
		print("CONTACT!");
		if (string.Equals(_contactWall, _wallUp) || _contactWall.Equals(_wallDown)) {
			return (_oldX, _oldY * -1);
		}

		if (_contactWall.Equals(_wallLeft) || _contactWall.Equals(_wallRight)) {
			return (_oldX * -1, _oldY);
		}
		return (_oldX, _oldY);
	}

	private void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.CompareTag(_wallUp)) {
			_contactWall = _wallUp;
			print(_wallUp);
		}

		if (col.gameObject.CompareTag(_wallDown)) {
			_contactWall = _wallDown;
			print(_wallDown);
		}
		
		if (col.gameObject.CompareTag(_wallLeft)) {
			_contactWall = _wallLeft;
			print(_wallLeft);
		}
		
		if (col.gameObject.CompareTag(_wallRight)) {
			_contactWall = _wallRight;
			print(_wallRight);
		}
		
		var (newX, newY) = GetXY();
		_oldX = newX;
		_oldY = newY;
		print(newX + " " + newY);
		
	}
}