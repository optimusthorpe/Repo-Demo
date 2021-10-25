using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(-1.62f, 1.55f, -4.295f);
    }
}
