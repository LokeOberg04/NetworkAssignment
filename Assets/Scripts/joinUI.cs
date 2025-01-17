using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class joinUI : MonoBehaviour
{

    [SerializeField] Button hostButton;
    [SerializeField] Button clientButton;

    void Start()
    {
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            //Hide();
        });
        clientButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
            //Hide();
        });

    }

}
