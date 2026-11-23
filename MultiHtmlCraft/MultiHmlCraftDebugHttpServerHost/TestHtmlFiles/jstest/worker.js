// メインスレッドからメッセージ受信
onmessage = function(e) {
  // 受信したメッセージに応答
   console.log("worker.js is called");
  postMessage('受信: ' + e.data);

};