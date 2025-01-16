using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerEmote : NetworkBehaviour
{
    [SerializeField] GameObject emotes;

    Queue<NetworkObject> emoteQueue = new Queue<NetworkObject>();

    float emoteTime;

    private void Update()
    {
        if(emoteQueue.Count > 0 && emoteTime < Time.time)
        {
            emoteQueue.Dequeue().Despawn();
        }


        if (Input.GetKeyDown(KeyCode.Alpha1) && emoteQueue.Count < 1)
        {
            var instance = Instantiate(emotes);
            var instanceNetworkObject = instance.GetComponent<NetworkObject>();
            instance.transform.position = new Vector3(transform.position.x,transform.position.y+2,transform.position.z);
            instanceNetworkObject.Spawn();
            emoteQueue.Enqueue(instanceNetworkObject);
            emoteTime = Time.time + 3;
        }
    }
}
