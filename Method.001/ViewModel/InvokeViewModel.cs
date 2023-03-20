using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Interop;
using Otchitta.Libraries.Screen.Data;
using Otchitta.Libraries.Screen.Hook;

namespace Occhitta.Example.Message.ViewModel;

/// <summary>
/// 実行画面情報クラスです。
/// </summary>
internal sealed class InvokeViewModel : AbstractScreenData {
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

	#region メンバー変数定義
	/// <summary>
	/// 形式情報
	/// </summary>
	private static InvokeViewModel? formatData;
	/// <summary>
	/// 実行情報
	/// </summary>
	private readonly Process? sourceData;
	/// <summary>
	/// 実行可否
	/// </summary>
	private bool sourceFlag;
	/// <summary>
	/// 実行番号
	/// </summary>
	private int? threadCode;
	/// <summary>
	/// 実行名称
	/// </summary>
	private string? threadName;
	/// <summary>
	/// 領域番地
	/// </summary>
	private IntPtr? windowCode;
	/// <summary>
	/// 表題名称
	/// </summary>
	private string? windowName;
	/// <summary>
	/// 詳細一覧
	/// </summary>
	private ObservableCollection<DetailViewModel> detailList;
	/// <summary>
	/// 開始可否
	/// </summary>
	private bool invokeFlag;
	/// <summary>
	/// 開始操作
	/// </summary>
	private DelegateScreenHook? invokeMenu;
	/// <summary>
	/// 終了可否
	/// </summary>
	private bool finishFlag;
	/// <summary>
	/// 終了操作
	/// </summary>
	private DelegateScreenHook? finishMenu;
	/// <summary>
	/// 結果内容
	/// </summary>
	private string? resultText;
	#endregion メンバー変数定義

	#region プロパティー定義
	/// <summary>
	/// 形式情報を取得します。
	/// </summary>
	/// <value>形式情報</value>
	public static InvokeViewModel FormatData => formatData ??= new InvokeViewModel(null);
	/// <summary>
	/// 実行番号を取得します。
	/// </summary>
	/// <value>実行番号</value>
	public int? ThreadCode {
		get => this.threadCode;
		private set => Update(ref this.threadCode, value, nameof(ThreadCode));
	}
	/// <summary>
	/// 実行名称を取得します。
	/// </summary>
	/// <value>実行名称</value>
	public string? ThreadName {
		get => this.threadName;
		private set => Update(ref this.threadName, value, nameof(ThreadName));
	}
	/// <summary>
	/// 領域番地を取得します。
	/// </summary>
	/// <value>領域番地</value>
	public IntPtr? WindowCode {
		get => this.windowCode;
		private set => Update(ref this.windowCode, value, nameof(WindowCode));
	}
	/// <summary>
	/// 表題名称を取得します。
	/// </summary>
	/// <value>表題名称</value>
	public string? WindowName {
		get => this.windowName;
		private set => Update(ref this.windowName, value, nameof(WindowName));
	}
	/// <summary>
	/// 詳細一覧を取得します。
	/// </summary>
	/// <value>詳細一覧</value>
	public ReadOnlyObservableCollection<DetailViewModel> DetailList {
		get;
	}
	/// <summary>
	/// 開始可否を取得します。
	/// </summary>
	/// <value>開始可否</value>
	public bool InvokeFlag {
		get => this.invokeFlag;
		private set => Update(ref this.invokeFlag, value, nameof(InvokeFlag), () => this.invokeMenu?.Notify());
	}
	/// <summary>
	/// 開始操作を取得します。
	/// </summary>
	/// <value>開始操作</value>
	public AbstractScreenHook InvokeMenu {
		get => this.invokeMenu ??= new DelegateScreenHook(ActionInvokeMenu, () => this.invokeFlag);
	}
	/// <summary>
	/// 終了可否を取得します。
	/// </summary>
	/// <value>終了可否</value>
	public bool FinishFlag {
		get => this.finishFlag;
		private set => Update(ref this.finishFlag, value, nameof(FinishFlag), () => this.finishMenu?.Notify());
	}
	/// <summary>
	/// 終了操作を取得します。
	/// </summary>
	/// <value>終了操作</value>
	public AbstractScreenHook FinishMenu {
		get => this.finishMenu ??= new DelegateScreenHook(ActionFinishMenu, () => this.finishFlag);
	}
	/// <summary>
	/// 結果内容を取得します。
	/// </summary>
	/// <value>結果内容</value>
	public string? ResultText {
		get => this.resultText;
		private set => Update(ref this.resultText, value, nameof(ResultText));
	}
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 実行画面情報を生成します。
	/// </summary>
	/// <param name="sourceData">実行情報</param>
	private InvokeViewModel(Process? sourceData) {
		this.sourceData = sourceData;
		this.sourceFlag = sourceData != null;
		this.threadCode = sourceData?.Id;
		this.threadName = sourceData?.ProcessName;
		this.windowCode = sourceData?.MainWindowHandle;
		this.windowName = sourceData?.MainWindowTitle;
		this.detailList = new ObservableCollection<DetailViewModel>();
		this.invokeFlag = sourceData != null;
		this.invokeMenu = null;
		this.finishFlag = false;
		this.finishMenu = null;
		this.resultText = null;
		DetailList = new ReadOnlyObservableCollection<DetailViewModel>(this.detailList);
		if (sourceData == null) {
			this.sourceFlag = false;
			this.invokeFlag = false;
			this.finishFlag = false;
		} else if (AttachSourceData(sourceData) == false) {
			this.sourceFlag = false;
			this.invokeFlag = false;
			this.finishFlag = false;
		} else {
			this.sourceFlag = true;
			this.invokeFlag = true;
			this.finishFlag = false;
			sourceData.Exited += (s, e) => this.sourceFlag = false;
			TaskWorker.InvokeData(InvokeMemberData);
		}
	}
	/// <summary>
	/// 実行画面一覧を生成します。
	/// </summary>
	/// <returns>実行画面一覧</returns>
	public static IEnumerable<InvokeViewModel> CreateList() {
		foreach (var choose in Process.GetProcesses()) {
			if (choose.MainWindowHandle == IntPtr.Zero) {
				// 処理なし
			} else {
				yield return new InvokeViewModel(choose);
			}
		}
	}
	#endregion 生成メソッド定義

	#region 内部メソッド定義(生成処理関連:AttachSourceData/CreateHandleData)
	/// <summary>
	/// 終了処理を設定します。
	/// </summary>
	/// <param name="sourceData">実行情報</param>
	/// <returns>設定に成功した場合、<c>True</c>を返却</returns>
	private static bool AttachSourceData(Process sourceData) {
		try {
			sourceData.EnableRaisingEvents = true;
			return true;
		} catch (System.ComponentModel.Win32Exception error) {
			switch (error.NativeErrorCode) {
			default:
				Logger.Error(error, "[失敗]終了イベントの有効化に失敗しました。\r\nプロセス:{0}\r\nタイトル:{1}\r\n例外番号:{2}", sourceData.ProcessName, sourceData.MainWindowTitle, error.NativeErrorCode);
				return false;
			case 0x0005: // アクセスが拒否されました。
				Logger.Trace("[情報]権限なし(プロセス:{0}, タイトル:{1})", sourceData.ProcessName, sourceData.MainWindowTitle);
				return false;
			}
		}
	}
	/// <summary>
	/// 領域管理を生成します。
	/// </summary>
	/// <param name="windowCode">領域番地</param>
	/// <param name="resultData">領域管理</param>
	/// <returns>生成に成功した場合、<c>True</c>を返却</returns>
	private static bool CreateHandleData(IntPtr windowCode, [MaybeNullWhen(false)]out HwndSource resultData) =>
		(resultData = HwndSource.FromHwnd(windowCode)) != null;
	#endregion 内部メソッド定義(生成処理関連:AttachSourceData/CreateHandleData)

	#region 内部メソッド定義(監視操作関連:UpdateMemberData/AcceptMemberData/InvokeMemberData/FinishMemberData)
	/// <summary>
	/// 内部情報を更新します。
	/// </summary>
	/// <param name="threadCode">実行番号</param>
	/// <param name="threadName">実行名称</param>
	/// <param name="windowCode">領域番地</param>
	/// <param name="windowName">表題名称</param>
	private void UpdateMemberData(int threadCode, string threadName, IntPtr windowCode, string windowName) {
		if (this.sourceData == null) {
			// 情報なし：処理なし
		} else if (this.sourceFlag == false) {
			// 監視不可：処理なし
		} else {
			ThreadCode = threadCode;
			ThreadName = threadName;
			WindowCode = windowCode;
			WindowName = windowName;
		}
	}
	/// <summary>
	/// 監視可能か判定します。
	/// </summary>
	/// <param name="sourceData">実行情報</param>
	/// <param name="sourceFlag">実行可否</param>
	/// <param name="threadTime">待機時間</param>
	/// <returns>監視可能である場合、<c>True</c>を返却</returns>
	private static bool AcceptMemberData(Process? sourceData, bool sourceFlag, int threadTime) {
		if (sourceData == null) {
			return false;
		} else if (sourceFlag == false) {
			return false;
		} else if (threadTime <= 0) {
			return true;
		} else {
			System.Threading.Thread.Sleep(threadTime);
			return true;
		}
	}
	/// <summary>
	/// 監視可能か判定します。
	/// </summary>
	/// <param name="sourceData">実行情報</param>
	/// <param name="sourceFlag">実行可否</param>
	/// <param name="resultData">実行情報</param>
	/// <returns>監視可能である場合、<c>True</c>を返却</returns>
	private static bool AcceptMemberData(Process? sourceData, bool sourceFlag, [MaybeNullWhen(false)]out Process resultData) {
		if (sourceData == null) {
			resultData = default;
			return false;
		} else if (sourceFlag == false) {
			resultData = default;
			return false;
		} else {
			sourceData.Refresh();
			resultData = sourceData;
			return sourceData.HasExited == false;
		}
	}
	/// <summary>
	/// 監視処理を実行します。
	/// </summary>
	private void InvokeMemberData() {
		try {
			for (var counter = 0; ; counter ++) {
				if (AcceptMemberData(this.sourceData, this.sourceFlag, counter == 0? 0: 100) == false) { // １００ミリ秒待機
					this.sourceFlag = false;
					TaskWorker.InvokeView(FinishMemberData, "プロセスが終了しました");
					return;
				} else if (AcceptMemberData(this.sourceData, this.sourceFlag, out var sourceData) == false) {
					this.sourceFlag = false;
					TaskWorker.InvokeView(FinishMemberData, "プロセスが終了しました");
					return;
				} else {
					var threadCode = sourceData.Id;
					var threadName = sourceData.ProcessName;
					var windowCode = sourceData.MainWindowHandle;
					var windowName = sourceData.MainWindowTitle;
					TaskWorker.InvokeView(UpdateMemberData, threadCode, threadName, windowCode, windowName);
				}
			}
		} catch {
			this.sourceFlag = false;
			TaskWorker.InvokeView(FinishMemberData, "監視中に例外が発生しました");
		}
	}
	/// <summary>
	/// 監視処理を終了します。
	/// </summary>
	/// <param name="resultText">結果内容</param>
	private void FinishMemberData(string resultText) =>
		ResultText = resultText;
	#endregion 内部メソッド定義(監視操作関連:UpdateMemberData/AcceptMemberData/InvokeMemberData/FinishMemberData)

	#region 内部メソッド定義(詳細情報関連:RegistDetailData)
	/// <summary>
	/// 詳細情報を登録します。
	/// </summary>
	/// <param name="handleCode">画面番地</param>
	/// <param name="invokeCode">実行種別</param>
	/// <param name="parameter1">基本情報</param>
	/// <param name="parameter2">引数情報</param>
	private void RegistDetailData(IntPtr handleCode, int invokeCode, IntPtr parameter1, IntPtr parameter2) =>
		this.detailList.Add(new DetailViewModel(handleCode, invokeCode, parameter1, parameter2));
	#endregion 内部メソッド定義(詳細情報関連:RegistDetailData)

	#region 内部メソッド定義(開始操作関連:InvokeInvokeMenu/ActionInvokeMenu/FinishInvokeMenu)
	/// <summary>
	/// 開始操作を実行します。
	/// </summary>
	/// <param name="handleCode">画面番地</param>
	/// <param name="invokeCode">実行種別</param>
	/// <param name="parameter1">基本情報</param>
	/// <param name="parameter2">引数情報</param>
	/// <param name="invokeFlag">実行状態</param>
	/// <returns>実行番地</returns>
	private IntPtr InvokeInvokeMenu(IntPtr handleCode, int invokeCode, IntPtr parameter1, IntPtr parameter2, ref bool invokeFlag) {
		TaskWorker.InvokeView(RegistDetailData, handleCode, invokeCode, parameter1, parameter2);
		return IntPtr.Zero;
	}
	/// <summary>
	/// 開始操作を実行します。
	/// </summary>
	private void InvokeInvokeMenu() {
		try {
			var sourceData = this.sourceData;
			if (sourceData == null) {
				TaskWorker.InvokeView(FinishInvokeMenu, "実行情報がありません");
			} else if (CreateHandleData(sourceData.MainWindowHandle, out var handleData) == false) {
				TaskWorker.InvokeView(FinishInvokeMenu, "監視処理を行えません");
			} else {
				handleData.AddHook(InvokeInvokeMenu);
				TaskWorker.InvokeView(() => FinishFlag = true);
				while (true) {
					if (this.finishFlag) {
						break;
					} else {
						System.Threading.Thread.Sleep(10);
					}
				}
				while (true) {
					if (this.finishFlag == false) {
						// 終了操作を実行
						break;
					} else if (this.sourceFlag == false) {
						// 実行処理が終了
						break;
					} else {
						// 監視操作が継続
						System.Threading.Thread.Sleep(100);
					}
				}
				handleData.RemoveHook(InvokeInvokeMenu);
				TaskWorker.InvokeView(FinishInvokeMenu, "監視処理を終了しました");
			}
		} catch (Exception error) {
			Logger.Error(error, "監視処理に失敗しました。");
			TaskWorker.InvokeView(FinishInvokeMenu, "監視処理に失敗しました");
		}
	}
	/// <summary>
	/// 開始操作を開始します。
	/// </summary>
	private void ActionInvokeMenu() {
		InvokeFlag = false;
		TaskWorker.InvokeData(InvokeInvokeMenu);
	}
	/// <summary>
	/// 開始操作を終了します。
	/// </summary>
	/// <param name="resultText">結果内容</param>
	private void FinishInvokeMenu(string resultText) {
		InvokeFlag = true;
		FinishFlag = false;
		ResultText = resultText;
	}
	#endregion 内部メソッド定義(開始操作関連:InvokeInvokeMenu/ActionInvokeMenu/FinishInvokeMenu)

	#region 内部メソッド定義(終了操作関連:ActionFinishMenu)
	/// <summary>
	/// 終了操作を開始します。
	/// </summary>
	private void ActionFinishMenu() {
		FinishFlag = false;
	}
	#endregion 内部メソッド定義(終了操作関連:ActionFinishMenu)
}
