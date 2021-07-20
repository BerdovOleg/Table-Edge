using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject PlayerCharacterController;
    [SerializeField] GameObject PlayerRigidBody;
    [SerializeField] GameObject PlayerCar;
    [SerializeField] Transform SpawnTarget;
    [SerializeField] CinemachineStateDrivenCamera camera;
    GameObject CurentPlayer;
    bool carIsDead = false;
    int playerIndex = 0;

    private void Awake()
    {        
        CurentPlayer = PlayerCar;
        playerIndex = 1;       
    }

    void Start()
    {
        CurentPlayer.transform.position = SpawnTarget.position;
        CurentPlayer.SetActive(true);
        camera.Follow = CurentPlayer.transform;
        camera.LookAt = CurentPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            changePlayer();
        }
    }

    private void instPlayer()
    {
        CurentPlayer.transform.position = SpawnTarget.position;
        CurentPlayer.SetActive(true);
        camera.Follow = CurentPlayer.transform;
        camera.LookAt = CurentPlayer.transform;
    }

    void changePlayer()
    {
        if (playerIndex == 1)
        {
            CurentPlayer.SetActive(false);
            CurentPlayer = PlayerRigidBody;
            playerIndex = 2;
            instPlayer();
            print("W1");
        }
        else if (playerIndex == 2)
        {
            CurentPlayer.SetActive(false);
            CurentPlayer = PlayerCharacterController;
            playerIndex = 3;            
            instPlayer();
            print("W2");
        }
        else 
        {
            CurentPlayer.SetActive(false);
            CurentPlayer = PlayerCar;
            playerIndex = 1;
            instPlayer();
        }
    }

}
