﻿using System;
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
				DontDestroyOnLoad(this);
			}
		}
		
		public void AddResult(UserResult userResult) {
			File.AppendAllText(_fileName, CvsManage.Code(userResult));
		}
		
		public List<UserResult> GetAllResult() {
			if (File.Exists(_fileName)) {
				var data = File.ReadAllText(_fileName);
				var userResults = CvsManage.DecodeAll(data);
				return userResults;
			}
			return new List<UserResult>();
		}
	}
}