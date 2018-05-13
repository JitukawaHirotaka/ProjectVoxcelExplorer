using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileInput
{
    /// <summary>
    /// タッチ入力単体のパラメータ
    /// </summary>
    /// <remarks>
    /// タッチパネルに触れた時に生成され、
    /// タッチパネルから離れた時、削除されます
    /// </remarks>
    public class Finger
    {
        public uint RegistIndex
        {
            get { return RegistIndex; }
        }

        private uint registIndex;
        public Touch touch;

        public Finger(uint fingerIndex, Touch touch)
        {
            registIndex = fingerIndex;
            this.touch = touch;
        }
    }

    public class Tap
    {
        public Finger finger;

        public Tap(Finger finger)
        {
            this.finger = finger;
        }
    }

    public class Pinch
    {
        public Finger finger;
        /// <summary>
        /// 拡縮量 
        /// 拡大は+の値
        /// 縮小は-の値で返却される
        /// </summary>
        public float scale;

        public Pinch(Finger finger)
        {
            this.finger = finger;
        }
    }

    public class Swipe
    {
        public Finger finger;
        /// <summary>
        /// 移動量
        /// XはHorizontal
        /// YはVertical
        /// </summary>
        public Vector2 axis;
    }

    /// <summary>
    /// 分かりずらいので要相談
    /// </summary>
    public static class Util
    {
        public static bool IsWithinRange(this uint fingerIndex)
        {
            return 0 <= fingerIndex && fingerIndex < Manager.MaxFingerSize;
        }
    }
}
