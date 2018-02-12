using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localCordPos : MonoBehaviour {

    public GameObject earth;
    public GameObject quare;
    public GameObject shuttle;

    //public Vector3 shuttleLocalPos;
    //public Vector3 earthlocalpos;
    public Vector3 quareLocalpos;
    public Vector3 shuttlePos;
    public Vector3 earthpos;
    public Vector3 quarepos;
    public Vector3 worldPos;
    public Vector3 shuttlematrixPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //earthlocalpos = earth.transform.localPosition;
        quareLocalpos = quare.transform.localPosition;
        //shuttleLocalPos = shuttle.transform.localPosition;


        earthpos = earth.transform.position;
        shuttlePos = shuttle.transform.position;


        //earth.transform.position
        //Matrix4x4 modelTransform = shuttle.transform.localToWorldMatrix;
        Matrix4x4 shuttlematrix = Matrix4x4.TRS(shuttlePos, shuttle.transform.rotation, shuttle.transform.localScale);
        shuttlematrixPos = shuttlematrix.MultiplyPoint3x4(quareLocalpos);
        Matrix4x4 earthmatrix = Matrix4x4.TRS(earthpos, earth.transform.rotation, earth.transform.localScale);
        Matrix4x4 earthmatrixinv = earthmatrix.inverse;
        worldPos = earthmatrixinv.MultiplyPoint3x4(shuttlematrixPos);
        //transform.position = modelTransform.GetColumn(3);
        //OnGUI();

        //Debug.Log(worldPos);
        //transform.position = modelTransform.GetColumn(3);
        //Vector3 forward = modelTransform.GetColumn(2);
        //Debug.Log(forward);
        //Debug.Log(modelTransform.GetColumn(3));
    }
    void OnGUI()
    {
        GUI.color = Color.red;
        //GUI.Label(new Rect(10, 10, 500, 100), "Earth position: " + earthpos.normalized);
        //GUI.Label(new Rect(10, 30, 500, 100), "quarepos position: " + quarepos.normalized);
        //GUI.Label(new Rect(10, 50, 500, 100), "quareLocalpos position: " + quareLocalpos.normalized);


        GUI.Label(new Rect(10, 10, 500, 100), "worldpos position X: " + worldPos.x);
        GUI.Label(new Rect(10, 30, 500, 100), "worldpos position Y: " + worldPos.y);
        GUI.Label(new Rect(10, 50, 500, 100), "worldpos position Z:  " + worldPos.z);

    }
}
