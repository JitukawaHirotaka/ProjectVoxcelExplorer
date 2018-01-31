/// <summary>
/// InGameScene class
/// </summary>
public class InGameScene : SceneBase<InGameScene>
{
	public override ISceneCache SceneCache
	{
		get { return null; }
	}

	protected override InGameScene GetOverrideInstance()
	{
		return this;
	}
}