namespace Occhitta.Example.Message.Native;

internal enum KeyboardCode : long {
	// ===================================================================
	// 0x00～0x0Fの定義
	// ===================================================================
	/* 0x01 */ VK_LBUTTON             = 0x01, // マウスの左ボタン
	/* 0x02 */ VK_RBUTTON             = 0x02, // マウスの右ボタン
	/* 0x03 */ VK_CANCEL              = 0x03, // 制御中断処理
	/* 0x04 */ VK_MBUTTON             = 0x04, // マウスの中央ボタン (3 ボタン マウス)
	/* 0x05 */ VK_XBUTTON1            = 0x05, // X1 マウス ボタン
	/* 0x06 */ VK_XBUTTON2            = 0x06, // X2 マウス ボタン
	/* 0x07 */ // 未定義
	/* 0x08 */ VK_BACK                = 0x08, // BACKSPACE キー
	/* 0x09 */ VK_TAB                 = 0x09, // Tab キー
	/* 0x0A */ // 予約
	/* 0x0B */ // 予約
	/* 0x0C */ VK_CLEAR               = 0x0C, // CLEAR キー
	/* 0x0D */ VK_RETURN              = 0x0D, // Enter キー
	/* 0x0E */ // 未定義
	/* 0x0F */ // 未定義

	// ===================================================================
	// 0x10～0x1Fの定義
	// ===================================================================
	/* 0x10 */ VK_SHIFT               = 0x10, // Shift キー
	/* 0x11 */ VK_CONTROL             = 0x11, // Ctrl キー
	/* 0x12 */ VK_MENU                = 0x12, // ALT キー
	/* 0x13 */ VK_PAUSE               = 0x13, // PAUSE キー
	/* 0x14 */ VK_CAPITAL             = 0x14, // CAPS LOCK キー
	/* 0x15 */ VK_KANA                = 0x15, // IME かなモード
	/* 0x15 */ VK_HANGUL              = 0x15, // IME ハングル モード
	/* 0x16 */ VK_IME_ON              = 0x16, // IME On
	/* 0x17 */ VK_JUNJA               = 0x17, // IME Junja モード
	/* 0x18 */ VK_FINAL               = 0x18, // IME Final モード
	/* 0x19 */ VK_HANJA               = 0x19, // IME Hanja モード
	/* 0x19 */ VK_KANJI               = 0x19, // IME 漢字モード
	/* 0x1A */ VK_IME_OFF             = 0x1A, // IME オフ
	/* 0x1B */ VK_ESCAPE              = 0x1B, // ESC キー
	/* 0x1C */ VK_CONVERT             = 0x1C, // IME 変換
	/* 0x1D */ VK_NONCONVERT          = 0x1D, // IME 無変換
	/* 0x1E */ VK_ACCEPT              = 0x1E, // IME 使用可能
	/* 0x1F */ VK_MODECHANGE          = 0x1F, // IME モード変更要求

	// ===================================================================
	// 0x20～0x2Fの定義
	// ===================================================================
	/* 0x20 */ VK_SPACE               = 0x20, // Space キー
	/* 0x21 */ VK_PRIOR               = 0x21, // PAGE UP キー
	/* 0x22 */ VK_NEXT                = 0x22, // PAGE DOWN キー
	/* 0x23 */ VK_END                 = 0x23, // END キー
	/* 0x24 */ VK_HOME                = 0x24, // HOME キー
	/* 0x25 */ VK_LEFT                = 0x25, // 左方向キー
	/* 0x26 */ VK_UP                  = 0x26, // 上方向キー
	/* 0x27 */ VK_RIGHT               = 0x27, // 右方向キー
	/* 0x28 */ VK_DOWN                = 0x28, // 下方向キー
	/* 0x29 */ VK_SELECT              = 0x29, // SELECT キー
	/* 0x2A */ VK_PRINT               = 0x2A, // PRINT キー
	/* 0x2B */ VK_EXECUTE             = 0x2B, // EXECUTE キー
	/* 0x2C */ VK_SNAPSHOT            = 0x2C, // 画面の印刷キー
	/* 0x2D */ VK_INSERT              = 0x2D, // INS キー
	/* 0x2E */ VK_DELETE              = 0x2E, // DEL キー
	/* 0x2F */ VK_HELP                = 0x2F, // HELP キー

	// ===================================================================
	// 0x30～0x3Fの定義
	// ===================================================================
	/* 0x30 */ VK_0                   = 0x30, // 0 キー
	/* 0x31 */ VK_1                   = 0x31, // 1 キー
	/* 0x32 */ VK_2                   = 0x32, // 2 キー
	/* 0x33 */ VK_3                   = 0x33, // 3 キー
	/* 0x34 */ VK_4                   = 0x34, // 4 キー
	/* 0x35 */ VK_5                   = 0x35, // 5 キー
	/* 0x36 */ VK_6                   = 0x36, // 6 キー
	/* 0x37 */ VK_7                   = 0x37, // 7 キー
	/* 0x38 */ VK_8                   = 0x38, // 8 キー
	/* 0x39 */ VK_9                   = 0x39, // 9 キー
	/* 0x3A */ // 未定義
	/* 0x3B */ // 未定義
	/* 0x3C */ // 未定義
	/* 0x3D */ // 未定義
	/* 0x3E */ // 未定義
	/* 0x3F */ // 未定義

	// ===================================================================
	// 0x40～0x4Fの定義
	// ===================================================================
	/* 0x40 */ // 未定義
	/* 0x41 */ VK_A                   = 0x41, // A キー
	/* 0x42 */ VK_B                   = 0x42, // B キー
	/* 0x43 */ VK_C                   = 0x43, // C キー
	/* 0x44 */ VK_D                   = 0x44, // D キー
	/* 0x45 */ VK_E                   = 0x45, // E キー
	/* 0x46 */ VK_F                   = 0x46, // F キー
	/* 0x47 */ VK_G                   = 0x47, // G キー
	/* 0x48 */ VK_H                   = 0x48, // H キー
	/* 0x49 */ VK_I                   = 0x49, // I キー
	/* 0x4A */ VK_J                   = 0x4A, // J キー
	/* 0x4B */ VK_K                   = 0x4B, // K キー
	/* 0x4C */ VK_L                   = 0x4C, // L キー
	/* 0x4D */ VK_M                   = 0x4D, // M キー
	/* 0x4E */ VK_N                   = 0x4E, // N キー
	/* 0x4F */ VK_O                   = 0x4F, // O キー

	// ===================================================================
	// 0x50～0x5Fの定義
	// ===================================================================
	/* 0x50 */ VK_P                   = 0x50, // P キー
	/* 0x51 */ VK_Q                   = 0x51, // Q キー
	/* 0x52 */ VK_R                   = 0x52, // R キー
	/* 0x53 */ VK_S                   = 0x53, // S キー
	/* 0x54 */ VK_T                   = 0x54, // T キー
	/* 0x55 */ VK_U                   = 0x55, // U キー
	/* 0x56 */ VK_V                   = 0x56, // V キー
	/* 0x57 */ VK_W                   = 0x57, // W キー
	/* 0x58 */ VK_X                   = 0x58, // X キー
	/* 0x59 */ VK_Y                   = 0x59, // Y キー
	/* 0x5A */ VK_Z                   = 0x5A, // Z キー
	/* 0x5B */ VK_LWIN                = 0x5B, // 左Windowsキー (ナチュラル キーボード)
	/* 0x5C */ VK_RWIN                = 0x5C, // 右Windowsキー (ナチュラル キーボード)
	/* 0x5D */ VK_APPS                = 0x5D, // アプリケーション キー (ナチュラル キーボード)
	/* 0x5E */ // 予約
	/* 0x5F */ VK_SLEEP               = 0x5F, // コンピューターのスリープ キー

	// ===================================================================
	// 0x60～0x6Fの定義
	// ===================================================================
	/* 0x60 */ VK_NUMPAD0             = 0x60, // テンキー 0 キー
	/* 0x61 */ VK_NUMPAD1             = 0x61, // テンキー 1 キー
	/* 0x62 */ VK_NUMPAD2             = 0x62, // テンキー 2 キー
	/* 0x63 */ VK_NUMPAD3             = 0x63, // テンキー 3 キー
	/* 0x64 */ VK_NUMPAD4             = 0x64, // テンキー 4 キー
	/* 0x65 */ VK_NUMPAD5             = 0x65, // テンキー 5 キー
	/* 0x66 */ VK_NUMPAD6             = 0x66, // テンキー 6 キー
	/* 0x67 */ VK_NUMPAD7             = 0x67, // テンキー 7 キー
	/* 0x68 */ VK_NUMPAD8             = 0x68, // テンキー 8 キー
	/* 0x69 */ VK_NUMPAD9             = 0x69, // テンキー 9 キー
	/* 0x6A */ VK_MULTIPLY            = 0x6A, // 乗算キー
	/* 0x6B */ VK_ADD                 = 0x6B, // キーの追加
	/* 0x6C */ VK_SEPARATOR           = 0x6C, // 区切り記号キー
	/* 0x6D */ VK_SUBTRACT            = 0x6D, // 減算キー
	/* 0x6E */ VK_DECIMAL             = 0x6E, // 10 進キー
	/* 0x6F */ VK_DIVIDE              = 0x6F, // キーの分割

	// ===================================================================
	// 0x70～0x7Fの定義
	// ===================================================================
	/* 0x70 */ VK_F1                  = 0x70, // F1 キー
	/* 0x71 */ VK_F2                  = 0x71, // F2 キー
	/* 0x72 */ VK_F3                  = 0x72, // F3 キー
	/* 0x73 */ VK_F4                  = 0x73, // F4 キー
	/* 0x74 */ VK_F5                  = 0x74, // F5 キー
	/* 0x75 */ VK_F6                  = 0x75, // F6 キー
	/* 0x76 */ VK_F7                  = 0x76, // F7 キー
	/* 0x77 */ VK_F8                  = 0x77, // F8 キー
	/* 0x78 */ VK_F9                  = 0x78, // F9 キー
	/* 0x79 */ VK_F10                 = 0x79, // F10 キー
	/* 0x7A */ VK_F11                 = 0x7A, // F11 キー
	/* 0x7B */ VK_F12                 = 0x7B, // F12 キー
	/* 0x7C */ VK_F13                 = 0x7C, // F13 キー
	/* 0x7D */ VK_F14                 = 0x7D, // F14 キー
	/* 0x7E */ VK_F15                 = 0x7E, // F15 キー
	/* 0x7F */ VK_F16                 = 0x7F, // F16 キー

	// ===================================================================
	// 0x80～0x8Fの定義
	// ===================================================================
	/* 0x80 */ VK_F17                 = 0x80, // F17 キー
	/* 0x81 */ VK_F18                 = 0x81, // F18 キー
	/* 0x82 */ VK_F19                 = 0x82, // F19 キー
	/* 0x83 */ VK_F20                 = 0x83, // F20 キー
	/* 0x84 */ VK_F21                 = 0x84, // F21 キー
	/* 0x85 */ VK_F22                 = 0x85, // F22 キー
	/* 0x86 */ VK_F23                 = 0x86, // F23 キー
	/* 0x87 */ VK_F24                 = 0x87, // F24 キー
	/* 0x88 */ // 未割り当て
	/* 0x89 */ // 未割り当て
	/* 0x8A */ // 未割り当て
	/* 0x8B */ // 未割り当て
	/* 0x8C */ // 未割り当て
	/* 0x8D */ // 未割り当て
	/* 0x8E */ // 未割り当て
	/* 0x8F */ // 未割り当て

	// ===================================================================
	// 0x90～0x9Fの定義
	// ===================================================================
	/* 0x90 */ VK_NUMLOCK             = 0x90, // NUM LOCK キー
	/* 0x91 */ VK_SCROLL              = 0x91, // SCROLL LOCK キー
	/* 0x92 */ // OEM 固有
	/* 0x93 */ // OEM 固有
	/* 0x94 */ // OEM 固有
	/* 0x95 */ // OEM 固有
	/* 0x96 */ // OEM 固有
	/* 0x97 */ // 未割り当て
	/* 0x98 */ // 未割り当て
	/* 0x99 */ // 未割り当て
	/* 0x9A */ // 未割り当て
	/* 0x9B */ // 未割り当て
	/* 0x9C */ // 未割り当て
	/* 0x9D */ // 未割り当て
	/* 0x9E */ // 未割り当て
	/* 0x9F */ // 未割り当て

	// ===================================================================
	// 0xA0～0xAFの定義
	// ===================================================================
	/* 0xA0 */ VK_LSHIFT              = 0xA0, // 左 Shift キー
	/* 0xA1 */ VK_RSHIFT              = 0xA1, // 右 Shift キー
	/* 0xA2 */ VK_LCONTROL            = 0xA2, // 左 Ctrl キー
	/* 0xA3 */ VK_RCONTROL            = 0xA3, // 右 Ctrl キー
	/* 0xA4 */ VK_LMENU               = 0xA4, // 左 Alt キー
	/* 0xA5 */ VK_RMENU               = 0xA5, // 右 Alt キー
	/* 0xA6 */ VK_BROWSER_BACK        = 0xA6, // ブラウザーの戻るキー
	/* 0xA7 */ VK_BROWSER_FORWARD     = 0xA7, // ブラウザーの進むキー
	/* 0xA8 */ VK_BROWSER_REFRESH     = 0xA8, // ブラウザーの更新キー
	/* 0xA9 */ VK_BROWSER_STOP        = 0xA9, // ブラウザーの停止キー
	/* 0xAA */ VK_BROWSER_SEARCH      = 0xAA, // ブラウザーの検索キー
	/* 0xAB */ VK_BROWSER_FAVORITES   = 0xAB, // ブラウザーのお気に入りキー
	/* 0xAC */ VK_BROWSER_HOME        = 0xAC, // ブラウザーのスタートとホーム キー
	/* 0xAD */ VK_VOLUME_MUTE         = 0xAD, // 音量ミュート キー
	/* 0xAE */ VK_VOLUME_DOWN         = 0xAE, // 音量下げるキー
	/* 0xAF */ VK_VOLUME_UP           = 0xAF, // 音量上げるキー

	// ===================================================================
	// 0xB0～0xBFの定義
	// ===================================================================
	/* 0xB0 */ VK_MEDIA_NEXT_TRACK    = 0xB0, // 次のトラックキー
	/* 0xB1 */ VK_MEDIA_PREV_TRACK    = 0xB1, // 前のトラック
	/* 0xB2 */ VK_MEDIA_STOP          = 0xB2, // メディアの停止キー
	/* 0xB3 */ VK_MEDIA_PLAY_PAUSE    = 0xB3, // メディアの再生/一時停止キー
	/* 0xB4 */ VK_LAUNCH_MAIL         = 0xB4, // メール開始キー
	/* 0xB5 */ VK_LAUNCH_MEDIA_SELECT = 0xB5, // メディアの選択キー
	/* 0xB6 */ VK_LAUNCH_APP1         = 0xB6, // アプリケーション 1 の起動キー
	/* 0xB7 */ VK_LAUNCH_APP2         = 0xB7, // アプリケーション 2 の起動キー
	/* 0xB8 */ // 予約
	/* 0xB9 */ // 予約
	/* 0xBA */ VK_OEM_1               = 0xBA, // その他の文字に使用されます。キーボードによって異なる場合があります。 米国標準キーボードの場合、';:' キー
	/* 0xBB */ VK_OEM_PLUS            = 0xBB, // 任意の国/地域の場合、'+' キー
	/* 0xBC */ VK_OEM_COMMA           = 0xBC, // どの国/地域の場合も、',' キー
	/* 0xBD */ VK_OEM_MINUS           = 0xBD, // どの国/地域の場合も、'-' キー
	/* 0xBE */ VK_OEM_PERIOD          = 0xBE, // 任意の国/地域の場合は、'.' キー
	/* 0xBF */ VK_OEM_2               = 0xBF, // その他の文字に使用されます。キーボードによって異なる場合があります。 米国標準キーボードの場合、'/?' key

	// ===================================================================
	// 0xC0～0xCFの定義
	// ===================================================================
	/* 0xC0 */ VK_OEM_3               = 0xC0, // その他の文字に使用されます。キーボードによって異なる場合があります。 米国標準キーボードの場合、''~' キー
	/* 0xC1 */ // 予約
	/* 0xC2 */ // 予約
	/* 0xC3 */ // 予約
	/* 0xC4 */ // 予約
	/* 0xC5 */ // 予約
	/* 0xC6 */ // 予約
	/* 0xC7 */ // 予約
	/* 0xC8 */ // 予約
	/* 0xC9 */ // 予約
	/* 0xCA */ // 予約
	/* 0xCB */ // 予約
	/* 0xCC */ // 予約
	/* 0xCD */ // 予約
	/* 0xCE */ // 予約
	/* 0xCF */ // 予約

	// ===================================================================
	// 0xD0～0xDFの定義
	// ===================================================================
	/* 0xD0 */ // 予約
	/* 0xD1 */ // 予約
	/* 0xD2 */ // 予約
	/* 0xD3 */ // 予約
	/* 0xD4 */ // 予約
	/* 0xD5 */ // 予約
	/* 0xD6 */ // 予約
	/* 0xD7 */ // 予約
	/* 0xD8 */ // 未割り当て
	/* 0xD9 */ // 未割り当て
	/* 0xDA */ // 未割り当て
	/* 0xDB */ VK_OEM_4               = 0xDB, // その他の文字に使用されます。キーボードによって異なる場合があります。 米国標準キーボードの場合、'[{' キー
	/* 0xDC */ VK_OEM_5               = 0xDC, // その他の文字に使用されます。キーボードによって異なる場合があります。 米国標準キーボードの場合、'\|' キー
	/* 0xDD */ VK_OEM_6               = 0xDD, // その他の文字に使用されます。キーボードによって異なる場合があります。 米国標準キーボードの場合、']}' キー
	/* 0xDE */ VK_OEM_7               = 0xDE, // その他の文字に使用されます。キーボードによって異なる場合があります。 米国標準キーボードの場合、"単一引用符/二重引用符" キー
	/* 0xDF */ VK_OEM_8               = 0xDF, // その他の文字に使用されます。キーボードによって異なる場合があります。

	// ===================================================================
	// 0xE0～0xEFの定義
	// ===================================================================
	/* 0xE0 */ // 予約
	/* 0xE1 */ // OEM 固定
	/* 0xE2 */ VK_OEM_102             = 0xE2, // <>米国標準キーボードのキー、または米国以外の \\| 102 キー キーボードのキー
	/* 0xE3 */ // OEM 固定
	/* 0xE4 */ // OEM 固定
	/* 0xE5 */ VK_PROCESSKEY          = 0xE5, // IME PROCESS キー
	/* 0xE6 */ // OEM 固定
	/* 0xE7 */ VK_PACKET              = 0xE7, // Unicode 文字がキーストロークであるかのように渡されます。 キーは VK_PACKET 、キーボード以外の入力メソッドに使用される 32 ビット仮想キー値の下位ワードです。 詳細については、「解説」、、およびSendInputWM_KEYDOWN「KEYBDINPUT〗」を参照してください。WM_KEYUP
	/* 0xE8 */ // 未割り当て
	/* 0xE9 */ // OEM 固定
	/* 0xEA */ // OEM 固定
	/* 0xEB */ // OEM 固定
	/* 0xEC */ // OEM 固定
	/* 0xED */ // OEM 固定
	/* 0xEE */ // OEM 固定
	/* 0xEF */ // OEM 固定

	// ===================================================================
	// 0xF0～0xFFの定義
	// ===================================================================
	/* 0xF0 */ // OEM 固定
	/* 0xF1 */ // OEM 固定
	/* 0xF2 */ // OEM 固定
	/* 0xF3 */ // OEM 固定
	/* 0xF4 */ // OEM 固定
	/* 0xF5 */ // OEM 固定
	/* 0xF6 */ VK_ATTN                = 0xF6, // Attn キー
	/* 0xF7 */ VK_CRSEL               = 0xF7, // CrSel キー
	/* 0xF8 */ VK_EXSEL               = 0xF8, // ExSel キー
	/* 0xF9 */ VK_EREOF               = 0xF9, // EOF キーを消去する
	/* 0xFA */ VK_PLAY                = 0xFA, // 再生キー
	/* 0xFB */ VK_ZOOM                = 0xFB, // ズーム キー
	/* 0xFC */ VK_NONAME              = 0xFC, // 予約されています。
	/* 0xFD */ VK_PA1                 = 0xFD, // PA1 キー
	/* 0xFE */ VK_OEM_CLEAR           = 0xFE, // クリア キー
	/* 0xFF */ // 不明(仕様なし)
}
