using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class health : MonoBehaviourPunCallbacks,IPunObservable
{
    public int totalHealth = 100;
    public int currentHealth;

    public Text score;
    public Text victorStatus;
    spawnTroops fofId;

    PhotonView photonView;

    delegate void die();

    die playerDeath;

    

   /* private void OnEnable()
    {
        health.damage += updateHealth;
    }

    private void OnDisable()
    {
        health.damage -= updateHealth;
    }*/



    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        currentHealth = totalHealth;

        playerDeath += deathMessage;

        if (photonView.IsMine)
        {
            score = GameObject.Find("player health value").GetComponent<Text>();
        }
        if (!photonView.IsMine)
        {
            score = GameObject.Find("enemy health value").GetComponent<Text>();
        }


        fofId = GetComponent<spawnTroops>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score)
        {
            score.text = currentHealth.ToString();
        }
        if (currentHealth <= 0)
        {
            playerDeath();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {

        

        if (collision.gameObject.layer == 6 )
        {
            
            Debug.Log("the collision is" + collision.gameObject.name);
            photonView.RPC("hurt", RpcTarget.All); // use RPC to sync calls. so that the correct photon view is targeted.
            //currentHealth -= 10;
            
            
            
            PhotonNetwork.Destroy(collision.gameObject);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(currentHealth);
            
        }
        else
        {
            this.currentHealth = (int)stream.ReceiveNext();
            
        }
    }


    [PunRPC]
    void hurt()
    {
        
            currentHealth -= 10;
    }

    void deathMessage()
    {
        if (photonView.IsMine)
        {
            Debug.Log("YOU LOSE");
            victorStatus = GameObject.Find("VictorStatus").GetComponent<Text>();
            victorStatus.text = "YOU LOSE";
        }
        else
        {
            Debug.Log("YOU WIN");
            victorStatus = GameObject.Find("VictorStatus").GetComponent<Text>();
            victorStatus.text = "YOU WIN";
        }
        Time.timeScale = 0;
            
    }
    
}
