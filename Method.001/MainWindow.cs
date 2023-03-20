using System.Windows;

namespace Occhitta.Example.Message;

/// <summary>
/// 主要画面制御クラスです。
/// </summary>
public partial class MainWindow : Window {
	#region ログ出力処理定義
	/// <summary>
	/// ログ出力処理
	/// </summary>
	private static NLog.ILogger? logger;
	/// <summary>
	/// ログ出力処理を取得します。
	/// </summary>
	/// <returns>ログ出力設定</returns>
	private static NLog.ILogger Logger => logger ??= NLog.LogManager.GetCurrentClassLogger();
	#endregion ログ出力処理定義

	/// <summary>
	/// 主要画面制御を生成します。
	/// </summary>
	public MainWindow() {
		InitializeComponent();

		var source = new System.Windows.Interop.WindowInteropHelper(this);
		Logger.Debug($"[情報]ウィンドウハンドル１:0x{source.Handle:X08}({source.Handle})");
		Logger.Debug($"[情報]ウィンドウハンドル２:0x{source.EnsureHandle():X08}({source.EnsureHandle()})");
	}
}
