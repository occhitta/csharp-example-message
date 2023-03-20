using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

[assembly:ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]

namespace Occhitta.Example.Message;

/// <summary>
/// 主要画面実行クラスです。
/// </summary>
internal static class MainModule {
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

	#region 内部メソッド定義(ToMessage/InvokeUnhandledException)
	/// <summary>
	/// 表示文言を生成します。
	/// </summary>
	/// <param name="source">例外情報</param>
	/// <returns>表示文言</returns>
	private static string ToMessage(Exception? source) {
		if (source == null) {
			return $"予期せぬエラーが発生しました。{Environment.NewLine}"
			     + $"開発者に報告してください。";
		} else {
			return $"予期せぬエラーが発生しました。{Environment.NewLine}"
			     + $"開発者に報告してください。{Environment.NewLine}"
			     + $"{source.Message}{Environment.NewLine}"
			     + $"{source.TargetSite?.Name}";
		}
	}
	/// <summary>
	/// 中枢例外を処理します。
	/// </summary>
	/// <param name="sender">実行情報</param>
	/// <param name="values">引数情報</param>
	private static void InvokeUnhandledException(object sender, UnhandledExceptionEventArgs values) {
		var reason = values.ExceptionObject as Exception;
		var output = ToMessage(reason);
		Logger.Fatal(reason, "未処理例外が発生しました");
		MessageBox.Show(output, "未処理例外", MessageBoxButton.OK, MessageBoxImage.Stop);
		Environment.Exit(1);
	}
	/// <summary>
	/// 内部例外を処理します。
	/// </summary>
	/// <param name="sender">実行情報</param>
	/// <param name="values">引数情報</param>
	private static void InvokeUnhandledException(object? sender, UnobservedTaskExceptionEventArgs values) {
		var reason = values.Exception.InnerException;
		var output = $"{ToMessage(reason)}{Environment.NewLine}プログラムの実行を継続しますか？";
		Logger.Fatal(reason, "内部スレッドにて未処理例外が発生しました");
		if (MessageBox.Show(output, "未処理例外(内部スレッド)", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes) {
			values.SetObserved();
		} else {
			Environment.Exit(1);
		}
	}
	/// <summary>
	/// 画面例外を処理します。
	/// </summary>
	/// <param name="sender">実行情報</param>
	/// <param name="values">引数情報</param>
	private static void InvokeUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs values) {
		var reason = values.Exception;
		var output = $"{ToMessage(reason)}{Environment.NewLine}プログラムの実行を継続しますか？";
		Logger.Fatal(reason, "画面スレッドにて未処理例外が発生しました");
		if (MessageBox.Show(output, "未処理例外(画面スレッド)", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes) {
			values.Handled = true;
		} else {
			Environment.Exit(1);
		}
	}
	#endregion 内部メソッド定義(ToMessage/InvokeUnhandledException)

	private static void RegistResource(Application source, string regist) =>
		source.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(regist, UriKind.Relative) });

	#region 実行メソッド定義
	/// <summary>
	/// 主要処理を開始します。
	/// </summary>
	/// <param name="commands">コマンドライン引数</param>
	[STAThread]
	public static void Main(string[] commands) {
		// 初期設定
		AppDomain.CurrentDomain.UnhandledException += InvokeUnhandledException;
		TaskScheduler.UnobservedTaskException += InvokeUnhandledException;

		// 生成処理
		var source = new Application();

		// 設定処理
		source.DispatcherUnhandledException += InvokeUnhandledException;
		RegistResource(source, "/ViewModel/WindowViewModel.xaml");
		RegistResource(source, "/ViewModel/InvokeViewModel.xaml");
		source.StartupUri = new Uri("/MainWindow.xaml", UriKind.Relative);

		// 実行処理
		source.Run();
	}
	#endregion 実行メソッド定義
}
