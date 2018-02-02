/// <summary>
/// InGameScene class
/// </summary>
public class InGameScene : SceneBase<InGameScene>, IRootScene
{
	public override ISceneCache SceneCache
	{
		get { return null; }
	}

	protected override InGameScene GetOverrideInstance()
	{
		return this;
	}

	public void OnSwitchBegin()
	{
		throw new System.NotImplementedException();
	}

	public void OnSwitchEnd()
	{
		throw new System.NotImplementedException();
	}
}