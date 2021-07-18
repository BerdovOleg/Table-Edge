using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class UIGameSetting : MonoBehaviour
{
    [Header("Меню")]
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject GDpanel;
    [Space(2)]
    [Header("Параметры игрока")]
    [SerializeField] PlayerControlCamUP player;
    [SerializeField] InputField _inSpeedPlayer;
    [SerializeField] InputField _inJumpFPlayer;
    [SerializeField] Text _txtturnSmoothTime;
    [SerializeField] Slider _SlideturnSmoothTime;
    [Space(1)]
    [Header("Мироввые параметры")]
    [SerializeField] InputField gravity;
    [Space (1)]
    [Header("Параметры Камеры")]
    [SerializeField] CinemachineStateDrivenCamera camera;
    [SerializeField] InputField x_pos;
    [SerializeField] InputField y_pos;
    [SerializeField] InputField z_pos;
    [SerializeField] InputField Range;
    [SerializeField] InputField x_dumping;
    [SerializeField] InputField y_dumping;
    [SerializeField] InputField z_dumping;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControlCamUP>();
        camera = FindObjectOfType<CinemachineStateDrivenCamera>();

        // GetParams();
    }

    private void GetParams()
    {
       
    }

    private void SetParams()
    {
        throw new NotImplementedException();
    }

    public void GDPanelActive()
    {
        MainMenu.SetActive(false);
        GDpanel.SetActive(true);

    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
