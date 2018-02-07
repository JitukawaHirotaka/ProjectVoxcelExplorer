/// <summary>
/// LoadDisplay class
/// </summary>
public class LoadDisplay : DisplayBase
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
	public EventsBase _events = new EventsBase();
}