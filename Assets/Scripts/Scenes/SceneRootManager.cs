using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// ルート(メイン)シーンを管理するクラス
/// </summary>
public class SceneRootManager : SingletonMonoBehaviour<SceneRootManager>
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
	/// メインシーンタイプとシーンの紐付けマップ
	/// </summary>
	protected static readonly Dictionary<SceneType, string> ROOT_SCENE_MAP =
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
	/// 非同期シーン切り替え
	/// </summary>
	protected IEnumerator SwitchAsync(SceneType nextScene)
	{
		duringTransScene = true;

		// フェード終了まで待機
		yield return null;

		SceneManager.LoadSceneAsync(ROOT_SCENE_MAP[nextScene], LoadSceneMode.Single);
	}

	/// <summary>
	/// シーン切り替え
	/// </summary>
	public static void Switch(SceneType nextScene)
	{
		if (Instance.duringTransScene)
			return;

		Instance.StartCoroutine(Instance.SwitchAsync(nextScene));
	}
}