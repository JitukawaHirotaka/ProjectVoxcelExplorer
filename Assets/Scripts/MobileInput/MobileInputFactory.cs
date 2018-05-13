namespace MobileInput
{   
    /// <summary>
    /// 入力クラスを生成する
    /// </summary>
    public class Factory
    {
        public static ISystemProcess Instantiate()
        {
            return new Manager();
        }
    }
}
