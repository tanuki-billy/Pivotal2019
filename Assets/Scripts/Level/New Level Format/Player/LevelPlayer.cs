using UnityEngine;
using System;

namespace ElementStudio.Pivotal.Levels
{
    //Class responsible for managing the play state of a Pivotal level.
    public class LevelPlayer : MonoBehaviour
    {
        //Singleton instance variable
        public static LevelPlayer instance;

        //Variables that might want to be kept track of.
        public float levelTime = 0f;    //The current timer of the level.
        public bool isPaused = false;   //Are we paused at the moment?
        public bool timeRunning = false;    //Is time running?

        //Events and delegates for handling things such as level load, start, and finish
        public event Action LevelLoaded;
        public event Action LevelStarted;
        public event Action LevelFinished;
        public event Action<bool> LevelPaused;

        //Instantiate singleton
        void Awake()
        {
            if (instance != null) Destroy(this.gameObject);
            instance = this;
        }

        //We've loaded the level, it's fair to start playing the level now.
        void Start()
        {
            OnLevelLoaded();
        }

        //Run in-game timer.
        void Update()
        {
            if (timeRunning)
            {
                levelTime += Time.unscaledDeltaTime;
            }
        }

        //Handle our events
        protected void OnLevelLoaded()
        {
            if (LevelLoaded != null) LevelLoaded();
        }

        protected void OnLevelStarted()
        {
            if (LevelStarted != null) LevelStarted();
        }

        protected void OnLevelFinished()
        {
            if (LevelFinished != null) LevelFinished();
        }

        protected void OnLevelPaused()
        {
            if (LevelPaused != null) LevelPaused(isPaused);
        }
    }
}