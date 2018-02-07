using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TitleScene class
/// </summary>
public class TitleScene : SceneBase<TitleScene>, IRootScene
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

	protected override TitleScene GetOverrideInstance()
	{
		return this;
	}

	[SerializeField]
	private TitleSceneCache _cache;
}
