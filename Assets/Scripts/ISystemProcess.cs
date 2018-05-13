/// <summary>
/// SystemProcessクラスで稼働させるシステムクラス用のインターフェイス
/// </summary>
public interface ISystemProcess
{
    /// <summary>
    /// 当インターフェイス継承クラスの初期化時に呼び出されるイベント関数
    /// </summary>
    void OnStart();

    /// <summary>
    /// 当インターフェイス継承クラスの毎フレーム呼び出されるイベント関数
    /// </summary>
    void OnUpdate();

    /// <summary>
    /// 当インターフェイス継承クラスの終了時に呼び出されるイベント関数
    /// </summary>
    void OnTeam();
}
