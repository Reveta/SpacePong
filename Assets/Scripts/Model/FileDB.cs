using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Model {
	public class FileDB : MonoBehaviour, IDataBase {
		public static IDataBase Inst;

		private string _fileName = "fileDB.txt";

		private void Awake() {
			if (Inst == null) {
				Inst = this;
			}
		}
		private void Start()
		{
			if (File.Exists(_fileName))
			{
				var fileContent = File.ReadAllText(_fileName);
				var data = fileContent;
				print("Data loaded: \n" + data);
			}
			DontDestroyOnLoad(this);
		}
		
		public void AddResult(UserResult userResult) {
			File.AppendAllText(_fileName, CvsManage.Code(userResult));
		}
		
		public List<UserResult> GetAllResult() {
			var data = File.ReadAllText(_fileName);
			var userResults = CvsManage.DecodeAll(data);
			return userResults;
		}

		public void Test() {
			AddResult(new UserResult() {
				Name = "roman",
				MaxSpeed = 2313
			});
			
			GetAllResult().ForEach(print);
		}
	}
}