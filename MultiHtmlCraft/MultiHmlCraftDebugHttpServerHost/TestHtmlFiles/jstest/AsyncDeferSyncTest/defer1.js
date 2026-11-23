console.log('⏳ [defer1.js] 開始（3秒間の処理遅延をシミュレート中...）');

// 3秒間の同期的なビジーウェイト（メインスレッドをブロック）
const start = Date.now();
while (Date.now() - start < 3000) {
  // 3秒間ループし続ける
}

console.log('⏳ [defer1.js] 終了');