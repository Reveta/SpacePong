using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public static GameController Inst;

	public string UserName { get; set; }
	public int Goals { get; set; } = 0;
	public float ScoreSum { get; set; } = 0;
	public float Score { get; set; } = 0;

	[BeforeRenderOrder(0)]private void Awake() {
		if (Inst == null) {
			Inst = this;
			DontDestroyOnLoad(gameObject);
		}
		// DontDestroyOnLoad(gameObject);

	}
}