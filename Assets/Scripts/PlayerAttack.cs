using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : NetworkBehaviour
{
    [SerializeField] GameObject cheesePrefab;
     void OnMouseDown()
        {
        tryAndCheeseServerRpc();
    }
    [ServerRpc(RequireOwnership = false)]
    void tryAndCheeseServerRpc()
    {
        var instance = Instantiate(cheesePrefab);
        var instanceNetworkObject = instance.GetComponent<NetworkObject>();
        instance.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        instance.transform.position += transform.forward / 2;
        instanceNetworkObject.Spawn();
        instanceNetworkObject.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
    }
}
