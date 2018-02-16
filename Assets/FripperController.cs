using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    private HingeJoint myhingeJoint;

    private float defaultAngle = 20;

    private float flickAngle = -20;

	// Use this for initialization
	void Start () {
        this.myhingeJoint = GetComponent<HingeJoint>();

        setAngle(this.defaultAngle);

	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.LeftArrow)&& tag == "LeftFripperTag")
        {
            setAngle(this.flickAngle);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)&& tag == "RightFripperTag")
        {
            setAngle(this.flickAngle);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)&& tag == "LeftFripperTag")
        {
            setAngle(this.defaultAngle);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)&& tag == "RightFripperTag")
        {
            setAngle(this.defaultAngle);
        }
	} 
    public void setAngle (float angle)
    {
        JointSpring jointSpr = this.myhingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myhingeJoint.spring = jointSpr;

    }
}
