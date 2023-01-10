using System;
using UnityEngine;

namespace Game {
	public class CameraFollowing : MonoBehaviour {
		private Transform _player;
		private Vector3 _tempPosition;
		private Vector3 _defaultPoistion;

		private const string PLAYER = "Player";

		private void Start() {
			_player = GameObject.FindWithTag(PLAYER).transform;
			_tempPosition = transform.position;
			this._defaultPoistion = _tempPosition;

		}
		private void LateUpdate() {
			_tempPosition.x = _player.position.x;
			_tempPosition.y = MakeDelayY(99);

			transform.position = _tempPosition;
		}

		private float MakeDelayY(int percentSmooth) {
			var player = _player.position.y;
			var tempPositionY = _tempPosition.y;

			var distance = Math.Abs(player - tempPositionY);
			var calculatedDistance = distance / 100 * percentSmooth;
			var step = player > tempPositionY
				? tempPositionY + calculatedDistance
				: tempPositionY - calculatedDistance;
			return _defaultPoistion.y - _tempPosition.y + step;
		}

	}
}