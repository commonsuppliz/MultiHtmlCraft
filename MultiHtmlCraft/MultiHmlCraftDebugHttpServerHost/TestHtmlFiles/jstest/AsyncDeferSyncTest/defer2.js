console.log('⏳ [defer2.js] 実行（HTMLパース後・DOMContentLoaded前 2番目）');


console.log('⏳ [defer2.js] 開始（3秒間の処理遅延をシミュレート中...）');

// 3秒間の同期的なビジーウェイト（メインスレッドをブロック）
const startDefer2 = Date.now();
while (Date.now() - startDefer2 < 3000) {
  // 3秒間ループし続ける
}

console.log('⏳ [defer2.js] 終了');