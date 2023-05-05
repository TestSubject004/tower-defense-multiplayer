using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class soldierNavmesh : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    private NavMeshAgent navMeshAgent;
    spawnTroops[] fofList;
    public int fofId;

    

    private void Awake()
    {
        



    }
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //targetTransform = GameObject.Find("enemyTower").transform;
        fofList = FindObjectsOfType<spawnTroops>(); //we find all players (there's two of them)
        Debug.Log(fofList.Length);
        foreach (spawnTroops sp in fofList) // we check if the player has the samefofID as the soldier, if yes, we find the next player. once the player towers fof dont match, they become enemy and get fucked.
        {
            if (fofId != sp.FOFid)
            {
                targetTransform = sp.gameObject.transform;
                break;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = targetTransform.position;
        transform.LookAt(targetTransform);

    }
}
