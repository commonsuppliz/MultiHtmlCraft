<%@ Page Language="C#" AutoEventWireup="true" %>
<!DOCTYPE html>
<html lang="ja">
<head>
    <meta charset="UTF-8" />
    <title>POSTデータ表示</title>
</head>
<body>
    <h2>POSTされたデータ</h2>
    <ul>
        <li>textbox1: <%: Request.Form["textbox1"] %></li>
    </ul>
    <hr />
    <h3>全POSTデータ</h3>
    <ul>
    <% foreach (string key in Request.Form.AllKeys) { %>
        <li><b><%: key %></b>: <%: Request.Form[key] %></li>
    <% } %>
    </ul>
</body>
</html>