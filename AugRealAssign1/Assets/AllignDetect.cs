using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllignDetect : MonoBehaviour {


    public Transform Landing;
    public float rightAllignValue;
    public float forwardAllignValue;
    public GameObject colorQuare;
    Color whateverColor = new Color(255, 0, 0, 1);

    public Vector3 spaceshipPos;
    public Vector3 landingVecForward;
    public Vector3 landingVecRight;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        landingVecForward = gameObject.transform.forward;
        landingVecRight = gameObject.transform.right;
        spaceshipPos = Landing.forward;

        forwardAllignValue = Vector3.Dot(landingVecForward, spaceshipPos);
        rightAllignValue = Vector3.Dot(landingVecRight, spaceshipPos);

        updateColor(forwardAllignValue, rightAllignValue);
	}

    void updateColor(float forwardAllignVal, float rightAllginval)
    {
        float rgbvalue = 255;
        //colorQuare.GetComponent<Renderer>().material.color = new Color(forwardAllignVal, 1 + rightAllignValue, 0);
        
        if (forwardAllignValue > 0.5)
        {

            // int rvalue = (int) (255 - (255 * allignVal));
            
            //Debug.Log("forwardAllignVal > 0.5");
            float allignvalueTurnedAround = 1 - forwardAllignValue;
            allignvalueTurnedAround = 2 * allignvalueTurnedAround;
            Debug.Log(allignvalueTurnedAround);
            colorQuare.GetComponent<Renderer>().material.color = new Color(allignvalueTurnedAround, 255, 0);

        }
        else if (forwardAllignVal > 0 && forwardAllignVal < 0.5)
        {

            
            float allignvalueTurnedAround = forwardAllignValue * 2;
            Debug.Log(forwardAllignValue);
            colorQuare.GetComponent<Renderer>().material.color = new Color(255, allignvalueTurnedAround, 0);
            
        }
        else
        {
            colorQuare.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
    }
}
