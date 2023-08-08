using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPainting : ComponentBehaviuor
{
   private static AutoPainting instance;
   public static AutoPainting Instance
   {
      get { return instance; }
   }
   public int paintCount = 0;
   protected override void Awake()
   {
      base.Awake();
      instance = this;
   }
   public void ChangePaintCtrl()
   {
      HidePaintCtrl();
      paintCount++;
      transform.GetChild(paintCount).gameObject.SetActive(true);
   }

   public void HidePaintCtrl()
   {
      transform.GetChild(paintCount).gameObject.SetActive(false);
   }
}
