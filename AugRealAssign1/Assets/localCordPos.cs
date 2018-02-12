using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localCordPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Matrix4x4 modelTransform = transform.localToWorldMatrix;
        Debug.Log(modelTransform);
        transform.position = modelTransform.GetColumn(3);
        Debug.Log(modelTransform.GetColumn(3));
    }
}
