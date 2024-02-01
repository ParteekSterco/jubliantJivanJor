﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="_404" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        img
        {
            text-align: center;
        }
        .w-75
        {
            width: 350px;
        }
        .innerErrorPage h1
        {
            font-size: 8vw;
            line-height: 1.5;
            font-weight: bold;
            color: #007ec5;
            position: relative;
            margin-top: 0;
            margin-bottom: 0;
            font-family: 'Oswald' , sans-serif;
        }
        .innerErrorPage h2
        {
            font-size: 2.5vw;
            line-height: 3vw;
            color: #007ec5;
            margin: -15px 0 25px 0;
            font-family: 'Open Sans' , sans-serif;
        }
        .innerErrorPage .btn
        {
            font-size: 1.05vw;
            background: #007ec5;
            color: #FFFFFF;
            padding: .5vw 2.5vw;
            border-radius: 2.5vw;
            margin-top: 10px;
            font-weight: bold;
            text-transform: uppercase;
            display: inline-block;
            text-decoration: none;
            font-family: 'Open Sans' , sans-serif;
        }
        
        .innerErrorPage p
        {
            text-align: center;
            font-weight: bold;
            color: #666;
            font-family: 'Open Sans' , sans-serif;
            font-size: 18px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; padding:100px 0;">
        <img src="/images/logo.png" class="w-75" />
        <div class="innerErrorPage">
            <h1 class="m-0">
                404</h1>
            <h2>
                Page Not Found</h2>
            <p>
                Either something went wrong or page doesnt exist anymore</p>
            <a href="/" class="btn secondary-btn-outline text-center text-md-left">Go to Home</a>
        </div>
    </div>
    </form>
</body>
</html>
