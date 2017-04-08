using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
