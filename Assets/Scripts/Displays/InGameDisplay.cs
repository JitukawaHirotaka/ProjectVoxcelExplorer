using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// InGameDisplay class
/// </summary>
public class InGameDisplay : DisplayBase
{
	/// <summary>
	/// ディスプレイイベントの定義インターフェイス
	/// </summary>
	public override IEvents DisplayEvents
	{
		get { return _events; }
	}

	/// <summary>
	/// UIオブジェクト呼び出しイベントクラス
	/// </summary>
	public InGameEvents _events = new InGameEvents();
}