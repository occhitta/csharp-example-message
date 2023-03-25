using System;
using System.Runtime.InteropServices;

namespace Occhitta.Example.Message.Native;

/// <summary>
/// OS依存補助関数クラスです。
/// </summary>
internal static class NativeHelper {
	#region メンバー定数定義
	/// <summary>
	/// キーボードフック
	/// </summary>
	private const int WH_KEYBOARD = 2;
	#endregion メンバー定数定義

	#region 外部メソッド定義
	/// <summary>
	/// 画面番地を検索します。
	/// <para>取得に失敗した場合、<c>IntPtr.Zero</c>を返却します。</para>
	/// </summary>
	/// <param name="moduleName">検索名称</param>
	/// <param name="windowName">検索表題</param>
	/// <returns>画面番地</returns>
	[DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
	private static extern IntPtr FindWindow(string? moduleName, string? windowName);
	/// <summary>
	/// 実行処理を設定します。
	/// </summary>
	/// <param name="selectCode">実行種別</param>
	/// <param name="actionHook">実行処理</param>
	/// <param name="moduleCode">呼元番号</param>
	/// <param name="threadCode">呼先番号</param>
	/// <returns>管理番地</returns>
	[DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
	private static extern IntPtr SetWindowsHookEx(int selectCode, KeyboardHook actionHook, IntPtr moduleCode, int threadCode);
	/// <summary>
	/// 実行処理を解除します。
	/// </summary>
	/// <param name="manageCode">管理番地</param>
	/// <returns>解除に成功した場合、<c>True</c>を返却</returns>
	[DllImport("user32.dll", SetLastError=true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool UnhookWindowsHookEx(IntPtr manageCode);
	/// <summary>
	/// 後続処理を実行します。
	/// </summary>
	/// <param name="manageCode">管理番地</param>
	/// <param name="actionCode">実行種別</param>
	/// <param name="parameter1">上位引数</param>
	/// <param name="parameter2">下位引数</param>
	/// <returns>実行結果</returns>
	[DllImport("user32.dll", SetLastError=true, CallingConvention=CallingConvention.StdCall)]
	private static extern IntPtr CallNextHookEx(IntPtr manageCode, int actionCode, IntPtr parameter1, IntPtr parameter2);
	/// <summary>
	/// 実行番号を取得します。
	/// </summary>
	/// <param name="windowCode">画面番地</param>
	/// <param name="systemCode">管理番号</param>
	/// <returns>実行番号</returns>
	[DllImport("user32.dll", SetLastError=true)]
	private static extern int GetWindowThreadProcessId(IntPtr windowCode, out int systemCode);
	/// <summary>
	/// 関数番号を取得します。
	/// </summary>
	/// <param name="moduleName">関数名称</param>
	/// <returns>関数番号</returns>
	[DllImport("kernel32.dll", SetLastError=true, CharSet=CharSet.Auto)]
	private static extern IntPtr GetModuleHandle(string moduleName);
	#endregion 外部メソッド定義

	/// <summary>
	/// 画面番地を検索します。
	/// </summary>
	/// <param name="moduleName">モジュール名称</param>
	/// <param name="windowName">ウィンドウ名称</param>
	/// <param name="resultCode">ウィンドウ番地</param>
	/// <returns>検索に成功した場合、<c>True</c>を返却</returns>
	public static bool SearchWindowCode(string? moduleName, string? windowName, out IntPtr resultCode) {
		resultCode = FindWindow(moduleName, windowName);
		return resultCode != IntPtr.Zero;
	}
	/// <summary>
	/// 実行番号を検索します。
	/// </summary>
	/// <param name="windowCode">画面番地</param>
	/// <param name="threadCode">実行番号</param>
	/// <returns>検索に成功した場合、<c>True</c>を返却</returns>
	public static bool SearchThreadCode(IntPtr windowCode, out int threadCode) {
		threadCode = GetWindowThreadProcessId(windowCode, out var systemCode);
		return threadCode != 0;
	}
	/// <summary>
	/// 実行番号へ介入します。
	/// </summary>
	/// <param name="threadCode">実行番号</param>
	/// <param name="actionHook">実行処理</param>
	/// <param name="nativeCode">管理番地</param>
	/// <returns>介入に成功した場合、<c>True<c>を返却</returns>
	public static bool AttachThreadCode(int threadCode, KeyboardHook actionHook, out IntPtr nativeCode) {
		var moduleData = Marshal.GetHINSTANCE(typeof(MainWindow).Module);
		nativeCode = SetWindowsHookEx(WH_KEYBOARD, actionHook, moduleData, threadCode);
		return nativeCode != IntPtr.Zero;
	}
	/// <summary>
	/// 実行番号を解除します。
	/// </summary>
	/// <param name="nativeCode">管理番号</param>
	/// <returns>解除に成功した場合、<c>True</c>を返却</returns>
	public static bool DetachThreadCode(IntPtr nativeCode) {
		return UnhookWindowsHookEx(nativeCode);
	}
	/// <summary>
	/// 管理番地を実行します。
	/// </summary>
	/// <param name="manageCode">管理番地</param>
	/// <param name="actionCode">実行種別</param>
	/// <param name="parameter1">上位引数</param>
	/// <param name="parameter2">下位引数</param>
	/// <returns>実行結果</returns>
	public static IntPtr InvokeThreadCode(IntPtr nativeCode, int actionCode, IntPtr parameter1, IntPtr parameter2) =>
		CallNextHookEx(nativeCode, actionCode, parameter1, parameter2);
}
