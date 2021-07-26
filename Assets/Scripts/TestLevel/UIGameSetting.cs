using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Vehicles.Car;

public class UIGameSetting : MonoBehaviour
{
    [Header("Меню")]
    bool EscapeMenu = false;
    bool GDMenu = false;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject GDpanel;
    [SerializeField] GameObject BG;

    [Space(2)]
    [Header("Параметры игрока")]
   
    float _scaleCar;
    [SerializeField] InputField scaleCharacter;
    float _scaleCharacter;
    [SerializeField] ThirdPersonCharacter rbPlayer;
    [SerializeField] PlayerControlCamUP player;

    [SerializeField] InputField _inSpeedPlayer;
    float playerSpd;
    [SerializeField] InputField _inJumpFPlayer;
    float Jpower;
    [SerializeField] Text _txtturnSmoothTime;
    [SerializeField] Slider _SlideturnSmoothTime;
    float animSpd;
    [Space(1)]

    [Header("Параметры Жука")]
    [SerializeField] CarController Car;
    [SerializeField] InputField scaleCar;
    [SerializeField] Text curSpd;
    [SerializeField] InputField in_mass;
    [SerializeField] InputField in_MaximumSteerAngle;
    [SerializeField] Slider Slid_steerHelper;
    [SerializeField] Text txt_steerHelper;
    [SerializeField] Slider Slid_TractionControl;
    [SerializeField] Text txt_TractionControl;
    [SerializeField] InputField in_FullTorqueOverAllWheels;
    [SerializeField] InputField in_ReverseTorque;
    [SerializeField] InputField in_MaxHandbrakeTorque;
    [SerializeField] InputField in_Downforce;
    [SerializeField] InputField in_Topspeed;
    [SerializeField] InputField in_RevRangeBoundary;
    [SerializeField] InputField in_SlipLimit;
    [SerializeField] InputField in_BrakeTorque;
    [SerializeField] Text clue;
    bool _showClue = false;

    [Space(1)]
    [Header("Мироввые параметры")]
    [SerializeField] InputField gravity;
    float _gravity;
    [Space (1)]
    [Header("Параметры Камеры")]
    [SerializeField] CinemachineVirtualCamera camera;
    
    [SerializeField] InputField x_pos;
    [SerializeField] InputField y_pos;
    [SerializeField] InputField z_pos;
    Vector3 camPos;
    [SerializeField] InputField fieldOfView;
    float _fieldOfView;
    [SerializeField] InputField x_dumping;
    [SerializeField] InputField y_dumping;
    [SerializeField] InputField z_dumping;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControlCamUP>();
        camera = FindObjectOfType<CinemachineVirtualCamera>();
        GetParams();
    }

    void GetCarParams()
    {
        //Получение значения размера жука
        _scaleCar = Car.gameObject.transform.localScale.x;
        scaleCar.text = _scaleCar.ToString();

        //Получение значения массы жука
        in_mass.text = Car.gameObject.GetComponent<Rigidbody>().mass.ToString();

        //Получение значения максимального угла поворота колес
        in_MaximumSteerAngle.text = Car.m_MaximumSteerAngle.ToString();
        //Получение значения сложности управления
        Slid_steerHelper.value = Car.m_SteerHelper;
        //Получение значения контроля тяги
        Slid_TractionControl.value = Car.m_TractionControl;
        //Получение значения максимум оборотов
        in_FullTorqueOverAllWheels.text = Car.m_FullTorqueOverAllWheels.ToString();
        //Получение значения обратной тяги
        in_ReverseTorque.text = Car.m_ReverseTorque.ToString();
        //Получение значения тяги ручного тормоза
        in_MaxHandbrakeTorque.text = Car.m_MaxHandbrakeTorque.ToString();
        //Получение значения прижимной силы
        in_Downforce.text = Car.m_Downforce.ToString();
        //Получение значения максимальной скорости
        in_Topspeed.text = Car.m_Topspeed.ToString();
        //Получение значения границы оборотов
        in_RevRangeBoundary.text = Car.m_RevRangeBoundary.ToString();
        //Получение значения предела скольжения
        in_SlipLimit.text = Car.m_SlipLimit.ToString();
        //Получение значения тормозного момента
        in_BrakeTorque.text = Car.m_BrakeTorque.ToString();

    }

    public void ShowClue()
    {
        clue.gameObject.SetActive(!_showClue);
        _showClue = !_showClue;
    }

    public void SetCarParams()
    {
        //установка новых параметров размеров жука
        Car.gameObject.transform.localScale = new Vector3(float.Parse(scaleCar.text), float.Parse(scaleCar.text), float.Parse(scaleCar.text));

        //установка новых параметров массы жука
        Car.gameObject.GetComponent<Rigidbody>().mass = float.Parse(in_mass.text);

        //установка новых параметров максимального угла поворота колес
        Car.m_MaximumSteerAngle = float.Parse(in_MaximumSteerAngle.text);
        //установка новых параметров сложности управления
        Car.m_SteerHelper = Slid_steerHelper.value;
        //установка новых параметров контроля тяги
         Car.m_TractionControl = Slid_TractionControl.value;
        //установка новых параметров максимум оборотов
        Car.m_FullTorqueOverAllWheels = float.Parse(in_FullTorqueOverAllWheels.text);
        //установка новых параметров обратной тяги
        Car.m_ReverseTorque = float.Parse(in_ReverseTorque.text);
        //установка новых параметров тяги ручного тормоза
        Car.m_MaxHandbrakeTorque = float.Parse(in_MaxHandbrakeTorque.text);
        //установка новых параметров прижимной силы
        Car.m_Downforce = float.Parse(in_Downforce.text);
        //установка новых параметров максимальной скорости
        Car.m_Topspeed = float.Parse(in_Topspeed.text);
        ///установка новых параметров границы оборотов
        Car.m_RevRangeBoundary = float.Parse(in_RevRangeBoundary.text);
        //установка новых параметров предела скольжения
        Car.m_SlipLimit = float.Parse(in_SlipLimit.text);
        //установка новых параметров тормозного момента
        Car.m_BrakeTorque = float.Parse(in_BrakeTorque.text);
    }

    private void GetParams()
    {
        //Получение значения размера наездника
        _scaleCharacter = rbPlayer.gameObject.transform.localScale.x;
        scaleCharacter.text = _scaleCharacter.ToString();
        //Получение значение параметра гравитации
       _gravity = rbPlayer.m_GravityMultiplier;
        gravity.text = _gravity.ToString();
        //Получение значение силы прыжка
        Jpower = rbPlayer.m_JumpPower;
        _inJumpFPlayer.text = Jpower.ToString();
        //Получение скорость передвижения
        playerSpd = rbPlayer.m_MoveSpeedMultiplier;
        _inSpeedPlayer.text = playerSpd.ToString();
        //Получение скорости анимации
        animSpd = rbPlayer.m_AnimSpeedMultiplier;
        _SlideturnSmoothTime.value = animSpd;
        ///Получение значение параметров камеры
        //camPos = 
        x_pos.text = camPos.x.ToString();
        y_pos.text = camPos.y.ToString();
        z_pos.text = camPos.z.ToString();

        _fieldOfView = camera.m_Lens.FieldOfView;
        fieldOfView.text = _fieldOfView.ToString();
    }


    public void SetParams()
    {
        //установка новых параметров камеры
        camera.m_Lens.FieldOfView = float.Parse(fieldOfView.text);
        //установка новых параметров гравитации
        if (gravity.text == null)
        {
            rbPlayer.m_GravityMultiplier = float.Parse(gravity.text);
        }
    }
    public void SetParamsCharacter()
    {
        //установка новых параметров размеры наездника
        rbPlayer.gameObject.transform.localScale = new Vector3(float.Parse(scaleCharacter.text), float.Parse(scaleCharacter.text), float.Parse(scaleCharacter.text));        
        //установка новых параметров силы прыжка наездника
        rbPlayer.m_JumpPower = float.Parse(_inJumpFPlayer.text);
        //установка новых параметров скорости наездника
        rbPlayer.m_MoveSpeedMultiplier = float.Parse(_inSpeedPlayer.text);
        //установка новых параметров скорости анимации наездник
        rbPlayer.m_AnimSpeedMultiplier = _SlideturnSmoothTime.value;        
    }

    public void GDPanelActive()
    {
        GDpanel.SetActive(GDMenu = !GDMenu);
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
        if (Input.GetKeyDown(KeyCode.Escape) && !EscapeMenu  )
        {
            MainMenu.SetActive(true);
            BG.SetActive(true);
            GetParams();
            GetCarParams();
            EscapeMenu = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && EscapeMenu)
        {
            MainMenu.SetActive(false);
            
            BG.SetActive(false);
            EscapeMenu = false;
        }

        if (GDMenu)
        {
            _txtturnSmoothTime.text = _SlideturnSmoothTime.value.ToString();
            txt_steerHelper.text = Slid_steerHelper.value.ToString();
            txt_TractionControl.text = Slid_TractionControl.value.ToString();
        }       


        //спидометр
        if (Car.gameObject.activeSelf)
        { curSpd.text = Mathf.Floor(Car.CurrentSpeed).ToString(); }
        else if (rbPlayer.gameObject.activeSelf)
        { curSpd.text = Mathf.Floor(rbPlayer.CurrentSpeedCharacter).ToString(); }
    }
}
