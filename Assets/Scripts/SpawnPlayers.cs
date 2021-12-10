using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject cameraPrefab;

    public float minX, maxX;
    public float minZ, maxZ;
    public float minY, maxY;

    void Start()    
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        //PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);

        GameObject temp = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        //Debug.Log("Instantiating: " + temp.name);
        if (temp.GetComponent<PhotonView>().IsMine)
        {
            //Debug.Log("PhotonView Gotten: ");
            temp.GetComponent<PlayerController>().SetJoysticks(Instantiate(cameraPrefab, randomPosition, Quaternion.identity));
            //Debug.Log("PlayerController Got: ");
        }

    }
}
