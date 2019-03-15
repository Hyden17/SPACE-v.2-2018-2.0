using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TimeMngr
{
    public class TimeManagement
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }

    public class Timer : MonoBehaviour
    {
        public float TimerLength;
        public float TimeLeft;
        public bool IsRunning;
        bool TimerFinished = true;


        public bool CheckTimer()
        {
            return TimerFinished;
        }

        public void SetTime(float time)
        {
            TimerLength = time;
        }



        public void ForceFinish()
        {
            IsRunning = false;
            TimeLeft = 0;
            TimerFinished = true;
        }

        void Update()
        {
            if(IsRunning == true)
            {
                TimeLeft -= Time.deltaTime;
            }
            if(TimeLeft <= 0)
            {
                TimerFinished = true;
                IsRunning = false;
            }

        }

        public void RunTimer()
        {
            IsRunning = true;
        }

        public void ResetAndRun()
        {
            ResetTimer();
            RunTimer();
        }

        public void ResetTimer()
        {
            TimeLeft = TimerLength;
            TimerFinished = false;
            IsRunning = false;
        }


    }
}