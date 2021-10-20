using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Addition : MonoBehaviour
{
    private void OnMouseDown()
    {
        Calculate Value = GameObject.Find("Calculate").GetComponent<Calculate>();

        Value.FunctionForAddition();
        GameObject.Find("Main Camera").transform.position = new Vector3(8.56f, 1.55f, -4.684f);
    }
}
