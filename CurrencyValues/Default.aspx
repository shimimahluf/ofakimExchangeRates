<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CurrencyValues.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .button {
            margin-top: 10px;
        }

        .grid {
            margin-top: 10px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Retrieve time: <asp:Label ID="lblRetrieveDate" runat="server" Text=""></asp:Label>
            <asp:GridView ID="gvExchangeRates" runat="server" AutoGenerateColumns="false" ShowHeader="false" CssClass="grid">

                <Columns>
                    <asp:BoundField DataField="Key" />
                    <asp:BoundField DataField="Value" DataFormatString="{0:F3}" />
                </Columns>
            </asp:GridView>

             <asp:Button ID="btnUpdate" runat="server" Text="Update from API" OnClick="btnUpdate_Click" CssClass="button" />
        </div>
    </form>
</body>
</html>
