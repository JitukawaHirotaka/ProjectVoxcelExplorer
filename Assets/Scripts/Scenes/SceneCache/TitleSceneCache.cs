/// <summary>
/// タイトルシーンのキャッシュデータ
/// </summary>
public class TitleSceneCache : SceneCacheBase, ISceneCache
{
	public override SceneRootManager.SceneType RootSceneType
	{
		get { return SceneRootManager.SceneType.Title; }
	}
}