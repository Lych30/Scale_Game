using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _container;
    [SerializeField] Button _quitButton;
    public void TriggerGO()
    {
        _container.SetActive(true);
        _quitButton.interactable = true;
        PlayerManager.instance.GetComponent<PlayerMovement>()._canMove = false;
        PlayerManager.instance.GetComponent<PlayerInteract>().CanInteract = false;

        ESReference.instance.eventSystem.SetSelectedGameObject(_quitButton.gameObject);

    }

    public void Reward()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }
}
