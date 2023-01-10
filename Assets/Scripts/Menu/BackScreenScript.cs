using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Menu {
	public class BackScreenScript : MonoBehaviour {
		public List<Texture2D> images;
		private RawImage _rawImage;

		public int secondsToUpdate = 5;
		void Start() {
			_rawImage = gameObject.GetComponent<RawImage>();

			StartCoroutine(UpdateScreen());
		}

		private void Update() {
		

		}

		IEnumerator UpdateScreen() {
			for (;;) {

				var randomIndex = Random.Range(0, images.Count-1);
				_rawImage.texture = images[randomIndex];
			
				yield return new WaitForSeconds(3);
			}
		}


	}
}