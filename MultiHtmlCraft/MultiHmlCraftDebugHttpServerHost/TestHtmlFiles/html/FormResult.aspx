<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html>
<html lang="ja">
<head>
    <meta charset="UTF-8">
    <title>POST受信結果</title>
    <style>
        body { 
            font-family: Meiryo, sans-serif; 
            margin: 40px; 
            line-height: 1.6;
        }
        table { 
            border-collapse: collapse; 
            width: 100%; 
            max-width: 800px; 
        }
        th, td { 
            border: 1px solid #666; 
            padding: 12px; 
            text-align: left; 
            height: 30px;
        }
        th { 
            background-color: #f4f4f4; 
            width: 180px; 
        }
        .value { background: #f9f9f9; }
    </style>
</head>
<body>
    <h1>POST受信結果</h1>

    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                string rawData = string.Empty;

                // 既にストリームが読み進められている場合に備えて、読み取り位置を先頭に戻す
                if (Request.InputStream.CanSeek)
                {
                    Request.InputStream.Position = 0;
                }

                // クライアントの文字コード（通常は UTF-8）に合わせて読み取る
                Encoding encoding = Request.ContentEncoding ?? Encoding.UTF8;

                using (var reader = new StreamReader(Request.InputStream, encoding))
                {
                    rawData = reader.ReadToEnd();
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("<div>rawData :" + rawData +"</div>");
                sb.Append("<hr/");
                
  
                sb.Append("<table>");
                sb.Append("<tr><th>項目</th><th>受信した値</th></tr>");

                AddRow(sb, "名前", Request.Form["name"]);
                AddRow(sb, "メールアドレス", Request.Form["email"]);
                AddRow(sb, "年齢", Request.Form["age"]);
                AddRow(sb, "性別", Request.Form["gender"]);

                // 趣味
                string hobby = Request.Form["hobby"];
                if (!string.IsNullOrEmpty(hobby))
                    hobby = hobby.Replace(",", ", ");
                AddRow(sb, "趣味", hobby);

                // メッセージ
                string message = Request.Form["message"];
                if (!string.IsNullOrEmpty(message))
                    message = Server.HtmlEncode(message).Replace("\n", "<br>");
                AddRow(sb, "メッセージ", message);

                sb.Append("</table>");

                litResult.Text = sb.ToString();
            }
            else
            {
                litResult.Text = "<p>POSTデータがありません。</p>";
            }
        }

        private void AddRow(StringBuilder sb, string label, string value)
        {
            string val = string.IsNullOrEmpty(value) ? "（未入力）" : value;
            
            sb.Append("<tr><td><strong>");
            sb.Append(label);
            sb.Append("</strong></td><td class='value'>");
            sb.Append(val);
            sb.Append("</td></tr>");
        }
    </script>

    <asp:Literal ID="litResult" runat="server"></asp:Literal>

    <div style="margin-top: 30px;">
        <a href="FormInput.aspx">← 入力フォームに戻る</a>
    </div>
</body>
</html>