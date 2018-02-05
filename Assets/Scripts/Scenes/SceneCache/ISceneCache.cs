/// <summary>
/// シーン内で使用しているデータのキャッシュをまとめ、外部シーンで使用するデータ
/// </summary>
public interface ISceneCache
{
	/// <summary>
	/// このクラスに紐づいているルートシーン
	/// </summary>
	SceneRootManager.SceneType RootSceneType
	{
		get;
	}
}