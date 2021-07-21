using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{
    [SerializeField] GameObject _Canvas;
    [SerializeField] InputField iputPlayerSpeed;
    [SerializeField] InputField iputPlayerJump;
    [SerializeField] InputField iputPlayerGV;
    [SerializeField] Text txtMouseSens;
    [SerializeField] Scrollbar scrollbarMS;

    [SerializeField] mouseLookControl _mouse;
    [SerializeField] firstPesonControl _Player;

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
        iputPlayerSpeed.text = _Player.moveSpeed.ToString();
        iputPlayerJump.text = _Player.jumpForse.ToString();
        iputPlayerGV.text = _Player.gravity.ToString();
        txtMouseSens.text = _mouse.mouseSensitivity.ToString();
        scrollbarMS.value = (_mouse.mouseSensitivity/1000);
        scrollText = scrollbarMS.value;
    }

    public void SetParams()
    {
        _Player.moveSpeed = float.Parse(iputPlayerSpeed.text);
        _Player.jumpForse = float.Parse(iputPlayerJump.text);
        _Player.gravity = float.Parse(iputPlayerGV.text);
        _mouse.mouseSensitivity = float.Parse(txtMouseSens.text);
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
            _mouse.pause = pause;
        }
        else if (Input.GetButtonDown("Cancel") && pause)
        {
            Debug.Log(pause);
            Cursor.lockState = CursorLockMode.None;
            _Canvas.SetActive(false);
            pause = false;
            _Player.pause = pause;
            _mouse.pause = pause;
        }


        if (scrollbarMS.value != scrollText)
        {
            txtMouseSens.text = (scrollbarMS.value * 1000).ToString();
            scrollText = scrollbarMS.value;
        }
    }
}
