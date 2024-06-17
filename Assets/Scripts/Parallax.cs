using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    [SerializeField] private Camera _camera;
    [SerializeField] private float _parallaxStrength;
    private float _length, _startPos;   


    void Start()
    {
         _startPos = transform.position.x;
         _length = GetComponent<SpriteRenderer>().bounds.size.x;    
    }

    void Update()
    {
         float temp = (_camera.transform.position.x * (1-_parallaxStrength));
         float distance = (_camera.transform.position.x * _parallaxStrength);

         transform.position = new Vector3(_startPos + distance, transform.position.y, transform.position.z);
         //if(temp > _startPos + _length) _startPos += _length;
         //else if (temp < _startPos - _length) _startPos -= _length;        
    }
}
