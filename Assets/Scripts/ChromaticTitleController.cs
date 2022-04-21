using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChromaticTitleController : MonoBehaviour
{
    private List<float> _startingPositions = new List<float>();
    private List<float> _directions = new List<float>();
    private List<float> _speeds = new List<float>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            _startingPositions.Add(child.position.y);

            int random = Random.Range(1, 10);

            int startingDirection = random > 5 ? 1 : -1;
            
            _directions.Add(startingDirection);

            float speed = Random.Range(0.1f, 0.3f);
            _speeds.Add(speed);
        }
    }
    
    private void FixedUpdate()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.position.y >= _startingPositions[i] + 10f ||
                child.position.y <= _startingPositions[i] - 10f)
            {
                _directions[i] = _directions[i] *= -1;
            }
            
            child.Translate(new Vector3(0, _directions[i] * _speeds[i], 0));
            // child.Translate(new Vector3(0, 1, 0));

            i++;
        }
    }
}
