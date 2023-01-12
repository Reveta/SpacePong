using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayerController : MonoBehaviour {
   public static ChoosePlayerController Inst;
   
   public Image image;

   public List<Sprite> images;
   public int imageIndex;
   private void Awake() {
      if (Inst == null) {
         Inst = this;
      }
   }

   public void OnButtonClickLeft() {
      var newIndex = imageIndex - 1;
      if (newIndex < 0) {
         var lastIndex = images.Count -1;
         newIndex = lastIndex;
      }
      image.sprite = images[newIndex];
      imageIndex = newIndex;
   }
   
   public void OnButtonClickRight() {
      var newIndex = imageIndex + 1;
      var lastIndex = images.Count - 1;
      if (newIndex > lastIndex) {
         newIndex = 0;
      }
      image.sprite = images[newIndex];
      imageIndex = newIndex;
   }

}
