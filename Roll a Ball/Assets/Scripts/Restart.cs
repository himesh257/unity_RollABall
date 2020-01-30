using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Button btn;

    void Start()
    {
        btn.onClick.AddListener(reset);
    }

    void reset()
    {
        Application.LoadLevel(0);
    }
}
