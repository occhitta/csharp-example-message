using System;

namespace Occhitta.Example.Message.Native;

/// <summary>
/// キーボードフックを行います。
/// </summary>
/// <param name="actionCode">情報種別</param>
/// <param name="parameter1">上位引数</param>
/// <param name="parameter2">下位引数</param>
/// <returns>実行結果</returns>
internal delegate IntPtr KeyboardHook(int actionCode, IntPtr parameter1, IntPtr parameter2);
