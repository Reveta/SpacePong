using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ResultTableScript : MonoBehaviour {
	// Start is called before the first frame update

	public TMP_Text id;
	public TMP_Text userName;
	public TMP_Text maxSpeed;
	public TMP_Text goals;

	private int _idCount = 1;
	private IDataBase _dataBase;
	void Start() {
		_dataBase = FileDB.Inst;

		_dataBase.GetAllResult()
			.OrderByDescending(result1 => result1.MaxSpeed)
			.ToList()
			.ForEach(result =>
		{
			id.text += _idCount++ + "\n";
			userName.text += result.Name + "\n";
			maxSpeed.text += result.MaxSpeed + "\n";
			goals.text += result.Goals + "\n";
		});
	}

	// Update is called once per frame
	void Update() {
	}
}