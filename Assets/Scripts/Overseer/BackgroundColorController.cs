using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Overseer
{
    public class BackgroundColorController : MonoBehaviour
    {
        private Color _newColor;
        private const float FadeDuration = 50f;
        private float _fadeTimeElapsed = 0;
        private Camera _camera;

        private void Awake()
        {
            _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            GenerateNewColor();
        }

        private void FixedUpdate()
        {
             ChangeColor();
        }

        private void ChangeColor()
        {
            if (_fadeTimeElapsed < FadeDuration)
            {
                _fadeTimeElapsed += 1;
                _camera.backgroundColor = Color.Lerp(_camera.backgroundColor, _newColor, _fadeTimeElapsed/FadeDuration);
            }
            else
            {
                _fadeTimeElapsed = 0;
                GenerateNewColor();
            }
        }

        private void GenerateNewColor()
        {
            _newColor = Random.ColorHSV(0, 1f, .3f, .3f, .3f, .3f, 1, 1);
        }
    }
}
