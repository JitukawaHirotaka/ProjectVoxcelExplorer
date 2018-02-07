/// <summary>
/// InGameTitleSceneCache class
/// </summary>
public class InGameSceneCache : SceneCacheBase, ISceneCache
{
	public override SceneRootManager.SceneType RootSceneType
	{
		get { return SceneRootManager.SceneType.InGame; }
	}
}