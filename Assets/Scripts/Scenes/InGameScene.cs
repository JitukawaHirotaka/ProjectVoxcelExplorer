using UnityEngine;

/// <summary>
/// InGameScene class
/// </summary>
public class InGameScene : SceneBase<InGameScene>, IRootScene
{
	public ISceneCache SceneCache
	{
		get { return _cache; }
	}

	public DisplayManager.DisplayType FirstUsingDisplay
	{
		get { return firstUsingDisplay; }
	}

	public void OnSwitchBegin()
	{
		throw new System.NotImplementedException();
	}

	public void OnSwitchEnd()
	{
		throw new System.NotImplementedException();
	}

	protected override InGameScene GetOverrideInstance()
	{
		return this;
	}

	[SerializeField]
	private InGameSceneCache _cache;
}