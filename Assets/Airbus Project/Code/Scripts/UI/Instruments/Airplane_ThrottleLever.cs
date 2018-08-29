using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeLoveAero;

namespace WeLoveAero
{
    public class Airplane_ThrottleLever : MonoBehaviour, IAirplane_UI
    {
        #region Variables
        [Header("Throttle Lever Properties")]
        public Airplane_Input input;
        public RectTransform parentRect;
        public RectTransform handleRect;
        public float handleSpeed = 2f;
        #endregion


        #region Interface Methods
        public void HandleAirplaneUI()
        {
            if(input && parentRect && handleRect)
            {
                float height = parentRect.rect.height;
                Vector2 wantedHandlePosition = new Vector2(0f, height * input.StickyThrottle);
                handleRect.anchoredPosition = Vector2.Lerp(handleRect.anchoredPosition, wantedHandlePosition, Time.deltaTime * handleSpeed);
            }
        }
        #endregion
    }
}
