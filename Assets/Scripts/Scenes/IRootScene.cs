using UnityEngine.SceneManagement;

/// <summary>
/// ルート(メイン)シーン　インターフェイス
/// </summary>
public interface IRootScene
{
	/// <summary>
	/// このオブジェクトが存在するシーン
	/// </summary>
	Scene FromScene
	{
		get;
	}

	/// <summary>
	/// 外部シーンが利用できるデータキャッシュ
	/// </summary>
	ISceneCache SceneCache
	{
		get;
	}

	/// <summary>
	/// シーン生成時に最初に表示されるディスプレイ
	/// </summary>
	DisplayManager.DisplayType FirstUsingDisplay
	{
		get;
	}

	/// <summary>
	/// 画面遷移開始時実行イベント
	/// </summary>
	void OnSwitchBegin();

	/// <summary>
	/// 画面遷移終了時実行イベント
	/// </summary>
	void OnSwitchEnd();
}