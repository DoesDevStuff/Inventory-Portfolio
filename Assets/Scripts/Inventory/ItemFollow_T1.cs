using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollow_T1 : MonoBehaviour {

	// Update is called once per frame
	void LateUpdate () {
        transform.position = Input.mousePosition;
	}
}
