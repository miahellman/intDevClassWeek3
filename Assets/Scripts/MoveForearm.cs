using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForearm : MonoBehaviour
{


    Rigidbody2D myBody;

    float forearmPower = 20f;



    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        //  mySoundManager = GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //  mySoundManager.myAudioSource.PlayOneSHot(mySoundManager.armSound);
            myBody.AddForce(transform.up * forearmPower, ForceMode2D.Impulse);

        }


    }
}
