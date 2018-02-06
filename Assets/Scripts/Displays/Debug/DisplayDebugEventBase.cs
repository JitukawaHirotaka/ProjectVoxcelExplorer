using UnityEngine;

/// <summary>
/// デバッグ用ディスプレイイベント呼び出しクラス
/// </summary>
//TODO:リフレクションを用いて、継承無しで呼び出せるようにする
public abstract class DisplayDebugEventBase : MonoBehaviour 
{
	/// <summary>
	/// デバッグ用イベントクラス
	/// </summary>
	public DisplayDebugger.DebugEvents DebugEvents
	{
		get { return debugEvents; }
	}

	/// <summary>
	/// デバッグ用イベントクラス
	/// </summary>
	protected DisplayDebugger.DebugEvents debugEvents = new DisplayDebugger.DebugEvents();

	/// <summary>
	/// 初期化時実行イベント
	/// </summary>
	public abstract void OnAwake();
}