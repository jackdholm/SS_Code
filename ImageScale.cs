using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class ImageScale : MonoBehaviour
    {
        private RectTransform _img;

        void Start()
        {
            _img = GetComponent<RectTransform>();
            _img.sizeDelta = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
        }
    }
}