using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedControll : MonoBehaviour
{

    simpleCarController scp;
    [SerializeField]Text text;
    // Start is called before the first frame update
    void Start()
    {
        scp = FindObjectOfType<simpleCarController>();        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = scp.KPH.ToString();
    }
}
