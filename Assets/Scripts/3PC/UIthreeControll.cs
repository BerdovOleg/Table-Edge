using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIthreeControll : MonoBehaviour
{
    [SerializeField] GameObject _Canvas;
    [SerializeField] InputField iputPlayerSpeed;
    [SerializeField] InputField iputPlayerJump;
    [SerializeField] InputField iputPlayerGV;
    [SerializeField] Text txtMouseSens;
    [SerializeField] Scrollbar scrollbarMS;

    [SerializeField] CinemachineFreeLook look;
    [SerializeField] PlayerControl  _Player;

    float scrollText;
    private bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        GetParams();
        _Canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void GetParams()
    {
        iputPlayerSpeed.text = _Player.speed.ToString();
        iputPlayerJump.text = _Player.jumpForse.ToString();
        iputPlayerGV.text = _Player.gravityScale.ToString();
        txtMouseSens.text = GetmouseSens().ToString();
        scrollbarMS.value = GetmouseSens();
        scrollText = scrollbarMS.value;
    }

    private float GetmouseSens()
    {
        float senseY = look.m_YAxis.m_MaxSpeed;
        float senseX = look.m_XAxis.m_MaxSpeed;
        return senseY/10;
    }

    public void SetParams()
    {
        _Player.speed = float.Parse(iputPlayerSpeed.text);
        _Player.jumpForse = float.Parse(iputPlayerJump.text);
        _Player.gravityScale = float.Parse(iputPlayerGV.text);
        SetMouseSens(float.Parse(txtMouseSens.text));
    }

    private void SetMouseSens(float v)
    {
        look.m_YAxis.m_MaxSpeed = v * 10;
        look.m_XAxis.m_MaxSpeed = v * 1000;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !pause)
        {
            Debug.Log(pause);
            Cursor.lockState = CursorLockMode.None;
            _Canvas.SetActive(true);
            pause = true;
            _Player.pause = pause;            
            
        }
        else if (Input.GetButtonDown("Cancel") && pause)
        {
            Debug.Log(pause);
            Cursor.lockState = CursorLockMode.None;
            _Canvas.SetActive(false);
            pause = false;
            _Player.pause = pause;
        }


        if (scrollbarMS.value != scrollText)
        {
            txtMouseSens.text = (scrollbarMS.value).ToString();
            scrollText = scrollbarMS.value;
        }
    }
}
