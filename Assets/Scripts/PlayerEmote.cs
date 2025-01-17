using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEmote : NetworkBehaviour
{
    [SerializeField] GameObject emotes;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spawnEmoteServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    void spawnEmoteServerRpc()
    {
        var instance = Instantiate(emotes);
        var instanceNetworkObject = instance.GetComponent<NetworkObject>();
        instance.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        instanceNetworkObject.Spawn();
        instance.transform.parent = transform;
        instance.transform.rotation = transform.rotation;
    }

}
