using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public static Point instance;
    private int point=0;
    public Text text;
    public GameObject gate;
    private void Start()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int value)
    {
        point = point + value;
        text.text = point.ToString();
        Debug.Log(point);

        if (point==5)
        {
            gate.SetActive(true);
        }
    }

}
