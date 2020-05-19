using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class LevelMove : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    Vector3 endPosition = new Vector3(45, 0, 0);
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(2, 0) * speed * Time.deltaTime);
    }


}
