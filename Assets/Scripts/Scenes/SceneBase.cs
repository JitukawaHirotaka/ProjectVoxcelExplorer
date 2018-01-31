using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン基底クラス
/// </summary>
public abstract class SceneBase<T> : MonoBehaviour where T : SceneBase<T>, IRootScene
{
	/// <summary>
	/// このオブジェクトが存在するシーン
	/// </summary>
	public Scene FromScene
	{
		get { return gameObject.scene; }
	}

	/// <summary>
	/// 外部シーンが利用できるデータキャッシュ
	/// </summary>
	public abstract ISceneCache SceneCache
	{
		get;
	}

	/// <summary>
	/// 派生クラスのインスタンスを取得
	/// </summary>
	protected abstract T GetOverrideInstance();

	/// <summary>
	/// 画面遷移開始時実行イベント
	/// </summary>
	protected virtual void OnSwitchBegin()
	{

	}

	/// <summary>
	/// 画面遷移終了時実行イベント
	/// </summary>
	protected virtual void OnSwitchEnd()
	{

	}
}
