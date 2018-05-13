using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform SampleTarget;

    void Start()
    {

    }

    void Update()
    {
        //TODO:InputManagerを作成する
        //例：タップ、ピッチ、スワイプのイベントを作成し、操作を必要とするメソッドをハンドリング出来るようにする
        //作成する理由：操作系イベントの発生条件の設定ミスを防ぐため（一つ一つの入力操作の判定条件を設定した場合、ミスした時に追いづらい）
        MoveHorizontal(Input.GetAxis("Horizontal"));
        MoveVertical(Input.GetAxis("Vertical"));
    }

    /// <summary>
    /// イベントハンドラ
	/// </summary>
    private void MoveHorizontal(float value)
    {

    }

    /// <summary>
    /// イベントハンドラ
    /// </summary>
    private void MoveVertical(float value)
    {

    }
}
