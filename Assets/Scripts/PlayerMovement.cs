using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //reference joints
    public HingeJoint2D rightThigh;
    public HingeJoint2D leftThigh;
    public HingeJoint2D rightCalf;
    public HingeJoint2D leftCalf;

    //initialize motors in joints
    private JointMotor2D rightThighMotorRef;
    private JointMotor2D leftThighMotorRef;
    private JointMotor2D rightCalfMotorRef;
    private JointMotor2D leftCalfMotorRef;

    public float hingeSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        rightThighMotorRef = rightThigh.motor;
        leftThighMotorRef = leftThigh.motor;
        rightCalfMotorRef = rightCalf.motor;
        leftCalfMotorRef = leftCalf.motor;

    }

    // Update is called once per frame
    void Update()
    {
        //THIGHS
        //if q pressed
        if (Input.GetKey(KeyCode.Q))
        {
            rightThigh.useMotor = true;
            leftThigh.useMotor = true;
            rightThighMotorRef.motorSpeed = -hingeSpeed;
            leftThighMotorRef.motorSpeed = hingeSpeed;
            rightThigh.motor = rightThighMotorRef;
            leftThigh.motor = leftThighMotorRef;
        } 
        else if (Input.GetKey(KeyCode.W)) //if w pressed
        {
            rightThigh.useMotor = true;
            leftThigh.useMotor = true;
            rightThighMotorRef.motorSpeed = hingeSpeed;
            leftThighMotorRef.motorSpeed = -hingeSpeed;
            rightThigh.motor = rightThighMotorRef;
            leftThigh.motor = leftThighMotorRef;
        }
        else
        {
            rightThigh.useMotor = false;
            leftThigh.useMotor = false;
        }
        //CALVES
        //if o pressed
        if (Input.GetKey(KeyCode.O))
        {
            rightCalf.useMotor = true;
            leftCalf.useMotor = true;
            rightCalfMotorRef.motorSpeed = -hingeSpeed;
            leftCalfMotorRef.motorSpeed = hingeSpeed;
            rightCalf.motor = rightCalfMotorRef;
            leftCalf.motor = leftCalfMotorRef;
        }
        else if (Input.GetKey(KeyCode.P)) //if p pressed
        {
            rightCalf.useMotor = true;
            leftCalf.useMotor = true;
            rightCalfMotorRef.motorSpeed = hingeSpeed;
            leftCalfMotorRef.motorSpeed = -hingeSpeed;
            rightCalf.motor = rightCalfMotorRef;
            leftCalf.motor = leftCalfMotorRef;
        }
        else
        {
            rightThigh.useMotor = false;
            leftThigh.useMotor = false;
        }
    }
}
