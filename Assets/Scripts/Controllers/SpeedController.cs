using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

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