using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    private int pin1, pin2, pin3;
    private int goal1, goal2, goal3;
    public TextMeshProUGUI _goal1, 
        _goal2, 
        _goal3, 
        _pin1, 
        _pin2, 
        _pin3;
    public TextMeshProUGUI timer,
        GameOverText;
    float i;
    float time;
    public Canvas canvas;
    public Button _drill, _hammer, _lockpick, _game;
    bool game;
    // Start is called before the first frame update
    void Start()
    {
        game = true;
        canvas.enabled = false;
        Restart();
        _drill.onClick.AddListener(Drill);
        _hammer.onClick.AddListener(Hammer);
        _lockpick.onClick.AddListener(Lockpick);
        _game.onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
        i = UpdateTime(i, game);
        time = (Mathf.Round(i));
        timer.text = time.ToString();
        if (i <= 0)
            Loss();
        if (pin1 == goal1 && pin2 == goal2 && pin3 == goal3)
            Win();
    }

    public void Drill()
    {
        pin1 = pinAdd(pin1, 1);
        pin2 = pinSub(pin2, 1);
        UpdatePins();
    }

    public void Hammer()
    {
        pin1 = pinSub(pin1, 1);
        pin2 = pinAdd(pin2, 2);
        pin3 = pinSub(pin3, 1);
        UpdatePins();
    }

    public void Lockpick()
    {
        pin1 = pinSub(pin1, 1);
        pin2 = pinAdd(pin2, 1);
        pin3 = pinAdd(pin3, 1);
        UpdatePins();
    }

    public void Restart()
    {
        canvas.enabled = false;
        i = 60f;
        goal1 = Random.Range(1, 10);
        goal2 = Random.Range(1, 10);
        goal3 = Random.Range(1, 10);
        pin1 = Random.Range(1, 10);
        pin2 = Random.Range(1, 10);
        pin3 = Random.Range(1, 10);
        UpdatePins();
        game = true;
    }

    void Loss()
    {
        canvas.enabled = true;
        GameOverText.text = "You Lost...";
        game = false;
    }
    void Win()
    {
        canvas.enabled = true;
        GameOverText.text = "You Win!";
        game = false;
    }

    void UpdatePins()
    {
        _goal1.text = goal1.ToString();
        _goal2.text = goal2.ToString();
        _goal3.text = goal3.ToString();
        _pin1.text = pin1.ToString();
        _pin2.text = pin2.ToString();
        _pin3.text = pin3.ToString();
    }

    private int pinAdd(int pin, int i)
    {
        pin += i;
        if (pin >= 10)
            pin = 10;
        return pin;
    }

    private int pinSub(int pin, int i)
    {
        pin -= i;
        if (pin <= 0)
            pin = 0;
        return pin;
    }
    float UpdateTime(float time, bool i)
    {
        if (i)
            time = time - Time.deltaTime;
        return time;
    }
}
