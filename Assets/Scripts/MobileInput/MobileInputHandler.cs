using UnityEngine;
using System.Collections.Generic;
using AlstroemeriaUtility;

namespace MobileInput
{
    public class Handler
    {
        private static Handler handler = null;

        private System.Action<Tap>[] tap = null;
        private System.Action<Tap>[] tapTrigger = null;
        private System.Action<Tap>[] tapRelease = null;
        private System.Action<Pinch>[] pinch = null;
        private System.Action<Swipe>[] swipe = null;

        public Handler()
        {
            handler = this;

            tap = new System.Action<Tap>[Manager.MaxFingerSize];
            tapTrigger = new System.Action<Tap>[Manager.MaxFingerSize];
            tapRelease = new System.Action<Tap>[Manager.MaxFingerSize];
            pinch = new System.Action<Pinch>[Manager.MaxFingerSize];
            swipe = new System.Action<Swipe>[Manager.MaxFingerSize];
        }

        public void OnStart()
        {

        }

        public void OnUpdate(List<Finger> fingers)
        {
            //tap.ForEach(e => e?.Invoke(default(Tap)));
            //pinch.ForEach(e => e?.Invoke());
            Input.touches?.ForEach<Touch>((touch, index) =>
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        //tapTrigger[index]?.Invoke();
                        break;
                    case TouchPhase.Moved:
                        break;
                    case TouchPhase.Ended:
                        break;
                }
            });

        }

        public void OnTeam()
        {

        }


        public static void Tap(uint fingerIndex, System.Action<Tap> action)
        {
            if (Handler.IsCreated() && fingerIndex.IsWithinRange())
            {
                handler.tap[fingerIndex] += action;
            }
        }

        public static void TapTrigger(uint fingerIndex, System.Action<Tap> action)
        {
            if (Handler.IsCreated() && fingerIndex.IsWithinRange())
            {
                handler.tapTrigger[fingerIndex] += action;
            }
        }

        public static void TapRelease(uint fingerIndex, System.Action<Tap> action)
        {
            if (Handler.IsCreated() && fingerIndex.IsWithinRange())
            {
                handler.tapRelease[fingerIndex] += action;
            }
        }

        public static void Pinth(uint fingerIndex, System.Action<Pinch> action)
        {
            if (Handler.IsCreated() && fingerIndex.IsWithinRange())
            {
                handler.pinch[fingerIndex] += action;
            }
        }

        public static void Swipe(uint fingerIndex, System.Action<Swipe> action)
        {
            if (Handler.IsCreated() && fingerIndex.IsWithinRange())
            {
                handler.swipe[fingerIndex] += action;
            }
        }

        private static bool IsCreated()
        {
            if (handler == null)
            {
#if DEBUG
                Debug.LogWarning("MobileInputHandler is not created");
#endif
            }

            return handler != null;
        }
    }
}