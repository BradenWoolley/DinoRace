using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    [SerializeField] float rotateSpeed, crossHairSpeed;
    GameObject crossHair;

    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        crossHair = GameObject.Find("CrossHair");
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0, joystick.Horizontal * rotateSpeed * Time.deltaTime));
        crossHair.transform.Translate(crossHairSpeed * joystick.Horizontal * rotateSpeed * Time.deltaTime, 0, 0);

        /*if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -rotateSpeed * Time.deltaTime));
            crossHair.transform.Translate(crossHairSpeed *-rotateSpeed * Time.deltaTime, 0 , 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime));
            crossHair.transform.Translate(crossHairSpeed * rotateSpeed * Time.deltaTime, 0, 0);
        }*/
    }
}
