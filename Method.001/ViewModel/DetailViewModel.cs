using System;

namespace Occhitta.Example.Message.ViewModel;

/// <summary>
/// 詳細画面情報クラスです。
/// </summary>
internal sealed class DetailViewModel {
	#region プロパティー定義
	/// <summary>
	/// 画面番地を取得します。
	/// </summary>
	/// <value>画面番地</value>
	public IntPtr HandleCode {
		get;
	}
	/// <summary>
	/// 実行種別を取得します。
	/// </summary>
	/// <value>実行種別</value>
	public int InvokeCode {
		get;
	}
	/// <summary>
	/// 実行名称を取得します。
	/// </summary>
	/// <value>実行名称</value>
	public string InvokeName {
		get;
	}
	/// <summary>
	/// 基本情報を取得します。
	/// </summary>
	/// <value>基本情報</value>
	public IntPtr Parameter1 {
		get;
	}
	/// <summary>
	/// 拡張情報を取得します。
	/// </summary>
	/// <value>拡張情報</value>
	public IntPtr Parameter2 {
		get;
	}
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 詳細画面情報を生成します。
	/// </summary>
	/// <param name="handleCode">画面番地</param>
	/// <param name="invokeCode">実行種別</param>
	/// <param name="parameter1">基本情報</param>
	/// <param name="parameter2">引数情報</param>
	public DetailViewModel(IntPtr handleCode, int invokeCode, IntPtr parameter1, IntPtr parameter2) {
		HandleCode = handleCode;
		InvokeCode = invokeCode;
		InvokeName = ToInvokeName(invokeCode);
		Parameter1 = parameter1;
		Parameter2 = parameter2;
	}
	#endregion 生成メソッド定義

	#region 内部メソッド定義
	/// <summary>
	/// 実行名称へ変換します。
	/// </summary>
	/// <param name="invokeCode">実行種別</param>
	/// <returns>実行名称</returns>
	private static string ToInvokeName(int invokeCode) {
		switch (invokeCode) {
			default:     return $"UNKNOWN({invokeCode:X08})";
		}
	}
	#endregion 内部メソッド定義
}
