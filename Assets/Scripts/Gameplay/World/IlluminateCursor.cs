using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlluminateCursor : MonoBehaviour {

    public bool allowCloseIlluminate = true;

	// Update is called once per frame
	void Update () {
        if (allowCloseIlluminate)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 toCursor = (hit.point - transform.position);
                //Debug.Log(Vector3.Angle(playerTransform.forward, toCursor));
                transform.rotation = Quaternion.LookRotation(toCursor, transform.forward);
            }
        }
        else
        {
            Vector3 toCursor = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            //Debug.Log(Vector3.Angle(playerTransform.forward, toCursor));
            transform.rotation = Quaternion.LookRotation(toCursor, transform.forward);
        }
    }
}
