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
        public bool TimerFinished;


        bool CheckTimer()
        {
            return TimerFinished;
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

        void RunTimer()
        {
            IsRunning = true;
        }

        void ResetTimer()
        {
            TimeLeft = TimerLength;
            TimerFinished = false;
            IsRunning = false;
        }


    }
}