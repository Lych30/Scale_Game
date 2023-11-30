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
        ESReference.instance.eventSystem.SetSelectedGameObject(_quitButton.gameObject);
    }

    public void Reward()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }
}
