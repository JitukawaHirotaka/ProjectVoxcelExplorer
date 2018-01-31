using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// シーン基底クラス
/// </summary>
public abstract class SceneBase<T> : MonoBehaviour where T : SceneBase<T>
{
	/// <summary>
	/// メインシーンの種類
	/// </summary>
	public enum SceneType : byte
	{
		None = 0,
		Title,
		InGame,
		Max
	}

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
	/// メインシーンタイプとシーンの紐付けマップ
	/// </summary>
	protected static readonly Dictionary<SceneType, string> SCENE_MAP = 
		new Dictionary<SceneType, string>
	{
		{ SceneType.Title, "Title" },
		{ SceneType.InGame, "InGame" },
	};

	/// <summary>
	/// シーン遷移中かどうか
	/// </summary>
	protected bool duringTransScene = false;

	/// <summary>
	/// シーン切り替え
	/// </summary>
	public virtual void Switch(SceneType nextScene)
	{
		if (duringTransScene)
			return;

		StartCoroutine(SwitchAsync(nextScene));
	}

	/// <summary>
	/// 派生クラスのインスタンスを取得
	/// </summary>
	protected abstract T GetOverrideInstance();

	/// <summary>
	/// 非同期シーン切り替え
	/// </summary>
	protected IEnumerator SwitchAsync(SceneType nextScene)
	{
		duringTransScene = true;

		yield return null;

		SceneManager.LoadSceneAsync(SCENE_MAP[nextScene], LoadSceneMode.Single);
	}
}
