using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using AlstroemeriaUtility;
using System.Linq;

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
		InGame
	}

	/// <summary>
	/// 現在表示しているルートシーン
	/// </summary>
	private SceneType _currentViewScene;

	/// <summary>
	/// 表示するルートシーン(インスペクタ操作用)
	/// </summary>
	[SerializeField]
	private SceneType _viewScene;

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

		DisplayManager.OnSceneEnd();

		// ディスプレイ解放待ち
		while (DisplayManager.IsSwitching)
			yield return null;

		//TODO:シーン遷移中間処理の追加

		// フェード終了まで待機(まだ考えない)
		yield return null;

		// ローディングディスプレイの表示(ルートシーンの解放のためにも必要)



		AsyncOperation unLoad = SceneManager.UnloadSceneAsync(ROOT_SCENE_MAP[_currentViewScene]);

		// 解放が完了するまで待機
		while (!unLoad.isDone)
			yield return null;

		AsyncOperation load = SceneManager.LoadSceneAsync(ROOT_SCENE_MAP[nextScene], LoadSceneMode.Additive);

		// 読み込みが完了するまで待機
		while (!load.isDone)
			yield return null;

		Scene next = SceneManager.GetSceneByName(ROOT_SCENE_MAP[nextScene]);

		// ルートシーンクラスの取得
		yield return StartCoroutine(FindRootScene(next));

		// ローディングディスプレイを非表示に

		// シーン情報を渡す
		DisplayManager.OnSceneStart(_currentRootScene.SceneCache);

		// ディスプレイの表示
		DisplayManager.Switch(_currentRootScene.FirstUsingDisplay);

		_currentViewScene = nextScene;
		_viewScene = _currentViewScene;
		duringTransScene = false;
	}

	/// <summary>
	/// シーン切り替え
	/// </summary>
	public static void Switch(SceneType nextScene)
	{
		if (nextScene == SceneType.None)
			return;

		if (Instance.duringTransScene)
			return;

		Instance.StartCoroutine(Instance.SwitchAsync(nextScene));
	}

	private IRootScene _currentRootScene;

	private void OnValidate()
	{
		if (_viewScene == SceneType.None)
			return;

		Switch(_viewScene);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void OnEntryPoint()
	{
		var go = new GameObject(nameof(SceneRootManager));
		var root = go.AddComponent<SceneRootManager>();
		SceneType type = ROOT_SCENE_MAP
			.First(e => e.Value == SceneManager.GetActiveScene().name).Key;

		root._currentViewScene = type;
		root._viewScene = root._currentViewScene;
	}

	private IEnumerator FindRootScene(Scene scene)
	{
		// ルートオブジェクト取得
		GameObject[] goList = scene.GetRootGameObjects();

		if (goList.IsNullOrEmpty())
		{
			Debug.LogError("ルートシーンが取得できませんでした");
			yield break;
		}

		IRootScene root;

		foreach (var go in goList)
		{
			root = go.GetComponent<IRootScene>();

			if (root == null)
				continue;

			_currentRootScene = root;
			yield break;
		}

		Debug.LogError("ルートシーンが取得できませんでした");
	}
}

