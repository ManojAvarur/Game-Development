using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameTimeStore
{
    private static GameTimeStore _gameTimeStore;
    private float gameTime;
    private bool pauseGameTimer;
    public static GameTimeStore getInstance()
    {
        if (_gameTimeStore == null)
        {
            _gameTimeStore = new GameTimeStore();
            _gameTimeStore.init();
        }
        return _gameTimeStore;
    }
    private void init()
    {
        gameTime = 0f;
        _gameTimeStore.pauseGameTimer = false;
    }
    public string getCurrentTime(){
        int hours = Mathf.FloorToInt(gameTime / 3600f);
        int minutes = Mathf.FloorToInt((gameTime % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(gameTime % 60f);
        string newTime;
        if (hours > 0)
        {
            newTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }
        else
        {
            newTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        return newTime;
    }
    public GameTimeStore updateTime(float timeDelta){
        if (pauseGameTimer)
        {
            return this;
        }

        gameTime += Time.deltaTime;
        return this;
    }
    public GameTimeStore resetTimer()
    {
        _gameTimeStore.init();
        return this;
    }
    public GameTimeStore pauseTimer()
    {
        pauseGameTimer = true;
        return this;
    }

    public GameTimeStore increaseTime()
    {
        gameTime += 60f;
        return this;
    }

    public GameTimeStore decreaseTime()
    {
        gameTime -= 60f;

        if (gameTime < 0f) 
        {
            gameTime = 0f;
        }

        return this;
    }
}