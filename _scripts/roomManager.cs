using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class roomManager : MonoBehaviourPunCallbacks
{
    public Transform spawn1;
    public Transform spawn2;

    public Text enemyHealth;
    public Text playerHealth;

    public GameObject gameOverscreen;

    public delegate void twoPlayersJoined();

    public static twoPlayersJoined activateCombatButtons;

    bool checkPlayercount = true;

    

    bool player1joined = false;
    bool player2joined = false;

    public GameObject mainScreen;

    bool hostGame=false, joinGame=false;

    

    PhotonView[] players;

   /* private void OnEnable()
    {
        health.damage += updateHealth;
    }

    private void OnDisable()
    {
        health.damage -= updateHealth;
    }
*/

    // Start is called before the first frame update
    void Start()
    {
        
        
        Debug.Log("connecting...");
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

       /* if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && checkCount)
        {
            Debug.Log("firing");

            activateCombatButtons?.Invoke();
            PhotonNetwork.CurrentRoom.IsOpen = false;
            checkCount = false;

        }*/

        /*if(player1joined && player2joined)
        {
            players = FindObjectsOfType<PhotonView>();
            player1joined = false;
            player2joined = false;
            updateScore = true;
        }

        if (updateScore)
        {
            sortPlayers();
        }*/

    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("connected to server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
       
        base.OnJoinedLobby();
        //PhotonNetwork.JoinOrCreateRoom("test", null, null);//testing for new stuff, adding discrete join/ host button, commenting this out
        StartCoroutine(host());
        Debug.Log("connected in a room now");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("we are connected and in a room");

        

        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            GameObject player = PhotonNetwork.Instantiate("playerTower", spawn1.position, Quaternion.identity);
            spawnTroops fofId = player.GetComponent<spawnTroops>();
            
            fofId.FOFid = PhotonNetwork.LocalPlayer.ActorNumber;
            player1joined = true;
            Debug.Log("YOU ARE MASTER");
        }
        else
        {
            GameObject player = PhotonNetwork.Instantiate("playerTower", spawn2.position, Quaternion.identity);
            spawnTroops fofId = player.GetComponent<spawnTroops>();
            fofId.FOFid = PhotonNetwork.LocalPlayer.ActorNumber;
            player2joined = true;
        }

        



    }

    IEnumerator host()
    {
        yield return new WaitUntil(() => hostGame || joinGame);
        if (hostGame)
            PhotonNetwork.CreateRoom(null, null, null);
        else if (joinGame)
            PhotonNetwork.JoinRandomRoom();
    }

    public void Hhost()
    {
        mainScreen.SetActive(false);
        hostGame = true;
        joinGame = false;
        
    }

    public void Jjoin()
    {
        mainScreen.SetActive(false);
        hostGame = false;
        joinGame = true;
        
    }

    
}
