using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject PlayerRigidBody;
    [SerializeField] GameObject PlayerCar;
    [SerializeField] Transform SpawnTarget;
    [SerializeField] CameraFollow camera;
    GameObject CurentPlayer;
    bool carIsDead = false;
    int playerIndex = 0;


    private void Awake()
    {        
        CurentPlayer = PlayerCar;
        playerIndex = 1;       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print(other.name);
            changePlayer();
        }
        print("notWork");
    }

    void Start()
    {
        CurentPlayer.transform.position = SpawnTarget.position;
        CurentPlayer.SetActive(true);
        camera.target = CurentPlayer.transform;
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
        camera.target = CurentPlayer.transform;
    }

    void changePlayer()
    {
        if (playerIndex == 1)
        {
            CurentPlayer.SetActive(false);
            CurentPlayer = PlayerRigidBody;
            playerIndex = 2;
            instPlayer();
        }
        else if (playerIndex == 2)
        {
            CurentPlayer.SetActive(false);
            CurentPlayer = PlayerCar;
            playerIndex = 1;            
            instPlayer();
        }
    }
}
