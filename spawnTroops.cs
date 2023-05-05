using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class spawnTroops : MonoBehaviour
{
    public GameObject troopsRed;
    public GameObject troopsBlue;
    private PhotonView photonView;
    public int FOFid;

    public Transform spawnPosRed;
    public Transform spawnPosBlue;

    public GameObject redButton;
    public GameObject blueButton;

    bool checkCount = true;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        //FOFid = PhotonNetwork.LocalPlayer.ActorNumber;
        
        roomManager.activateCombatButtons += combatButtonEnable;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && checkCount)
        {
            Debug.Log("firing");

            roomManager.activateCombatButtons?.Invoke();
            PhotonNetwork.CurrentRoom.IsOpen = false;
            checkCount = false;


        }
        /*if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameObject soldier = PhotonNetwork.Instantiate(troops.name, spawnPosRed.position, Quaternion.identity);//instantiate soldier
            soldierNavmesh fofTag = soldier.GetComponent<soldierNavmesh>();//find the soldiernavmesh component of the instantiate object (there we have the fof tag)
            fofTag.fofId = FOFid; // set the fof tag of the soldier to the same as the creator tower. we use it to idenitfy the enemy target
            *//*RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                GameObject soldier = PhotonNetwork.Instantiate(troops.name, hit.point+ new Vector3(0,1,0),Quaternion.identity);//instantiate soldier
                soldierNavmesh fofTag = soldier.GetComponent<soldierNavmesh>();//find the soldiernavmesh component of the instantiate object (there we have the fof tag)
                fofTag.fofId = FOFid; // set the fof tag of the soldier to the same as the creator tower. we use it to idenitfy the enemy target
            }*//*
            //commented the raycast solution to make the spawning easy and simple.
        }
        if (Input.GetMouseButtonUp(1))
        {
            GameObject soldier = PhotonNetwork.Instantiate(troops.name, spawnPosBlue.position, Quaternion.identity);//instantiate soldier
            soldierNavmesh fofTag = soldier.GetComponent<soldierNavmesh>();//find the soldiernavmesh component of the instantiate object (there we have the fof tag)
            fofTag.fofId = FOFid; // set the fof tag of the soldier to the same as the creator tower. we use it to idenitfy the enemy target

        }*/
    }
    public void spawnRedEnemy()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        GameObject soldier = PhotonNetwork.Instantiate(troopsRed.name, spawnPosRed.position, Quaternion.identity);//instantiate soldier
        soldierNavmesh fofTag = soldier.GetComponent<soldierNavmesh>();//find the soldiernavmesh component of the instantiate object (there we have the fof tag)
        fofTag.fofId = FOFid; // set the fof tag of the soldier to the same as the creator tower. we use it to idenitfy the enemy target
    }

    public void spawnBlueEnemy()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        GameObject soldier = PhotonNetwork.Instantiate(troopsBlue.name, spawnPosBlue.position, Quaternion.identity);//instantiate soldier
        soldierNavmesh fofTag = soldier.GetComponent<soldierNavmesh>();//find the soldiernavmesh component of the instantiate object (there we have the fof tag)
        fofTag.fofId = FOFid; // set the fof tag of the soldier to the same as the creator tower. we use it to idenitfy the enemy target
    }

    public void combatButtonEnable() {
        if (photonView.IsMine)
        {
            redButton.SetActive(true);
            blueButton.SetActive(true);
        }
    }
}

   
