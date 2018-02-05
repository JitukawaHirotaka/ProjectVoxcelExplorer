using UnityEngine;

/// <summary>
/// ディスプレイで使用するシーン情報キャッシュクラス
/// </summary>
/// <remarks>
/// ディスプレイのUIオブジェクトが利用するシーンデータに合わせて追加、消去してください
/// ISceneCacheをはずしたい
/// </remarks>
public abstract class SceneCacheBase : MonoBehaviour, ISceneCache
{
	/// <summary>
	/// このクラスに紐づいているルートシーン
	/// </summary>
	public abstract SceneRootManager.SceneType RootSceneType
	{
		get;
	}
}