using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WheelSpin : MonoBehaviour
{

    public enum WheelDirection { left = 0, right}
    public WheelDirection direction = WheelDirection.left;

    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == WheelDirection.left)
        {
            transform.Rotate(0, 0, (-2 * speed * Time.deltaTime));
        }

        else
        {
            transform.Rotate(0, 0, (2 * speed * Time.deltaTime));
        }
    }
}
