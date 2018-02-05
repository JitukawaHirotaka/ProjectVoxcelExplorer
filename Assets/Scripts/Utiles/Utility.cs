using System.Collections.Generic;
using System.Linq;
using System;

/// <summary>
/// alstroemeriaUtility 名前空間
/// 製作者：実川
/// </summary>
namespace AlstroemeriaUtility
{
	public static class EnumerableExtensions
	{
		public static Decimal[] SumDoubleArray(this IEnumerable<Decimal[][]> element, int arraySize)
		{
			Decimal[] result = element
				.SelectMany(x => x.Select(e =>
				{
					Decimal num1 = new Decimal(0);
					foreach (Decimal num2 in e)
						num1 += num2;
					return num1;
				}))
				.ToArray();

			return result;
		}

		/// <summary>
		/// 選択した範囲の要素を取り出す
		/// </summary>
		public static IEnumerable<T> ElementsRange<T>(this IEnumerable<T> element, int beginIndex, int endIndex)
		{
			return element.Skip(beginIndex).Take(endIndex - beginIndex);
		}

		/// <summary>
		/// 最大値の要素が格納されている番号を取得する
		/// </summary>
		public static int FindIndexMax<T>(this IEnumerable<T> element)
		{
			return element
				.Select((v, i) => new { Value = v, Index = i })
				.First(e => e.Value.Equals(element.Select(s => s).Max())).Index;
		}

		/// <summary>
		/// 最大値の要素が格納されている番号を取得する
		/// </summary>
		public static int FindIndexMin<T>(this IEnumerable<T> element)
		{
			return element
				.Select((v, i) => new { Value = v, Index = i })
				.First(e => e.Value.Equals(element.Select(s => s).Min())).Index;
		}
	}

	public static class ArrayExtensions
	{
		/// <summary>
		/// 配列のfor文を簡潔に記述するための拡張メソッド
		/// </summary>
		public static void ForEach<T>(this T[] array, Action<T> action)
		{
			foreach(T t in array)
			{
				action?.Invoke(t);
			}
		}

		/// <summary>
		/// 条件が一致した要素の順番を取得する
		/// </summary>
		public static int Index<T>(this T[] array, Func<T, bool> action)
		{
			int index = 0;
			foreach (T t in array)
			{
				if(action?.Invoke(t) == true)
				{
					return index;
				}
				index++;
			}
			return index;
		}

		/// <summary>
		/// インスタンスがNullか、要素数が空の場合trueを返却
		/// </summary>
		public static bool IsNullOrEmpty<T>(this T[] array)
		{
			if (array == null)
				return true;

			if (array.Length == 0)
				return true;

			return false;
		}
	}

	public static class UtilityExtensions
	{
		public static bool IsEmpty<T>(this T element) where T : class
		{
			if(element == null)
			{
#if DEBUG
				UnityEngine.Debug.LogWarning(nameof(T) + "がNullです");
#endif
				return true;
			}
			return false;
		}
	}
}
