using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using AlstroemeriaUtility;

namespace MobileInput
{
    /// <summary>
    /// 入力イベントを管理するクラス
    /// </summary>
    public class Manager : ISystemProcess
    {
        /// <summary>
        /// 入力を検知する指の最大数
        /// </summary>
        public const uint MaxFingerSize = 5;

        /// <summary>
        /// 現在タッチされている指
        /// </summary>
        public List<Finger> fingers = null;



        public Handler handler;

        public Manager()
        {
            fingers = new List<Finger>();
            handler = new Handler();
        }

        public void OnStart()
        {
            handler.OnStart();
        }

        public void OnUpdate()
        {
#if DEBUG
            if (Input.GetMouseButtonDown(0))
            {
                var touch = new Touch();
                touch.phase = TouchPhase.Began;
                touch.position = Input.mousePosition;
                touch.deltaPosition = Input.mouseScrollDelta;
                fingers.Add(new Finger((uint)fingers.Count, touch));
            }

            if (Input.GetMouseButton(0))
            {
                var finger = fingers[0];
                finger.touch.phase = TouchPhase.Stationary;
                finger.touch.position = Input.mousePosition;
                finger.touch.deltaPosition = Input.mouseScrollDelta;
            }

            if (Input.GetMouseButtonUp(0))
            {
                var finger = fingers[0];
                finger.touch.phase = TouchPhase.Ended;
                finger.touch.position = Input.mousePosition;
                finger.touch.deltaPosition = Input.mouseScrollDelta;
            }
#else
			Input.touches?.ForEach<Touch>((touch) =>
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        fingers.Add(new Finger((uint)fingers.Count, touch));
						Debug.Log($"同時に{fingers.Count}本の入力を検知しました");
                        break;
                    case TouchPhase.Moved:
						fingers
							.First(e => e.RegistIndex == touch.fingerId)
						    .touch = touch;
                        break;
                }
            });
#endif
            handler.OnUpdate(fingers);

            fingers?.RemoveAll(e =>
            {
                if (e.touch.phase == TouchPhase.Ended)
                {
                    Debug.LogWarning($"{e.RegistIndex}番目の入力情報が途絶えました");
                    return true;
                }

                return false;
            });
        }

        public void OnTeam()
        {
            handler.OnTeam();
        }
    }
}