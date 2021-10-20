using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtraction : MonoBehaviour
{
    private void OnMouseDown()
    {
        Calculate Value = GameObject.Find("Calculate").GetComponent<Calculate>();

        Value.FunctionForSubtraction();
        GameObject.Find("Main Camera").transform.position = new Vector3(9.013f, 1.55f, -4.295f);
    }
}
