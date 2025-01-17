using UnityEngine;
using Unity.Netcode;

public class emote : NetworkBehaviour
{

    float emoteTime;

    public override void OnNetworkSpawn()
    {
        emoteTime = Time.time + 3;
        Debug.Log("kill me in 3 sec");
    }

    private void Update() 
    {
        if (emoteTime < Time.time)
        {
            deSpawnEmoteServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    void deSpawnEmoteServerRpc()
    {
        NetworkObject me = gameObject.GetComponent<NetworkObject>();
        me.Despawn();
    }
}
