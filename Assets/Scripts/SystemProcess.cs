using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// システムクラスの生成と更新を行うクラス
/// 仕様に合わせて変更する可能性あり
/// </summary>
public class SystemProcess : MonoBehaviour
{
    private List<ISystemProcess> processes = null;

	void Start () 
    {
        processes = new List<ISystemProcess>();
        processes.Add(MobileInput.Factory.Instantiate());

        foreach(var value in processes)
        {
            value.OnStart();
        }
    }

	void Update () 
    {
        foreach(var value in processes)
        {
            value.OnUpdate();
        }
	}
}
