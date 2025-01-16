using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;
using Cinemachine;

public class ClientPlayerMove : NetworkBehaviour
{
    [SerializeField]
    CharacterController m_CharacterController;
    [SerializeField]
    ThirdPersonController m_ThirdPersonController;
    [SerializeField]
    PlayerInput m_PlayerInput;
    [SerializeField]
    CinemachineVirtualCamera Cinemachine;
    [SerializeField]
    Camera Camera;
    [SerializeField]
    PlayerEmote playeremote;
    [SerializeField]
    PlayerAttack playerattack;


    [SerializeField]
    Transform m_CameraFollow;

    void Awake()
    {
        m_CharacterController.enabled = false;
        m_ThirdPersonController.enabled = false;
        m_PlayerInput.enabled = false;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        enabled = IsClient; // has to be client

        // if its not ours
        if(!IsOwner)
        {
            enabled = false;
            m_CharacterController.enabled =false;
            m_ThirdPersonController.enabled = false;
            m_PlayerInput.enabled = false;
            Cinemachine.enabled = false;
            Camera.enabled = false;
            playeremote.enabled = false;
            playerattack.enabled = false;
            return;
        }

        // this is ours now

        m_CharacterController.enabled = true;
        m_ThirdPersonController.enabled = true;
        m_PlayerInput.enabled = true;
        Cinemachine.enabled = true;
        Camera.enabled = true;
        playeremote.enabled = true;
        playerattack.enabled = true;

    }
}

