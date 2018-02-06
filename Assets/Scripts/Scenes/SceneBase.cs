using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン基底クラス
/// </summary>
public abstract class SceneBase<T> : MonoBehaviour where T : SceneBase<T>
{
	/// <summary>
	/// このオブジェクトが存在するシーン
	/// </summary>
	public Scene FromScene
	{
		get { return gameObject.scene; }
	}

	/// <summary>
	/// 派生クラスのインスタンスを取得
	/// </summary>
	protected abstract T GetOverrideInstance();

	/// <summary>
	/// シーン生成時に最初に表示されるディスプレイ
	/// </summary>
	[SerializeField]
	protected DisplayManager.DisplayType firstUsingDisplay;
}
