using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;

    private int _score;

    void Awake()
    {
        EventManager.StartListening(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void OnDestroy()
    {
        EventManager.StopListening(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();

        settingsPopup.Close();
    }

    private void OnEnemyHit()
    {
        _score += 1;
        scoreLabel.text = _score.ToString();
    }

    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }
}
